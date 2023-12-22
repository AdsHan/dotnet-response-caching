using MediatR;
using ResponseCaching.API.Cache.DecoratorPattern;
using ResponseCaching.API.Common;

namespace ResponseCaching.API.Application.Messages.Behaviors;

public class CacheResponseBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICachedQuery
{
    private readonly ICacheService _cache;

    public CacheResponseBehavior(ICacheService cache)
    {
        _cache = cache;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await _cache.GetOrSetAsync<TResponse>(request.Key, request.Expiration, () => next());
    }

}
