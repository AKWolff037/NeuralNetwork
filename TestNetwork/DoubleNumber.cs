using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    public interface ICanMath<T> : ICanAdd<T>, ICanSubtract<T>, ICanMultiply<T>, ICanSigmoid<T> where T : ICanAdd<T>, ICanSubtract<T>, ICanMultiply<T>, ICanSigmoid<T>
    {

    }
    public struct DoubleNumber : ICanMath<DoubleNumber>
    {
        private double _value;

        public double Value { get { return _value; } }
        //public DoubleNumber Value { get { return this; } set { this = value; } }
        public DoubleNumber(double number)
        {
            _value = number;
        }

        public Func<DoubleNumber, DoubleNumber, DoubleNumber> Add
        {
            get { return new Func<DoubleNumber, DoubleNumber, DoubleNumber>((x, y) => new DoubleNumber(x.Value + y.Value)); }
        }
        public Func<DoubleNumber, DoubleNumber, DoubleNumber> Subtract
        {
            get { return new Func<DoubleNumber, DoubleNumber, DoubleNumber>((x, y) => new DoubleNumber(x.Value - y.Value)); }
        }
        public Func<DoubleNumber, DoubleNumber, DoubleNumber> Multiply
        {
            get { return new Func<DoubleNumber, DoubleNumber, DoubleNumber>((x, y) => new DoubleNumber(x.Value * y.Value)); }
        }
        public DoubleNumber AddMe(DoubleNumber input)
        {
            return Add(new DoubleNumber(Value), input);
        }

        public DoubleNumber SubtractMe(DoubleNumber input)
        {
            return Subtract(input, new DoubleNumber(Value));
        }
        public DoubleNumber SubtractIt(DoubleNumber input)
        {
            return Subtract(new DoubleNumber(Value), input);
        }

        public DoubleNumber MultiplyMe(DoubleNumber input)
        {
            return Multiply(new DoubleNumber(Value), input);
        }

        public DoubleNumber Sigmoid()
        {
            var exp = Math.Exp(-Value);
            var sig = (1 / (1 + exp));
            return new DoubleNumber(sig);
        }
    }

}
