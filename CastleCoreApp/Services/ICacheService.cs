namespace CastleCoreApp.Services
{
    public interface ICacheService
    {
        bool IsCacheAvailable();
        void StoreCache();
        void GetValueFromCache();
    }
}
