using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public abstract class Interface_NNExample
    {
        public Network network { get; set; } = new Network();
        public Interface_ActivationFunction activationFunc { get; set; }
    }
}
