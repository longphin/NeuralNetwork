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
            /*
            Network NN = new NN1().network;
            IActivationFunction sig = new Sigmoid();
            NN.activationFunc = sig;

            NN.initializeWeights();

            IData d = new SampleData1();
            
            for (int i = 0; i < d.GetSize(); i++)
            {
                NN.forwardPropogate(d.inputList[i]);
                
                NN.backPropogate(d.outputList[i]);
            }

            // print outs
            NN.PrintNetwork();
            */

            IData d = new SampleData1(2);
            Network network = d.network;

            IActivationFunction sig = new Sigmoid();
            network.activationFunc = sig;
            network.initializeWeights();

            for (int i = 0; i < d.GetSize(); i++)
            {
                network.forwardPropogate(d.inputList[i]);

                network.backPropogate(d.outputList[i]);
            }

            // print outs
            network.PrintNetwork();

            Console.ReadKey();
        }
    }
}
