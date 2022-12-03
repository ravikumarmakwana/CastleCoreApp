using Castle.DynamicProxy;
using CastleCoreApp.Attributes;
using System.Reflection;

namespace CastleCoreApp.Interceptors
{
    public class InterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var targetMethod =
                type.GetMethod(method.Name, method.GetParameters().Select(p => p.ParameterType).ToArray());

            if (targetMethod == null)
            {
                return interceptors;
            }

            if (!targetMethod.GetCustomAttributes<LogAttribute>().Any())
            {
                interceptors = interceptors.Where(interceptor =>
                    !(interceptor is AsyncDeterminationInterceptor asyncInterceptor) ||
                    !(asyncInterceptor.AsyncInterceptor is LoggerInterceptor))
                    .ToArray();
            }

            if (!targetMethod.GetCustomAttributes<MailAttribute>().Any())
            {
                interceptors = interceptors.Where(interceptor =>
                    !(interceptor is AsyncDeterminationInterceptor asyncInterceptor) ||
                    !(asyncInterceptor.AsyncInterceptor is MailInterceptor))
                    .ToArray();
            }

            if (!targetMethod.GetCustomAttributes<CacheAttribute>().Any())
            {
                interceptors = interceptors.Where(interceptor =>
                    !(interceptor is AsyncDeterminationInterceptor asyncInterceptor) ||
                    !(asyncInterceptor.AsyncInterceptor is CacheInterceptor))
                    .ToArray();
            }

            return interceptors;
        }
    }
}
