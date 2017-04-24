using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Network
    {
        public List<Layer> layers { get; set; } = new List<Layer>();
        public IActivationFunction activationFunc { get; set; }
        private static readonly Random getrandom = new Random(250);
        public static double alpha { get; set; } = 0.05d;

        public Network()
        {
        }
        
        public void AddLayer(Layer layer)
        {
            layers.Add(layer);
        }

        public void PrintNetwork()
        {
            foreach(Layer layer in layers)
            {
                foreach(Node node in layer.nodes)
                {
                    if (!node.forwardConnectors.Any()) // then is end point
                        Console.WriteLine("endpoint " + node.name + " (" + node.output + ")");
                    else
                        Console.WriteLine(node.name + " (" + node.output + ")");

                    foreach (Connector connector in node.forwardConnectors)
                    {
                        Console.WriteLine(" -> " + connector.To.name + " x" + connector.weight.ToString() + " (" + connector.To.output + ")");
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
                    foreach(Connector connector in node.forwardConnectors)
                    {
                        connector.weight = (double)getrandom.Next(1,100)/(double)1000;
                    }
                }
            }
        }

        public void forwardPropogate(inputVector inputData)
        {
            // initialize input layer
            for (int i = 0; i < inputData.input.Count; i++)
            {
                layers[0].nodes[i].output = inputData.input[i];
            }

            if (layers.Count < 2) return; // If there is only 1 layer (which shouldn't happen), then do nothing.
            
            // forward propogate
            for(int i = 1; i<layers.Count; i++)
            {
                foreach(Node node in layers[i].nodes)
                {
                    double sum = 0;
                    foreach(Connector con in node.backwardConnectors)
                    {
                        sum += con.weight * con.From.output;
                    }
                    node.weightedSum = sum;
                    node.output = calcActivationFunc(sum);
                }
            }
        }

        public void backPropogate(outputVector trueOutput)
        {
            // initialize error layer
            double TotalError = 0;
            for (int i = 0; i<trueOutput.output.Count; i++)
            {
                Node node = layers[layers.Count - 1].nodes[i];
                node.error = calcActivationFunc_Prime(node.weightedSum) * (trueOutput.output[i] - node.output);

                TotalError += node.error;
            }

            //Console.WriteLine("error: " + TotalError.ToString());

            if (layers.Count < 2) return; // If there is only 1 layer (which shouldn't happen), then do nothing.

            // back propogate
            for(int i = layers.Count-2; i>=0; i--)
            {
                foreach(Node node in layers[i].nodes)
                {
                    double sum = 0;
                    foreach(Connector con in node.forwardConnectors)
                    {
                        sum += con.weight * con.To.error;
                    }
                    node.error = calcActivationFunc_Prime(node.weightedSum) * sum;
                }
            }

            // update all weights in network using errors
            foreach (Layer layer in layers)
            {
                foreach(Node node in layer.nodes)
                {
                    foreach(Connector con in node.forwardConnectors)
                    {
                       con.weight += alpha * node.output * con.To.error;
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
        public void Test(IDataTest data)
        {
            if (layers.Count < 2) return; // If there is only 1 layer (which shouldn't happen), then do nothing.

            for (int j = 0; j<data.inputList.Count; j++)
            {
                for (int i = 0; i < data.inputList[j].input.Count; i++)
                {
                    layers[0].nodes[i].output = data.inputList[j].input[i];
                }

                // forward propogate
                for (int i = 1; i < layers.Count; i++)
                {
                    foreach (Node node in layers[i].nodes)
                    {
                        double sum = 0;
                        foreach (Connector con in node.backwardConnectors)
                        {
                            sum += con.weight * con.From.output;
                        }
                        node.weightedSum = sum;
                        node.output = calcActivationFunc(sum);
                    }
                }

                // print out results
                double TotalError = 0d;
                for(int i = 0; i<layers[layers.Count - 1].nodes.Count; i++)
                {
                    Node node = layers[layers.Count - 1].nodes[i];
                    Console.WriteLine(node.name + " guess " + node.output.ToString() + " : " + data.outputList[j].output[i].ToString());
                    TotalError += Math.Pow(node.output - data.outputList[j].output[i], 2);
                    }
                Console.WriteLine("Total Error: " + TotalError.ToString());
            }
        }
    }
}
