using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class inputVector
    {
        public List<double> input { get; set; } = new List<double>();
        public inputVector(List<double> inp)
        {
            input = inp;
        }
        public void AddElement(List<double> inp)
        {
            input.AddRange(inp);
        }
    }

    public class outputVector
    {
        public List<double> output { get; set; } = new List<double>();
        public outputVector(List<double> outp)
        {
            output = outp;
        }
        public void AddElement(List<double> outp)
        {
            output.AddRange(outp);
        }
    }

    public abstract class IData
    {
        public List<inputVector> inputList = new List<inputVector>();
        public List<outputVector> outputList = new List<outputVector>();

        public int GetSize()
        {
            return (inputList.Count);
        }
    }
}
