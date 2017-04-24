using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Exampler
{
    // simple linear data
    public class SampleData1 : IData
    {
        public SampleData1(int numHiddenLayers, bool addBiasNode)
        {
            // input
            inputList.Add(new inputVector(new List<double> { 0, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 1, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 0, 1, 1 }));

            // output
            outputList.Add(new outputVector(new List<double> { 0 }));
            outputList.Add(new outputVector(new List<double> { 1 }));
            outputList.Add(new outputVector(new List<double> { 1 }));
            outputList.Add(new outputVector(new List<double> { 0 }));

            network = createNetwork(inputList[0].input.Count, outputList[0].output.Count, numHiddenLayers, addBiasNode);
        }

        public IDataTest Test(int whichTest)
        {
            IDataTest d = new IDataTest();
            if (whichTest==1)
            {
                d.inputList.AddMany(
                    new inputVector(new List<double> { 0, 0, 1 }),
                    new inputVector(new List<double> { 1, 1, 1 }),
                    new inputVector(new List<double> { 1, 0, 1 }),
                    new inputVector(new List<double> { 0, 1, 1 })
                );
                d.outputList.AddMany(
                    new outputVector(new List<double> { 0 }),
                    new outputVector(new List<double> { 1 }),
                    new outputVector(new List<double> { 1 }),
                    new outputVector(new List<double> { 0 })
                );
                return (d);
            }
            d.inputList.AddMany(
                new inputVector(new List<double> { 0, 0, 1 })
            );
            d.outputList.AddMany(
                new outputVector(new List<double> { 0 })
            );
            return (d);
        }
    }

    // simple nonlinear data
    public class SampleData2 : IData
    {
        public SampleData2(int numHiddenLayers, bool addBiasNode)
        {
            // input
            inputList.Add(new inputVector(new List<double> { 0, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 0, 1, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 0, 1 }));
            inputList.Add(new inputVector(new List<double> { 1, 1, 1 }));

            // output
            outputList.Add(new outputVector(new List<double> { 0 }));
            outputList.Add(new outputVector(new List<double> { 1 }));
            outputList.Add(new outputVector(new List<double> { 1 }));
            outputList.Add(new outputVector(new List<double> { 0 }));

            network = createNetwork(inputList[0].input.Count, outputList[0].output.Count, numHiddenLayers, addBiasNode);
        }

        public IDataTest Test(int whichTest)
        {
            IDataTest d = new IDataTest();
            if (whichTest == 1)
            {
                d.inputList.AddMany(
                    new inputVector(new List<double> { 0, 0, 1 }),
                    new inputVector(new List<double> { 0, 1, 1 }),
                    new inputVector(new List<double> { 1, 0, 1 }),
                    new inputVector(new List<double> { 1, 1, 1 })
                );
                d.outputList.AddMany(
                    new outputVector(new List<double> { 0 }),
                    new outputVector(new List<double> { 1 }),
                    new outputVector(new List<double> { 1 }),
                    new outputVector(new List<double> { 0 })
                );
                return (d);
            }
            d.inputList.AddMany(
                new inputVector(new List<double> { 0, 0, 1 })
            );
            d.outputList.AddMany(
                new outputVector(new List<double> { 0 })
            );
            return (d);
        }
    }
}
