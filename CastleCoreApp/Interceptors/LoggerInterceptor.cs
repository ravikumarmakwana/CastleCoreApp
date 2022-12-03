using Castle.DynamicProxy;
using CastleCoreApp.Services;

namespace CastleCoreApp.Interceptors
{
    public class LoggerInterceptor : IAsyncInterceptor
    {
        private readonly ILoggerService _loggerService;

        public LoggerInterceptor(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void InterceptAsynchronous(IInvocation invocation)
        {
            // Before method call
            invocation.Proceed();
            // After method call
        }

        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {
            // Before method call
            invocation.Proceed();
            // After method call
        }

        public void InterceptSynchronous(IInvocation invocation)
        {
            // Before method call
            invocation.Proceed();
            // After method call
        }
    }
}
