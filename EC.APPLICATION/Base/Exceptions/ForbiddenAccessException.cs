using System;

namespace EC.APPLICATION.Base.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() { }
        public ForbiddenAccessException(string message) : base(message) { }
    }
}
