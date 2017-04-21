using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public abstract class Interface_NNExample
    {
        Network network { get; set; }
        Interface_ActivationFunction activationFunc { get; set; }
    }
}
