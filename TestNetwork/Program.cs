using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;
namespace TestNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var circ = new Circuit();
            circ.ForwardNeuron();
            circ.PrintResult();
            circ.Result.Gradient = new DoubleNumber(1.0);
            circ.BackwardNeuron();
            circ.ForwardNeuron();
            circ.PrintResult();
            Console.ReadLine();

            //double[,] trainingValues = new double[6, 3] 
            //{
            //    {1.2, 0.7, 1},
            //    {-0.3, 0.5, -1},
            //    {-3, -1, 1},
            //    {0.1, 1.0, -1},
            //    {3.0, 1.1, -1},
            //    {2.1, -3, 1}
            //};
            //var rand = new Random();
            //var parameter = rand.Next(0, 6);
            //var trainerA = trainingValues[parameter, 0];
            //var trainerB = trainingValues[parameter, 1];
            //var trainerC = trainingValues[parameter, 2];

            //var trainer = new double[] { trainerA, trainerB, trainerC };
            //var x = 1.0;
            //var y = 1.0;
            //var result = TrainingFunction(x, y, trainer);

        }
        public static double TrainingFunction(double x, double y, double[] training)
        {
            var result = training[0] * x + training[1] * y + training[2];
            return result;
        }
        public static double Sigmoid(double input)
        {
            var exponent = -input;
            var y = Math.Exp(-input);
            return 1 / (1 + y);
        }
    }
}
