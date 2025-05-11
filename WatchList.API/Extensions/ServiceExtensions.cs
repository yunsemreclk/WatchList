using WatchList.Business.Abstract;
using WatchList.Business.Concrate;
using WatchList.Business.Configurations;


namespace WatchList.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITMDbMovieService, TMDbMovieService>();
            services.AddScoped<ITMDbSeriesService, TMDbSeriesService>();

            services.Configure<JwtTokenOptions>(configuration.GetSection("TokenOptions"));
            services.AddScoped<IJwtService, JwtService>();

        }
    }
}
