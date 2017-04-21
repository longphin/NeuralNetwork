using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Network
    {
        private List<Layer> layers = new List<Layer>();

        public Network()
        {
        }

        public void AddLayer(ref Layer layer)
        {
            layers.Add(layer);
        }

        public void PrintNetwork()
        {
            foreach(Layer layer in layers)
            {
                foreach(Node node in layer.nodes)
                {
                    if (!node.connectors.Any()) // then is end point
                        Console.WriteLine("endpoint " + node.name);
                    else
                        Console.WriteLine(node.name);

                    foreach (Connector connector in node.connectors)
                    {
                        Console.WriteLine(" -> " + connector.To.name);
                    }
                }
            }
        }
    }
}
