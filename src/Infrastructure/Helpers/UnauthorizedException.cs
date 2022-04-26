using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using src.Infrastructure.Helpers;

namespace Infrastructure.Helpers
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base() {}

        public UnauthorizedException(string message) : base(message)
        {
            throw new HttpStatusException((int)HttpStatusCode.Unauthorized, message);
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}