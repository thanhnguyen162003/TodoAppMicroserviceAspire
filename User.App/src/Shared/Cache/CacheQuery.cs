using Shared.Abstractions.Caching;
using Shared.Abstractions.Core.CQRS;

namespace Shared.Cache;

public abstract record CacheQuery<TRequest, TResponse> : ICacheQuery<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
    where TResponse : class
{
    public virtual TimeSpan? AbsoluteExpirationRelativeToNow { get; }
    public virtual TimeSpan? AbsoluteLocalCacheExpirationRelativeToNow { get; }
    public virtual string Prefix => "Ch_";

    public virtual string CacheKey(TRequest request) => $"{Prefix}{typeof(TRequest).Name}";
}