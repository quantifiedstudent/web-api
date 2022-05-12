using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Qs.Domain.IoC;

public static class DomainServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}