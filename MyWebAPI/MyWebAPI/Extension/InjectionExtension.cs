using Castle.MicroKernel.Registration;
using MyWebApi.Manager;
using MyWebApi.Manager.EntityFramework.DBContext;
using MyWebAPI.Base;

namespace MyWebAPI.Extension
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddMyWebApiService(this IServiceCollection services)
        {
            var types = typeof(ManagerModule).Assembly.GetTypes();
            types = types.Where(item => item.IsInterface && (item.BaseType == typeof(IManager) || item.BaseType == typeof(IRepository))).ToArray();

            foreach(var type in types)
            {
                services.AddTransient(type);
            }

            return services.AddDbContext<MyDbContext>();
            
        }
    }
}
