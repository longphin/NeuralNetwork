using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Exampler
{
    public class SampleData1 : IData
    {
        public SampleData1()
        {
            // input
            inputList.Add(new inputVector(new List<double> { 0, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 0, 1, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 1, 1 }));

            // output
            outputList.Add(new outputVector(new List<double> { 0, 1 }));
            outputList.Add(new outputVector(new List<double> { 1, 1 }));
            outputList.Add(new outputVector(new List<double> { 1, 0 }));
            outputList.Add(new outputVector(new List<double> { 1, 1 }));
        }
    }
}
