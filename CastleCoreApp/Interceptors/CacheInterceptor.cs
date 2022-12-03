using Castle.DynamicProxy;
using CastleCoreApp.Services;

namespace CastleCoreApp.Interceptors
{
    public class CacheInterceptor : IAsyncInterceptor
    {
        private readonly ICacheService _cacheService;

        public CacheInterceptor(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public void InterceptAsynchronous(IInvocation invocation)
        {
            if (_cacheService.IsCacheAvailable())
            {
                //invocation.ReturnValue = _cacheService.GetValueFromCache();
                return;
            }

            invocation.Proceed();

            // Add return value to cache.
            if (invocation.ReturnValue != null)
            {
                _cacheService.StoreCache(/*key, invocation.ReturnValue*/);
            }
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
