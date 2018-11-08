using EmployeeMaintance.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMaintance.DataAccess
{
    public static class EmployeeDA
    {
        static string filePath = Application.StartupPath + @"\employees.txt";

        //save eployee to file
        public static void SaveRecord(Employee ee)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(ee.EmployeeId + "," + ee.FirstName + "," + ee.LastName + "," + ee.PhoneNumber + "," + ee.Email);
            }
            MessageBox.Show("Save a new employee success!", "Message");
        }

        //check employee  id is unique or not
        public static bool IsDuplicatedId(int id)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null && line != "")
                {
                    string[] fields = line.Split(',');
                    if (Convert.ToInt32(fields[0]) == id)
                    {
                        sr.Close();
                        return true;
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            return false;
        }

        //search by employee id,only one can be found, but i return a list cause when show result is easy to deal with
        public static List<Employee> SearchRecord(int id)
        {
            List<Employee> eeList = new List<Employee>();
            if (File.Exists(filePath))
            {
                Employee ee = null;
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (id == Convert.ToInt32(fields[0]))
                    {
                        ee = new Employee();
                        ee.EmployeeId = Convert.ToInt32(fields[0]);
                        ee.FirstName = fields[1];
                        ee.LastName = fields[2];
                        ee.PhoneNumber = fields[3];
                        ee.Email = fields[4];
                        eeList.Add(ee);
                        break;                     
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                return eeList;
            }
            return null;
        }

        //search by firstname or lastname, it can be found more than one employee
        public static List<Employee> SearchRecord(string name, bool bFirstName = true)
        {
            name = name.ToUpper();
            List<Employee> eeList = new List<Employee>();
            if (File.Exists(filePath))
            {
                Employee ee = null;
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if ((bFirstName && fields[1].ToUpper().CompareTo(name) == 0) 
                        || (!bFirstName && fields[2].ToUpper().CompareTo(name) == 0))
                    {
                        ee = new Employee();
                        ee.EmployeeId = Convert.ToInt32(fields[0]);
                        ee.FirstName = fields[1];
                        ee.LastName = fields[2];
                        ee.PhoneNumber = fields[3];
                        ee.Email = fields[4];
                        eeList.Add(ee);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                return eeList;
            }
            return null;
        }

        //read all employee form file
        public static List<Employee> ReadAllRecord()
        {
            List<Employee> eeList = new List<Employee>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] fields = line.Split(',');
                    Employee ee = new Employee();
                    ee.EmployeeId = Convert.ToInt32(fields[0]);
                    ee.FirstName = fields[1];
                    ee.LastName = fields[2];
                    ee.PhoneNumber = fields[3];
                    ee.Email = fields[4];
                    eeList.Add(ee);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            if (eeList.Count() <= 0)
                MessageBox.Show("Employee not found!", "Error");
            return eeList;
        }
    }
}
