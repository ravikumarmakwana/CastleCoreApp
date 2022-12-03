namespace CastleCoreApp.Services
{
    public interface ILoggerService
    {
        void LogError(string message);
        void LogInformation(string message);
    }
}
