using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork;

namespace Exampler
{
    public class Sigmoid : IActivationFunction
    {
        public double activationFunction(double x)
        {
            return (1 / (1 + Math.Pow(Math.E, -x)));
        }

        public double activationFunction_Prime(double x)
        {
            return (Math.Pow(Math.E, x)/Math.Pow(Math.Pow(Math.E, x) + 1, 2));
        }
    }

    public class HyperbolicTangent : IActivationFunction
    {
        public double activationFunction(double x)
        {
            return ((1 - Math.Pow(Math.E, -2*x))/(1+Math.Pow(Math.E, 2*x)));
        }

        public double activationFunction_Prime(double x)
        {
            return (Math.Pow(Math.E, -2 * x) * (4 * Math.Pow(Math.E, 2 * x) - 2 * Math.Pow(Math.E, 4 * x) + 2) / Math.Pow(Math.Pow(Math.E, 2 * x) + 1, 2));
        }
    }

    public class ArcTan: IActivationFunction
    {
        public double activationFunction(double x)
        {
            return (Math.Atan(x));
        }
        public double activationFunction_Prime(double x)
        {
            return (1/(Math.Pow(x, 2) + 1));
        }
    }

    public class Sinusoidal: IActivationFunction
    {
        public double activationFunction(double x)
        {
            return (Math.Sin(x));
        }
        public double activationFunction_Prime(double x)
        {
            return (Math.Cos(x));
        }
    }

    public class Sinc: IActivationFunction
    {
        public double activationFunction(double x)
        {
            if (x == 0) return (1);
            return (Math.Sin(x) / x);
        }
        public double activationFunction_Prime(double x)
        {
            if (x == 0) return (1);
            return (Math.Cos(x) / x - Math.Sin(x) / Math.Pow(x, 2));
        }
    }

    public class Guassian: IActivationFunction
    {
        public double activationFunction(double x)
        {
            return (Math.Pow(Math.E, -Math.Pow(x, 2)));
        }
        public double activationFunction_Prime(double x)
        {
            return (-2 * x * Math.Pow(Math.E, -Math.Pow(x, 2)));
        }
    }
}
