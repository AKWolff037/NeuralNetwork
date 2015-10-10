using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public interface ICanSubtract<T>
    {
        Func<T, T, T> Subtract { get; }
        T SubtractMe(T input);
        T SubtractIt(T input);
    }
}
