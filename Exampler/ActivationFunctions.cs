using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Exampler
{
    public class Sigmoid : Interface_ActivationFunction
    {
        public double activationFunction(double val)
        {
            // sigmoid function
            return (1 / (1 + Math.Pow(Math.E, val)));
        }

        public double activationFunction_Prime(double val)
        {
            return (val);
        }
    }
}
