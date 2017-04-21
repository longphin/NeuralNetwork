using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Node
    {
        public float val { get; set; }
        public List<Connector> connectors { get; set; } = new List<Connector>();
        public string name { get; set; }

        public Node()
        {
            this.name = "undef";
        }

        public Node(string name)
        {
            this.name = name;
        }

        public void AddConnector(ref Connector newConnector)
        {
            connectors.Add(newConnector);
        }
        /*
        public void AddConnector(ref List<Connector> newConnectors)
        {
            connectors.AddRange(newConnectors);
        }
        */
    }
}
