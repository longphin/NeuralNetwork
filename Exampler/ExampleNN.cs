using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Exampler
{
    public class NN1 : INeuralNetwork
    {
        //public Network network { get; set; } = new Network();

        public NN1()
        {
            network = initializeNetwork();
        }

        private Network initializeNetwork()
        {
            // layer 1
            Node a1 = new Node("a1");
            Node a2 = new Node("a2");
            Node a3 = new Node("a3");
            Layer layer1 = new Layer();
            layer1.AddNode(ref a1);
            layer1.AddNode(ref a2);
            layer1.AddNode(ref a3);
            // layer 2
            Node b1 = new Node("b1");
            Node b2 = new Node("b2");
            Layer layer2 = new Layer();
            layer2.AddNode(ref b1);
            layer2.AddNode(ref b2);
            // layer 3
            Node c1 = new Node("c1");
            Node c2 = new Node("c2");
            Layer layer3 = new Layer();
            layer3.AddNode(ref c1);
            layer3.AddNode(ref c2);

            // Connectors layer1 -> layer2
            Connector con_a1_b1 = new Connector(ref a1, ref b1, 0.5f);
            a1.AddForwardConnector(ref con_a1_b1);
            b2.AddBackwardConnector(ref con_a1_b1);
            Connector con_a2_b1 = new Connector(ref a2, ref b1, 0.5f);
            Connector con_a2_b2 = new Connector(ref a2, ref b2, 0.5f);
            a2.AddForwardConnector(ref con_a2_b1);
            b1.AddBackwardConnector(ref con_a2_b1);
            a2.AddForwardConnector(ref con_a2_b2);
            b2.AddBackwardConnector(ref con_a2_b2);
            Connector con_a3_b2 = new Connector(ref a3, ref b2, 0.5f);
            a3.AddForwardConnector(ref con_a3_b2);
            b2.AddBackwardConnector(ref con_a3_b2);
            // Connectors layer2 -> layer3
            Connector con_b1_c1 = new Connector(ref b1, ref c1, 0.5f);
            Connector con_b1_c2 = new Connector(ref b1, ref c2, 0.5f);
            b1.AddForwardConnector(ref con_b1_c1);
            c1.AddBackwardConnector(ref con_b1_c1);
            b1.AddForwardConnector(ref con_b1_c2);
            c2.AddBackwardConnector(ref con_b1_c2);
            Connector con_b2_c1 = new Connector(ref b2, ref c1, 0.5f);
            Connector con_b2_c2 = new Connector(ref b2, ref c2, 0.5f);
            b2.AddForwardConnector(ref con_b2_c1);
            c1.AddBackwardConnector(ref con_b2_c1);
            b2.AddForwardConnector(ref con_b2_c2);
            c2.AddBackwardConnector(ref con_b2_c2);

            // form the network
            Network network = new Network();
            network.AddLayer(ref layer1);
            network.AddLayer(ref layer2);

            return (network);
        }
    }
}
