﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Node
    {
        public double weightedSum { get; set; } = 0;
        public double output { get; set; }
        public List<Connector> forwardConnectors { get; set; } = new List<Connector>();
        public List<Connector> backwardConnectors { get; set; } = new List<Connector>();
        public string name { get; set; }
        public double error { get; set; }
        public bool isBiasNode { get; set; } = false;

        public Node()
        {
            this.name = "undef";
        }

        public Node(string name)
        {
            this.name = name;
        }

        public Node(string name, double output, bool isBiasNode)
        {
            this.name = name;
            this.output = output;
            this.isBiasNode = isBiasNode;
        }

        public void AddForwardConnector(Connector newConnector)
        {
            forwardConnectors.Add(newConnector);
        }
        public void AddBackwardConnector(Connector newConnector)
        {
            backwardConnectors.Add(newConnector);
        }

        public void PrintNode()
        {
            if (!forwardConnectors.Any()) // then is end point
                Console.WriteLine("endpoint " + name + " (" + output.ToString() + ")");
            else
                Console.WriteLine(name + " (" + output.ToString() + ") " + weightedSum.ToString());

            foreach (Connector connector in forwardConnectors)
            {
                Console.WriteLine(" -> " + connector.To.name + " x" + connector.weight.ToString() + " (" + connector.To.output.ToString() + ") " + connector.To.weightedSum.ToString());
            }
        }
    }
}
