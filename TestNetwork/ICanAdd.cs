using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public interface ICanAdd<T>
    {
        Func<T, T, T> Add { get; }
        T AddMe(T input);
    }
}
