using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface Interface_ActivationFunction
    {
        double activationFunction(double x);
        double activationFunction_Prime(double x);
    }
}
