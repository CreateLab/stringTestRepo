using System;
using System.Collections.Generic;
using TestJustifier;
using Xunit;

namespace TestCore
{
    public class UnitTest1
    {
        private IJustifier _justifier;
        
        public UnitTest1()
        {
            _justifier = new Justifier();
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test(string[] x, int l, string expectedStr)
        {
            Assert.Equal(expectedStr,_justifier.Justify(x,l));
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] {new []{"x"}, 3, "x  "};
            yield return new object[] {new []{"x"}, 4, "x   "};
            yield return new object[] {new []{"x","y"}, 3, "x y"};
            yield return new object[] {new []{"x","y"}, 4, "x  y"};
            yield return new object[] {new []{"x","y","z"}, 5, "x y z"};
            yield return new object[] {new []{"x","y","z"}, 6, "x  y z"};
            yield return new object[] {new []{"xxx","yy","z"}, 8, "xxx yy z"};
            yield return new object[] {new []{"xxx","yy","zz","k"}, 13, "xxx  yy  zz k"};
        }
    }
}