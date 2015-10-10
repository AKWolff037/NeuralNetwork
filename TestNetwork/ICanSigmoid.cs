using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public interface ICanSigmoid<T>
    {
        T Sigmoid();
    }
}
