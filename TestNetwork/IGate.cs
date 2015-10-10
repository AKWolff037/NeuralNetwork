using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public interface IGate<T>
    {
        IUnit<T> ReturnValue { get; set; }
        IUnit<T> XValue { get; set; }
        IUnit<T> YValue { get; set; }
        IUnit<T> Forward(IUnit<T> input1, IUnit<T> input2);
        void Backward();
    }
}
