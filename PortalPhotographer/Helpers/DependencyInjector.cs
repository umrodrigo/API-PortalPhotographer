using Api.ViewModel;
using Api.ViewModel.Interface;
using Data;

namespace Api.Helpers
{
    public static class Injector
    {
        private static IServiceProvider ServiceProvider { get; set; }
        private static IServiceCollection Services { get; set; }
        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static PhotographerContext GetDbContext()
        {
            return GetService<PhotographerContext>();
        }

        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserViewModel, UserViewModel>();

            Services = services;
            return services;
        }
    }
}
