using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Connector
    {
        public Node To { get; set; } = new Node();
        public float weight { get; set; }

        public Connector(ref Node To, float weight)
        {
            this.To = To;
            this.weight = weight;
        }
    }
}
