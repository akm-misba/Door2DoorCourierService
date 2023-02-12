using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Training.Exceptions
{
    public class invalidPerameterException : Exception
    {
        public invalidPerameterException(string message)
            : base(message)
        {

        }
    }
}
