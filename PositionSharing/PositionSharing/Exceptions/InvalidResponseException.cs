using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharing.Exceptions
{
    public class InvalidResponseException : Exception
    {

        public InvalidResponseException()
        {
        }

        public InvalidResponseException(string message)
            : base(message)
        {
        }
        public InvalidResponseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
