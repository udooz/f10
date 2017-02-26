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
            var actual = Some(2).Map(n => Math.Sqrt(n));
            Assert.Equal(expected, actual);
        }

        //[Fact(Skip = "Suitable solution not implemented on Option")]
        //public void OptionWithNone_ApplyMap_ReturnNone()
        //{
        //    var expected = None;
        //    var actual = "s".ParseInt32().FlatMap(n => Math.Sqrt(n));
        //}


    }
}
