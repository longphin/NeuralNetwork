using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;
using Exampler;

namespace Startup
{
    class Program
    {
        static void Main()
        {
            Network NN = new Example1().network;
            Interface_ActivationFunction sig = (Interface_ActivationFunction)new Sigmoid();
            NN.activationFunc = sig;

            Console.WriteLine(NN.calcActivationFunc(3.2d));

            NN.PrintNetwork();
            
            Console.ReadKey();
        }
    }
}
