using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public class SimpleUnit<T> : IUnit<T>
    {
        public T Value { get; set; }
        public T Gradient { get; set; }

        public SimpleUnit(T val, T grad)
        {
            Value = val;
            Gradient = grad;
        }
    }
}
