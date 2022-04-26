using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Helpers;
using Xunit;

namespace Tests.UnitTests.Infrastructure.Helpers
{
    public class TooManyRequestExceptionTests
    {
        [Fact]
        public void SomeMethodShouldThrowTooManyRequestException()
        {
            static void Act() => throw new TooManyRequestException();

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<TooManyRequestException>(ex);
        }
    }
}