using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public interface ICanMultiply<T>
    {
        Func<T, T, T> Multiply {get;}
        T MultiplyMe(T input);
    }
}
