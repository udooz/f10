namespace F10Core.Tests
{
    using System;
    using Xunit;

    using F10;
    using static F10.Core;

    public class OptionMapTests
    {
        [Fact]
        public void OptionWithSome_ApplyMap_ReturnMappedValue()
        {
            var baseValue = 2;
            var expected = Some(Math.Sqrt(baseValue));
            var actual = Some(2).Map((n) => Math.Sqrt(n));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OptionWithNone_ApplyMap_ReturnNone()
        {
            var expected = None;
            var converted = Some("a").Map(s => ToDouble(s));
            var actual = converted
                .Map((n) => Math.Sqrt(n.Value));
            Assert.Equal(expected, actual);
        }

        private Option<string> ToDouble(string value)
        {
            double result;
            if (double.TryParse(value, out result))
            {
                return Some(result);
            }
            else
            {
                return None;
            }
        }
    }
}
