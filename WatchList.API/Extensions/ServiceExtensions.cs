using WatchList.Business.Absract;
using WatchList.Business.Abstract;
using WatchList.Business.Concrate;
using WatchList.Business.Configurations;
using WatchList.DataAccess.Abstract;
using WatchList.DataAccess.Repositories;


namespace WatchList.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITMDbMovieService, TMDbMovieService>();
            services.AddScoped<ITMDbSeriesService, TMDbSeriesService>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.Configure<JwtTokenOptions>(configuration.GetSection("TokenOptions"));
            services.AddScoped<IJwtService, JwtService>();

        }
    }
}
