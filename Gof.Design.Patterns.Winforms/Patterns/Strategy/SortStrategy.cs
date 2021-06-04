
using System.Collections.Generic;

namespace Gof.Design.Patterns.Winforms.Patterns.Strategy
{
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
}
