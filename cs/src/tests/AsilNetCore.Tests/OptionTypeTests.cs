﻿namespace AsilNetCore.Tests
{
    using System;
    using Xunit;

    using F10;
    using static F10.Core;

    
    public class OptionTypeTests
    {

        [Fact]
        public void IfEmployeeObjectIsNotNull_InitWithSome_ReturnSome()
        {
            var empName = "Tamil";
            var expected = new Employee(empName);
            var notNullEmployee = Some(new Employee(empName));
            Assert.Equal<Employee>(expected, notNullEmployee.Value);
        }

        [Fact]
        public void IfEmployeeObjectIsNULL_ReturnNone()
        {            
            Employee nullEmployee = null;
            var optEmployee = Some(nullEmployee);

            Assert.True(optEmployee.Equals(None));
        }

        [Fact]
        public void OnSuccessfulIntConversion_ReturnGracefulSome()
        {            
            Assert.Equal(5, ToInt("5").Value);
        }

        [Fact]
        public void OnFailedIntConversion_ReturnGracefulNone()
        {
            var actual = ToInt("Abc");
            Assert.Equal(None, actual);
        }

        [Fact]
        public void OnSomeMatch_ExecuteSomeFn()
        {
            var expected = 5;
            var intValue = ToInt("5");
            var actual = intValue.Match(Some: v => v, None: () => -1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnNoneMatch_ExecuteNoneFn()
        {
            var expected = -1;
            var intValue = ToInt("Abc");
            var actual = intValue.Match(Some: v => v, None: () => -1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EqualsWithOneNone_ShouldNotBeSame()
        {
            var employee1 = Some(new Employee("Tamil"));
            var employee2 = Some<Employee>(null);            
            Assert.NotEqual(employee1, employee2);
        }

        [Fact]
        public void EqualsWithBothNone_ShouldBeSame()
        {
            Option<Employee> employee1 = None;
            Option<Employee> employee2 = Some<Employee>(null);

            Assert.Equal(employee1, employee2);
        }

        [Fact]
        public void EqualsWithBothSome_ShouldBeSame()
        {
            var expected = true;
            var empName = "Tamil";
            Option<Employee> employee1 = Some(new Employee(empName));
            Option<Employee> employee2 = Some(new Employee(empName));
            var actual = employee1.Equals(employee2);

            Assert.Equal(expected, actual);
        }

        private Option<int> ToInt(string value)
        {
            int result;      
            if(int.TryParse(value, out result))
            {
                return Some(result);
            }else
            {
                return None;
            }
        }
    }
}
