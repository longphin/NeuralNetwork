using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Connector
    {
        public Node From { get; set; } = new Node();
        public Node To { get; set; } = new Node();
        public double weight { get; set; }

        public Connector(Node From, Node To, double weight)
        {
            this.From = From;
            this.To = To;
            this.weight = weight;
        }
    }
}
