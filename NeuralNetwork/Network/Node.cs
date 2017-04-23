using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Node
    {
        public double weightedSum { get; set; }
        public double output { get; set; }
        public List<Connector> forwardConnectors { get; set; } = new List<Connector>();
        public List<Connector> backwardConnectors { get; set; } = new List<Connector>();
        public string name { get; set; }
        public double error { get; set; }

        public Node()
        {
            this.name = "undef";
        }

        public Node(string name)
        {
            this.name = name;
        }

        public void AddForwardConnector(Connector newConnector)
        {
            forwardConnectors.Add(newConnector);
        }
        public void AddBackwardConnector(Connector newConnector)
        {
            backwardConnectors.Add(newConnector);
        }
    }
}
