using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class SimpleNeuronInput : INeuronInput
    {
        public Type ValueType { get { return typeof(double); } }
        public object Value { get; set; }

        public SimpleNeuronInput(double val)
        {
            Value = val;
        }
    }
}
