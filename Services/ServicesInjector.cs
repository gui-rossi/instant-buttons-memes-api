using Microsoft.Extensions.DependencyInjection;
using Services.CrossCutting;
using Services.Interfaces;
using Services.Services;

namespace Services
{
    public static class ServicesInjector
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IButtonsService), typeof(ButtonsService));
            services.AddTransient<IBlobStorageService, BlobStorageService>();
        }
    }
}
