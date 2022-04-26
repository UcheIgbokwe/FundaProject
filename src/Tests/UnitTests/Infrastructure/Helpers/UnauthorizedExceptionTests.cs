using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Helpers;
using Xunit;

namespace Tests.UnitTests.Infrastructure.Helpers
{
    public class UnauthorizedExceptionTests
    {
        [Fact]
        public void SomeMethodShouldThrowUnauthorizedException()
        {
            static void Act() => throw new UnauthorizedException();

            var ex = Record.Exception(Act);

            Assert.NotNull(ex);
            Assert.IsType<UnauthorizedException>(ex);
        }
    }
}