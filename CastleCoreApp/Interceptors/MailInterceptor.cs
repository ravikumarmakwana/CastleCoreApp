using Castle.DynamicProxy;
using CastleCoreApp.Services;

namespace CastleCoreApp.Interceptors
{
    public class MailInterceptor : IAsyncInterceptor
    {
        private readonly IMailService _mailService;

        public MailInterceptor(IMailService mailService)
        {
            _mailService = mailService;
        }

        public void InterceptAsynchronous(IInvocation invocation)
        {
            _mailService.SendMail();
            // Before method call
            invocation.Proceed();
            // After method call
        }

        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {
            // Before method call
            invocation.Proceed();
            // After method call
            _mailService.SendMail();
        }

        public void InterceptSynchronous(IInvocation invocation)
        {
            // Before method call
            invocation.Proceed();
            // After method call
        }
    }
}
