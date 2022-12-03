using CastleCoreApp.Interceptors;

namespace CastleCoreApp.Extensions
{
    public static class InterceptorExtension
    {
        public static IServiceCollection AddInterceptoreScoped<TInterface, TImplementation>(this IServiceCollection services)
            where TImplementation : class, TInterface
            where TInterface : class
        {
            services.AddScoped<TImplementation>();

            services.AddScoped(providers =>
                providers.GetRequiredService<InterceptorWraper>()
                    .Wrap<TInterface>(providers.GetRequiredService<TImplementation>())
            );

            return services;
        }
    }
}
