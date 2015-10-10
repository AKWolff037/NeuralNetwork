using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public interface IUnit<T>
    {
        T Value { get; set; }
        T Gradient { get; set; }
    }
}
