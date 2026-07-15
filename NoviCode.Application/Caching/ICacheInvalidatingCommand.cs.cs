using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Caching
{
    public interface ICacheInvalidatingCommand<in TResult>
    {
        IEnumerable<string> CacheKeysToInvalidate(TResult result);
    }

}
