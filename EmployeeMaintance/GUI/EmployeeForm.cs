using EmployeeMaintance.Business;
using EmployeeMaintance.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMaintance
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        //create a new employee
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validator.IsValidId(txtEmployeeId, 4))
            {
                return;
            }
            int id = Convert.ToInt32(txtEmployeeId.Text.Trim());
            if(Employee.IsDuplicatedId(id))
            {
                MessageBox.Show("Employee id should be unique!", "Error");
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }
            if(!Validator.IsValidName(txtFirstName))
            {
                return;
            }

            if (!Validator.IsValidName(txtLastName))
            {
                return;
            }

            if (!Validator.IsValidPhone(txtPhoneNumber))
            {
                return;
            }

            if (!Validator.IsValidEmail(txtEmail))
            {
                return;
            }
            Employee aEmployee = new Employee();
            aEmployee.EmployeeId = id;
            aEmployee.FirstName = txtFirstName.Text.Trim();
            aEmployee.LastName = txtLastName.Text.Trim();
            aEmployee.PhoneNumber = txtPhoneNumber.Text.Trim();
            aEmployee.Email = txtEmail.Text.Trim();
            Employee.SaveRecord(aEmployee);
        }

        //search employee 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Employee> eeList = null;
            int index = combType.SelectedIndex;
            if(index == 0)
            {
                txtSearchKey.Tag = "Employee Id should be 4-digits number!";
                if (!Validator.IsValidId(txtSearchKey, 4))
                {
                    return;
                }
                eeList = Employee.SearchRecord(Convert.ToInt32(txtSearchKey.Text.Trim()));
            }
            else if (index == 1)
            {
                txtSearchKey.Tag = "First Name should be less than 32-digits alphabet! ";
                if (!Validator.IsValidName(txtSearchKey))
                {
                    return;
                }
                eeList = Employee.SearchRecord(txtSearchKey.Text.Trim());
            }
            else if (index == 2)
            {
                txtSearchKey.Tag = "Last Name should be less than 32-digits alphabet! ";
                if (!Validator.IsValidName(txtSearchKey))
                {
                    return;
                }
                eeList = Employee.SearchRecord(txtSearchKey.Text.Trim(), false);
            }
            else
            {
                ;
            }

            if(eeList == null || eeList.Count() <= 0)
            {
                MessageBox.Show("Can not find this employee!", "Message");
                return;
            }

            DisplayListView(eeList);
        }

        private void btnDislayAll_Click(object sender, EventArgs e)
        {
            List<Employee> eeList = null;
            eeList = Employee.ReadAllRecord();
            DisplayListView(eeList);
        }

        //show employee to list view
        private void DisplayListView(List<Employee> list)
        {
            if (list == null || list.Count() <= 0)
            {
                //MessageBox.Show("Can not find this employee!", "Message");
                return;
            }

            eeListView.Items.Clear();
            foreach (var ee in list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ee.EmployeeId.ToString();
                item.SubItems.Add(ee.FirstName);
                item.SubItems.Add(ee.LastName);
                item.SubItems.Add(ee.PhoneNumber);
                item.SubItems.Add(ee.Email);
                eeListView.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit the application?", "Exit?", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            combType.SelectedIndex = 0;
        }
    }
}
