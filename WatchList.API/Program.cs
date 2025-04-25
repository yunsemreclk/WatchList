
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WatchList.Business.Absract;
using WatchList.Business.Concrate;
using WatchList.DataAccess.Abstract;
using WatchList.DataAccess.Context;
using WatchList.DataAccess.Repositories;

namespace WatchList.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Oluþturduðum repositorylerilerin(depo), api tarafýnda registration(kayýt) iþlerimin yapýlmasý
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //registration
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));


            builder.Services.AddDbContext<WatchListContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
