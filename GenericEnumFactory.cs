using System;
using System.Collections.Generic;
using System.Linq;

namespace Tixone.GenericFactory
{
    public class GenericEnumFactory<T> where T : class
    {
        private readonly Dictionary<Enum, Func<T>> _dict = new Dictionary<Enum, Func<T>>();

        public GenericEnumFactory() { }

        public void Register(Enum type, Func<T> ctor)
        {
            if (ctor is null) return;
            _dict.Add(type, ctor);
        }

        public T Get(Enum type) => _dict.TryGetValue(type, out var constructor) ? constructor() : default(T);

        public IList<Func<T>> GetAll() => _dict.Count > 0 ? _dict.Values.ToList() : null;
    }
}
