using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class inputVector
    {
        public List<double> input { get; set; } = new List<double>();
        public inputVector(List<double> inp)
        {
            input = inp;
        }
        public void AddElement(List<double> inp)
        {
            input.AddRange(inp);
        }
    }

    public class outputVector
    {
        public List<double> output { get; set; } = new List<double>();
        public outputVector(List<double> outp)
        {
            output = outp;
        }
        public void AddElement(List<double> outp)
        {
            output.AddRange(outp);
        }
    }

    public class IDataTest
    {
        public List<inputVector> inputList = new List<inputVector>();
        public List<outputVector> outputList = new List<outputVector>();

        public IDataTest() { }
    }
    public abstract class IData
    {
        private static readonly char[] nodeNamePrefix = { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        public List<inputVector> inputList = new List<inputVector>();
        public List<outputVector> outputList = new List<outputVector>();
        public Network network = new Network();

        public int GetSize()
        {
            return (inputList.Count);
        }
        
        public Network createNetwork(int inputVectorLength, int outputVectorLength, int numHiddenLayers, bool addBias)
        {
            Network network = new Network();

            // create input layer
            Layer inpLayer = new Layer();
            for (int i = 0; i < inputVectorLength; i++)
            {
                Node n = new Node(nodeNamePrefix[0] + i.ToString());
                inpLayer.AddNode(n);
            }
            network.AddLayer(inpLayer);
            // create hidden layers
            for (int numLayer = 0; numLayer < numHiddenLayers; numLayer++)
            {
                Layer hiddenLayer = new Layer();

                string res = new String(nodeNamePrefix[(numLayer + 1) % nodeNamePrefix.Length], (numLayer + 1) / nodeNamePrefix.Length + 1);
                for (int i = 0; i < inputVectorLength; i++)
                {
                    Node n = new Node(res + i.ToString());
                    hiddenLayer.AddNode(n);
                }

                network.AddLayer(hiddenLayer);
            }
            // create connectors from input to hidden layers, and from hidden to hidden layers
            for(int i = 0; i<numHiddenLayers; i++)
            {
                foreach(Node n in network.layers[i].nodes)
                {
                    foreach (Node n2 in network.layers[i + 1].nodes)
                    {
                        Connector con = new Connector(n, n2, 0.5d);
                        n.AddForwardConnector(con);
                        n2.AddBackwardConnector(con);
                    }
                }
            }
            // create output layer
            Layer outLayer = new Layer();

            string reso = new String(nodeNamePrefix[(numHiddenLayers + 1) % nodeNamePrefix.Length], (numHiddenLayers + 1) / nodeNamePrefix.Length + 1);
            for (int i = 0; i < outputVectorLength; i++)
            {
                Node n = new Node(reso + i.ToString());
                outLayer.AddNode(n);
            }
            network.AddLayer(outLayer);
            // create connectors from hidden layer to output layer
            foreach(Node n in network.layers[numHiddenLayers].nodes)
            {
                foreach(Node n2 in outLayer.nodes)
                {
                    Connector con = new Connector(n, n2, 0.5d);
                    n.AddForwardConnector(con);
                    n2.AddBackwardConnector(con);
                }
            }

            // Now add bias node and connect it to all other nodes
            if (addBias == true)
            {
                Node bias = new Node("bias", 1d, true);
                for (int i = 1; i < numHiddenLayers + 2; i++)
                {
                    foreach (Node node in network.layers[i].nodes)
                    {
                        Connector con = new Connector(bias, node, 0.5d);
                        bias.AddForwardConnector(con);
                        node.AddBackwardConnector(con);
                    }
                }
                /*
                foreach (Layer layer in network.layers)
                {
                    foreach (Node node in layer.nodes)
                    {
                        Connector con = new Connector(bias, node, 0.5d);
                        bias.AddForwardConnector(con);
                        node.AddBackwardConnector(con);
                    }
                }
                */
                inpLayer.AddNode(bias);
            }

            return (network);
        }
    }
}
