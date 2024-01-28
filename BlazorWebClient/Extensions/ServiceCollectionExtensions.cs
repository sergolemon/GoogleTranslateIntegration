using BlazorWebClient.Interfaces;
using BlazorWebClient.Services;
using BlazorWebClient.ViewModels.Main;

namespace BlazorWebClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainVm>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITranslateService, TranslateService>();
            services.AddHostedService<TgMessagesListener>();

            return services;
        }
    }
}
