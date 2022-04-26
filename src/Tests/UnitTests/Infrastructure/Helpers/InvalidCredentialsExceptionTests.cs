using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Infrastructure.Helpers;
using Xunit;

namespace Tests.UnitTests.Infrastructure.Helpers
{
    public class InvalidCredentialsExceptionTests
    {
        [Fact]
        public void SomeMethodShouldThrowAppInvalidCredentialsException()
        {
            static void Act() => throw new InvalidCredentialsException();

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<InvalidCredentialsException>(ex);
        }
    }
}