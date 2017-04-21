using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Startup
{
    class Program
    {
        static void Main()
        {
            // layer 1
            Node a = new Node("a");
            Node b = new Node("b");
            Layer layer1 = new Layer();
            layer1.AddNode(ref a);
            layer1.AddNode(ref b);
            // layer 2
            Node c = new Node("c");
            Node d = new Node("d");
            Layer layer2 = new Layer();
            layer2.AddNode(ref c);
            layer2.AddNode(ref d);

            // Connectors layer1 -> layer2
            Connector con_a_c = new Connector(ref c, 0f);
            a.AddConnector(ref con_a_c);
            Connector con_b_c = new Connector(ref c, 0f);
            Connector con_b_d = new Connector(ref d, 0f);
            b.AddConnector(ref con_b_c);
            b.AddConnector(ref con_b_d);

            // form the network
            Network network = new Network();
            network.AddLayer(ref layer1);
            network.AddLayer(ref layer2);
            network.PrintNetwork();

            Console.ReadKey();
        }
    }
}
