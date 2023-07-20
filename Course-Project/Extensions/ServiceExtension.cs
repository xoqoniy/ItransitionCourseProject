using Course_Project.Dal.IRepositories;
using Course_Project.Dal.Repositories;
using Course_Project.Service.Interfaces;
using Course_Project.Service.Services;

namespace Course_Project.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


            services.AddScoped<IUserService, UserService>();
        }
    }
}
