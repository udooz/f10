namespace F10Core.Tests
{
    using System;
    using Xunit;

    using F10;
    using static F10.Core;

    public class EnumerableMapTests
    {
        [Fact]
        public void Enumerables_Map_ShourProcessEachElement()
        {
            var cities = new[] { "IN_Chennai", "Dallas", "IN_Delhi" };
            var expected = new[] { true, false, true };
            Func<string, bool> isIndia = (c) =>
            {
                if (c.StartsWith("IN_")) return true;
                else return false;
            };
            var actual = cities.Map(c => isIndia(c));
            Assert.Equal(expected, actual);
        }
    }
}
