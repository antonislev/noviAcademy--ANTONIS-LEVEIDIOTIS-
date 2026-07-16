using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Caching
{
    public interface ICachedQuery
    {
        string CacheKey { get; }
        TimeSpan CacheTtl => TimeSpan.FromSeconds(60); // default; a query may override
    }
}
