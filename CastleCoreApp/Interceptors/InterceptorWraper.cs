using Castle.DynamicProxy;
using CastleCoreApp.Services;

namespace CastleCoreApp.Interceptors
{
    public class InterceptorWraper
    {
        private readonly IMailService _mailService;
        private readonly ILoggerService _loggerService;
        private readonly ICacheService _cacheService;
        private readonly ProxyGenerator _proxyGenerator;

        public InterceptorWraper(IMailService mailService, ILoggerService loggerService, ICacheService cacheService)
        {
            _mailService = mailService;
            _loggerService = loggerService;
            _proxyGenerator = new ProxyGenerator();
            _cacheService = cacheService;
        }

        public TInterface Wrap<TInterface>(TInterface target)
            where TInterface : class
        {
            if (!typeof(TInterface).IsInterface)
            {
                throw new ArgumentException("The type argument TInterface should be interface.");
            }

            var proxyGenerationOptions = new ProxyGenerationOptions
            {
                Selector = new InterceptorSelector()
            };

            return _proxyGenerator.CreateInterfaceProxyWithTarget<TInterface>(
                target, 
                proxyGenerationOptions, 
                new LoggerInterceptor(_loggerService), 
                new MailInterceptor(_mailService),
                new CacheInterceptor(_cacheService)
                );
        }
    }
}
