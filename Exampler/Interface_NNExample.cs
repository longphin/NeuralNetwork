using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Exampler
{
    public abstract class Interface_NNExample
    {
        Network network { get; set; }
        Interface_ActivationFunction activationFunc { get; set; } = new Sigmoid();

        public double calcActivationFunc(double val)
        {
            return (activationFunc.activationFunction(val));
        }
        public double calcActivationFunc_Prime(double val)
        {
            return (activationFunc.activationFunction_Prime(val));
        }
    }
}
