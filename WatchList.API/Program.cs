
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WatchList.API.Extensions;
using WatchList.Business.Absract;
using WatchList.Business.Concrate;
using WatchList.Business.Configurations;
using WatchList.Business.Validators;
using WatchList.DataAccess.Abstract;
using WatchList.DataAccess.Context;
using WatchList.DataAccess.Repositories;
using WatchList.Entity.Entities;

namespace WatchList.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddServiceExtensions(builder.Configuration);
            //Oluþturduðum repositorylerilerin(depo), api tarafýnda registration(kayýt) iþlerimin yapýlmasý
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //registration
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));


            builder.Services.AddDbContext<WatchListContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
            });

            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<WatchListContext>().AddErrorDescriber<CustomErrorDescriber>();
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<JwtTokenOptions>();

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata= false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key)),
                    ClockSkew=TimeSpan.Zero,
                    NameClaimType= ClaimTypes.Name
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
