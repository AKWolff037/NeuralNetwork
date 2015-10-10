using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public class Circuit
    {
        IUnit<DoubleNumber> a = new SimpleUnit<DoubleNumber>(new DoubleNumber(1.0), new DoubleNumber(0.0));
        IUnit<DoubleNumber> b = new SimpleUnit<DoubleNumber>(new DoubleNumber(2.0), new DoubleNumber(0.0));
        IUnit<DoubleNumber> c = new SimpleUnit<DoubleNumber>(new DoubleNumber(-3.0), new DoubleNumber(0.0));
        IUnit<DoubleNumber> x = new SimpleUnit<DoubleNumber>(new DoubleNumber(-1.0), new DoubleNumber(0.0));
        IUnit<DoubleNumber> y = new SimpleUnit<DoubleNumber>(new DoubleNumber(3.0), new DoubleNumber(0.0));

        IGate<DoubleNumber> mGate1 = new MultiplyGate<DoubleNumber>();
        IGate<DoubleNumber> mGate2 = new MultiplyGate<DoubleNumber>();

        IGate<DoubleNumber> aGate1 = new AddGate<DoubleNumber>();
        IGate<DoubleNumber> aGate2 = new AddGate<DoubleNumber>();

        IGate<DoubleNumber> sGate1 = new SigmoidGate();

        public IUnit<DoubleNumber> Result = new SimpleUnit<DoubleNumber>(new DoubleNumber(0.00), new DoubleNumber(0.00));
        public void BackwardNeuron()
        {
            sGate1.Backward();
            aGate2.Backward();
            aGate1.Backward();
            mGate2.Backward();
            mGate1.Backward();

            var step_size = new DoubleNumber(0.01);
            a.Value = a.Value.AddMe(step_size.MultiplyMe(a.Gradient));
            b.Value = b.Value.AddMe(step_size.MultiplyMe(b.Gradient));
            c.Value = c.Value.AddMe(step_size.MultiplyMe(b.Gradient));
            x.Value = x.Value.AddMe(step_size.MultiplyMe(x.Gradient));
            y.Value = y.Value.AddMe(step_size.MultiplyMe(y.Gradient));
        }
        public void ForwardNeuron()
        {
            var ax = mGate1.Forward(a, x);
            var by = mGate2.Forward(b, y);

            var axpby = aGate1.Forward(ax, by);
            var axpbypc = aGate2.Forward(axpby, c);

            Result = sGate1.Forward(axpbypc, null);
        }
        public void PrintResult()
        {
            Console.WriteLine("Circuit output: " + Result.Value.Value);            
        }
    }
}
