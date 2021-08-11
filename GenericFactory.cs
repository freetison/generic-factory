using System;
using System.Collections.Generic;
using System.Linq;

namespace Tixone.GenericFactory
{
    public class GenericFactory<T, TK> where TK : class
    {
        private readonly Dictionary<T, Func<TK>> _dict = new Dictionary<T, Func<TK>>();

        public GenericFactory() { }

        public void Register(T type, Func<TK> ctor)
        {
            if (ctor is null) return;
            _dict.Add(type, ctor);
        }

        public TK Get(T type) => _dict.TryGetValue(type, out var constructor) ? constructor() : default(TK);

        public IList<Func<TK>> GetAll() => _dict.Count > 0 ? _dict.Values.ToList() : null;
    }
}
