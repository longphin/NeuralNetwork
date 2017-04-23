using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Layer
    {
        public List<Node> nodes { get; set; } = new List<Node>();

        public Layer()
        {
        }

        public void AddNode(Node node)
        {
            nodes.Add(node);            
        }
    }
}
