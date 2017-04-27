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
            //var d = new SampleData1(0);
            var d = new SampleData2(2, false);
            //IActivationFunction sig = new Sigmoid();
            IActivationFunction af = new ArcTan();

            Network network = d.network;
            network.activationFunc = af;
            network.initializeWeights();
            
            for (int j = 0; j < 10000; j++)
            {
                for (int i = 0; i < d.GetSize(); i++)
                {
                    network.forwardPropogate(d.inputList[i]);

                    network.backPropogate(d.outputList[i]);
                }
            }
            Console.WriteLine("after training");
            network.PrintNetwork();

            network.Test(d.Test(1));
            Console.WriteLine("after test");
            network.PrintNetwork();

            Console.ReadKey();
        }
    }
}
