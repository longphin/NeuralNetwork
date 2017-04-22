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
        public Interface_ActivationFunction activationFunc { get; set; }
        private static readonly Random getrandom = new Random(250);

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

        public void initializeWeights()
        {
            foreach(Layer layer in layers)
            {
                foreach(Node node in layer.nodes)
                {
                    foreach(Connector connector in node.connectors)
                    {
                        connector.weight = (double)getrandom.Next(1,100)/(double)1000;
                    }
                }
            }
        }

        public double calcActivationFunc(double x)
        {
            return (activationFunc.activationFunction(x));
        }
        public double calcActivationFunc_Prime(double x)
        {
            return (activationFunc.activationFunction_Prime(x));
        }
    }
}
