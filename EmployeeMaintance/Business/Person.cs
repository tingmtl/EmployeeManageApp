using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaintance.Business
{
    public class Person
    {
        private string firstName;
        private string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Person(string fn, string ln)
        {
            firstName = fn;
            lastName = ln;
        }
        public Person()
        {
        }
    }
}
