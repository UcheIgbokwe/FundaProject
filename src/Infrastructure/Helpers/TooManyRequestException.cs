using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using src.Infrastructure.Helpers;

namespace Infrastructure.Helpers
{
    public class TooManyRequestException : Exception
    {
        public TooManyRequestException() : base() {}

        public TooManyRequestException(string message) : base(message)
        {
            throw new HttpStatusException((int)HttpStatusCode.TooManyRequests, message);
        }

        public TooManyRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}