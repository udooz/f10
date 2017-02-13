namespace F10Core.Tests
{
    using System;
    using Xunit;

    using F10;
    using static F10.Core;

    public class TryTypeTests
    {
        [Fact]
        public void TryEmpRepoWithEmpData_ReturnSuccess()
        {
            var expected = Try<Employee, MyError>(new Employee("Tamil"));
            var repo = new SyntheticEmployeeRepository();
            var actual = repo.GetById(1050);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryEmpRepoWithNoEmpData_ReturnFailed()
        {
            var expected = new MyError(1010);
            var repo = new SyntheticEmployeeRepository();
            var actual = repo.GetById(9999);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnSuccessMatch_ExecuteSuccessFn()
        {
            var expected = "OK(Tamil)";
            var repo = new SyntheticEmployeeRepository();
            var actual = 
                repo
                .GetById(1010)
                .Match(Success: (v) => $"OK({v.Name})", 
                       Failed: (f) => "No()");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnFailedMatch_ExecuteFailedFn()
        {
            var expected = "No()";
            var repo = new SyntheticEmployeeRepository();
            var actual =
                repo
                .GetById(8080)
                .Match(Success: (v) => $"OK({v.Name})",
                       Failed: (f) => "No()");
            Assert.Equal(expected, actual);
        }

        [Fact]        
        public void TryErrorSuccessMatch_ReturnSuccess()
        {
            var expected = Try(new Employee("Tamil"));
            var repo = new SyntheticEmployeeRepository();
            var actual = repo.GetByIdSimplified(1050);
            var result = expected.Equals(actual);
            Assert.True(result);
        }

        [Fact]
        public void TryErrorFailedMatch_ReturnFailed()
        {
            var expected = Error.As(1010);
            var repo = new SyntheticEmployeeRepository();
            var actual = repo.GetByIdSimplified(7070);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnFailedMatch_TryError_ExecuteFailedFn()
        {
            var expected = "No()";
            var repo = new SyntheticEmployeeRepository();
            var actual =
                repo
                .GetByIdSimplified(8080)
                .Match(Success: (v) => $"OK({v.Name})",
                       Failed: (f) => "No()");
            Assert.Equal(expected, actual);
        }

    }
}
