using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            return services.AddAutoMapper(config => { }, typeof(ApiConfiguration).GetTypeInfo().Assembly);
        }
    }
}
