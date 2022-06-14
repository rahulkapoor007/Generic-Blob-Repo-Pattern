using AzureRepositories.Abstraction.Contracts;
using AzureRepositories.Common.Models;
using AzureRepositories.Implementation.Concrete;
using AzureRepositories.Implementation.ContainerFactory;
using GenericBlobStorage.IServices;
using GenericBlobStorage.Services;

namespace GenericBlobStorage.StartupExtensions
{
    public static class StartupConfiguration
    {
        public static IServiceCollection ConfiguringRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBlobStorage, BlobStorage>();
            return services;
        }
        public static IServiceCollection ConfiguringServices(this IServiceCollection services)
        {
            services.AddScoped<IUploadService, UploadService>();
            return services;

        }
        public static IServiceCollection ConfiguringGlobaleServices(this IServiceCollection services, IConfiguration configuration)
        {
            BlobOptions.Options = configuration.GetSection("BlobResources").Get<BlobResources>();
            services.AddSingleton(new BlobContainerFactory(BlobOptions.Options));
            return services;

        }
    }
}
