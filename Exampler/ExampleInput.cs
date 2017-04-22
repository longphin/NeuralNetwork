using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exampler
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

    public abstract class Data
    {
        public List<inputVector> inputList = new List<inputVector>();
        public List<outputVector> outputList = new List<outputVector>();
    }

    public class SampleData1 : Data
    {
        public SampleData1()
        {
            // input
            inputList.Add(new inputVector(new List<double> { 0, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 0, 1, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 1, 1 }));

            // output
            outputList.Add(new outputVector(new List<double> { 0, 1, 1, 0 }));
        }
    }
}
