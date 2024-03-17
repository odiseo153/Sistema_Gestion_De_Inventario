

using Application.Chaching;
using Microsoft.Extensions.Caching.Memory;

namespace  Application.Chaching_
{
    public sealed class ChacheService1 : IChacheService
    {
        private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(3);   
        private readonly IMemoryCache memoryCache;

        public ChacheService1(IMemoryCache _memoryCache)
        {
            this.memoryCache = _memoryCache;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, Task<T>> factory, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            T result =await memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(expiration ?? DefaultExpiration);

                    return factory(cancellationToken);
                });

            return result;
        }
    }
}
