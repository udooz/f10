namespace F10Core.Tests
{
    using System;
    using F10;
    using static F10.Core;

    public class SyntheticEmployeeRepository
    {
        public Try<Employee, MyError> GetById(int empId)
        {
            if(empId >= 1000 && empId < 2000)
            {
                return new Employee("Tamil");
            }else
            {
                return new MyError(1010);
            }
        }

        public Try<Employee> GetByIdSimplified(int empId)
        {
            if (empId >= 1000 && empId < 2000)
            {
                return new Employee("Tamil");
            }
            else
            {
                return Error.As(1010);
            }
        }
    }
}
