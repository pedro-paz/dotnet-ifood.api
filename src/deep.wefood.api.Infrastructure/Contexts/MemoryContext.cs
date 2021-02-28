using System.Collections.Generic;

namespace deep.wefood.api.Infrastructure.Contexts
{
    public class MemoryContext<T>
    {
        public List<T> Entities = new List<T>();
    }
}
