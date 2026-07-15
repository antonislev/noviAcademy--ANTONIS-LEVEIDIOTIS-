using MediatR;
using Microsoft.Extensions.Logging;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Decorators
{
    public class QueryCachingDecorator<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>, ICachedQuery
    {
        private readonly IRequestHandler<TRequest, TResult> _inner;
        private readonly ICache _cache;
        private readonly ILogger<QueryCachingDecorator<TRequest, TResult>> _logger;

        public QueryCachingDecorator(
            IRequestHandler<TRequest, TResult> inner,
            ICache cache,
            ILogger<QueryCachingDecorator<TRequest, TResult>> logger)
        {
            _inner = inner;
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (_cache.TryGet(request.CacheKey, out TResult? cached) && cached is not null)
            {
                _logger.LogInformation("Cache HIT  {Key}", request.CacheKey);
                return cached;
            }

            _logger.LogInformation("Cache MISS {Key} - loading from handler", request.CacheKey);
            var result = await _inner.Handle(request, cancellationToken);
            if (result is not null)
                _cache.Set(request.CacheKey, result, request.CacheTtl);
            return result;
        }
    }
}
