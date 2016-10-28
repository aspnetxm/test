using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Galaxy.UnitTest
{
    public class CommonTest
    {
        [Fact]
        public void AAA()
        {
            Assert.Equal(10, Galaxy.Code.Common.RndNum(10).Length);
        }

    }
}
