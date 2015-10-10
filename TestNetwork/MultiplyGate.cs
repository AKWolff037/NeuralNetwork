using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public class MultiplyGate<T> : IGate<T> where T : ICanMultiply<T>, ICanAdd<T>
    {
        public MultiplyGate()
        {
            ReturnValue = null;
            XValue = null;
            YValue = null;
        }
        public IUnit<T> ReturnValue { get; set; }
        public IUnit<T> XValue { get; set; }
        public IUnit<T> YValue { get; set; }
        public IUnit<T> Forward(IUnit<T> input1, IUnit<T> input2)
        {
            XValue = input1;
            YValue = input2;
            ReturnValue = new SimpleUnit<T>(input1.Value.MultiplyMe(input2.Value), default(T));
            return ReturnValue; 
        }

        public void Backward()
        {
            XValue.Gradient = XValue.Gradient.AddMe(YValue.Value.MultiplyMe(ReturnValue.Gradient));
            YValue.Gradient = YValue.Gradient.AddMe(XValue.Value.MultiplyMe(ReturnValue.Gradient));
        }
    }
    public class AddGate<T> : IGate<T> where T : ICanMultiply<T>, ICanAdd<T>
    {
        public AddGate()
        {
            ReturnValue = null;
            XValue = null;
            YValue = null;
        }
        public IUnit<T> ReturnValue { get; set; }
        public IUnit<T> XValue { get; set; }
        public IUnit<T> YValue { get; set; }
        public IUnit<T> Forward(IUnit<T> input1, IUnit<T> input2)
        {
            XValue = input1;
            YValue = input2;
            ReturnValue = new SimpleUnit<T>(input1.Value.AddMe(input2.Value), default(T));
            return ReturnValue;
        }
        public void Backward()
        {
            XValue.Gradient = XValue.Gradient.AddMe(ReturnValue.Gradient);
            YValue.Gradient = YValue.Gradient.AddMe(ReturnValue.Gradient);
        }
    }
    public class SigmoidGate : IGate<DoubleNumber>
    {
        public SigmoidGate()
        {
            XValue = null;
            YValue = null;
            ReturnValue = null;
        }
        public IUnit<DoubleNumber> XValue { get; set; }
        public IUnit<DoubleNumber> YValue { get; set; }
        public IUnit<DoubleNumber> ReturnValue { get; set; }
        public IUnit<DoubleNumber> Forward(IUnit<DoubleNumber> input1, IUnit<DoubleNumber> input2)
        {
            XValue = input1;
            YValue = null;
            ReturnValue = new SimpleUnit<DoubleNumber>(new DoubleNumber(input1.Value.Sigmoid().Value), new DoubleNumber(0.00));
            return ReturnValue;
        }
        public void Backward()
        {
            var sig = new DoubleNumber(XValue.Value.Sigmoid().Value);
            var one = new DoubleNumber(1.00);
            var delta = new DoubleNumber(sig.MultiplyMe(one.SubtractIt(sig)).Value);
            delta = new DoubleNumber(delta.MultiplyMe(ReturnValue.Gradient).Value);
            XValue.Gradient = new DoubleNumber(XValue.Gradient.AddMe(delta).Value);
        }
    }
}
