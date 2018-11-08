using EmployeeMaintance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaintance.Business
{
    public class Employee : Person
    {
        private int employeeId;
        private string phoneNumber;
        private string email;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }

        public Employee(string fn, string ln, int employeeId, string phoneNumber, string email):base(fn,ln)
        {
            this.employeeId = employeeId;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public Employee():base()
        {
            employeeId = 0;
            phoneNumber = "";
            email = "";
        }

        //save employee to txt file
        public static void SaveRecord(Employee ee)
        {
            EmployeeDA.SaveRecord(ee);
        }

        //check employee id is unique or not
        public static bool IsDuplicatedId(int id)
        {
            return EmployeeDA.IsDuplicatedId(id);
        }

        //format phone number
        public static string FormatPhoneNumber(string phoneNumber)
        {
            string newNumber = string.Format("({0}){1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6));
            return newNumber;
        }

        //search employee by employee id
        public static List<Employee> SearchRecord(int id)
        {
            return EmployeeDA.SearchRecord(id);
        }

        //search employee by first name or last name
        public static List<Employee> SearchRecord(string name, bool bFirstName = true)
        {
            return EmployeeDA.SearchRecord(name, bFirstName);
        }

        //read all employee from txt file
        public static List<Employee> ReadAllRecord()
        {
            return EmployeeDA.ReadAllRecord();
        }
    }
}
