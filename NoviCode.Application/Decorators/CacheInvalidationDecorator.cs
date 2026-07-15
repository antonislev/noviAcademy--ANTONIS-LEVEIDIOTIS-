using MediatR;
using Microsoft.Extensions.Logging;
using NoviCode.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Decorators
{
    public class CacheInvalidationDecorator<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>, ICacheInvalidatingCommand<TResult>
    {
        private readonly IRequestHandler<TRequest, TResult> _inner;
        private readonly ICache _cache;
        private readonly ILogger<CacheInvalidationDecorator<TRequest, TResult>> _logger;

        public CacheInvalidationDecorator(
            IRequestHandler<TRequest, TResult> inner,
            ICache cache,
            ILogger<CacheInvalidationDecorator<TRequest, TResult>> logger)
        {
            _inner = inner;
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var result = await _inner.Handle(request, cancellationToken);
            foreach (var key in request.CacheKeysToInvalidate(result))
            {
                _cache.Remove(key);
                _logger.LogInformation("Cache invalidated {Key}", key);
            }
            return result;
        }
    }
}
