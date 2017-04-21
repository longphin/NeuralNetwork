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
            Example1 NN = new Example1();
            
            NN.network.PrintNetwork();
            
            Console.ReadKey();
        }
    }
}
