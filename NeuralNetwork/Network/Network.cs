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
        public Node biasnode { get; set; }// = new Node();

        public Network()
        {
        }
        
        public void AddLayer(Layer layer)
        {
            layers.Add(layer);
        }

        public void PrintNetwork()
        {
            // print other nodes
            biasnode.PrintNode();
            foreach(Layer layer in layers)
            {
                foreach(Node node in layer.nodes)
                {
                    node.PrintNode();
                }
            }
        }

        private double GetRandomDouble(Random rnd, double min, double max)
        {
            return (rnd.NextDouble() * (max - min) + min);
        }

        public void initializeWeights()
        {
            foreach(Layer layer in layers)
            {
                foreach(Node node in layer.nodes)
                {
                    foreach(Connector connector in node.forwardConnectors)
                    {
                        connector.weight = GetRandomDouble(getrandom, -1d/Math.Sqrt((double)layer.nodes.Count), 1d/Math.Sqrt((double)layer.nodes.Count));//(double)getrandom.Next(1,100)/(double)200;
                    }
                }
            }
            foreach(Connector con in biasnode.forwardConnectors)
            {
                con.weight = GetRandomDouble(getrandom, -.3, .3); //(double)getrandom.Next(1, 100) / (double)200;
            }
        }

        public void forwardPropogate(inputVector inputData)
        {
            // initialize input layer
            int nonBiasNodeIterator = 0;
            for (int i = 0; i < layers[0].nodes.Count; i++)
            {
                if(layers[0].nodes[i].isBiasNode == false)
                {
                    layers[0].nodes[i].output = inputData.input[nonBiasNodeIterator];
                    nonBiasNodeIterator += 1;
                }
            }

            if (layers.Count < 2) return; // If there is only 1 layer (which shouldn't happen), then do nothing.
            
            // forward propogate
            for(int i = 1; i<layers.Count; i++)
            {
                foreach(Node node in layers[i].nodes)
                {
                    if (node.isBiasNode == false)
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
            }
        }

        public void backPropogate(outputVector trueOutput)
        {
            // initialize error layer
            double TotalError = 0;
            int nonBiasNodeIterator = 0;
            for (int i = 0; i<layers[layers.Count - 1].nodes.Count; i++)
            {
                Node node = layers[layers.Count - 1].nodes[i];
                if (node.isBiasNode == false) // this check shouldn't be needed
                {
                    node.error = calcActivationFunc_Prime(node.weightedSum) * (trueOutput.output[nonBiasNodeIterator] - node.output);

                    TotalError += node.error;
                    nonBiasNodeIterator += 1;
                }
            }
            //Console.WriteLine(TotalError.ToString());

            //Console.WriteLine("error: " + TotalError.ToString());

            //if (layers.Count < 2) return; // If there is only 1 layer (which shouldn't happen), then do nothing.

            // back propogate
            for (int i = layers.Count-2; i>=0; i--)
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
            // update weights for bias node
            foreach(Connector con in biasnode.forwardConnectors)
            {
                con.weight += alpha * con.To.error;
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
                forwardPropogate(data.inputList[j]);

                // print out results
                double TotalError = 0d;
                int nonBiasNodeIterator = 0;
                for(int i = 0; i<layers[layers.Count - 1].nodes.Count; i++)
                {
                    Node node = layers[layers.Count - 1].nodes[i];
                    if (node.isBiasNode == false)
                    {
                        Console.WriteLine(node.name + " guess " + node.output.ToString() + " : " + data.outputList[j].output[nonBiasNodeIterator].ToString());
                        TotalError += Math.Pow(node.output - data.outputList[j].output[nonBiasNodeIterator], 2);
                        nonBiasNodeIterator += 1;
                    }
                }
                Console.WriteLine("Total Error: " + TotalError.ToString());
            }
        }
    }
}
