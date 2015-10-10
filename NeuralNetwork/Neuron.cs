using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Neuron
    {
        public INeuronInput[] Inputs { get; set; }
        public Func<INeuronInput[], double> NeuralFunction { get; set; }
        public double CalculateResult()
        {
            if (NeuralFunction != null)
            {
                return NeuralFunction.Invoke(Inputs);
            }
            else
            {
                throw new InvalidOperationException("Cannot calculate result when NeuralFunction is null");
            }
        }
    }
}
