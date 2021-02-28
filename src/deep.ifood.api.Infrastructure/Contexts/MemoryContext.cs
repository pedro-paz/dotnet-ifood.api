using System.Collections.Generic;

namespace deep.ifood.api.Infrastructure.Contexts
{
    public class MemoryContext<T>
    {
        public List<T> Entities = new List<T>();
    }
}
