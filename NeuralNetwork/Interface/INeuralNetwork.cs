﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public abstract class INeuralNetwork
    {
        public Network network { get; set; } = new Network();
        public IActivationFunction activationFunc { get; set; }
    }
}
