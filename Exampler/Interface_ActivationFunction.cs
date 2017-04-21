using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exampler
{
    public interface Interface_ActivationFunction
    {
        double activationFunction(double val);
        double activationFunction_Prime(double val);
    }
}
