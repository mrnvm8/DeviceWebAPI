using DeviceWebAPI.Application.Repositories.DeviceRepository;
using DeviceWebAPI.Application.Services.DeviceService;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceWebAPI.Application
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection Application(this IServiceCollection services)
        {
            services.AddSingleton<IDeviceRepository, DeviceRepository>();
            services.AddSingleton<IDeviceService, DeviceService>();

            return services;
        }
    }
}
