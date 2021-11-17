using System;
using System.Collections.Generic;
using System.Text;

namespace EC.APPLICATION.Base.Exceptions
{
    public class ECException : Exception
    {
        public ECException()
        {
        }

        public ECException(string message)
            : base(message)
        {
        }

        public ECException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
