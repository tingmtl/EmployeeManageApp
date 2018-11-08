using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMaintance.Validation
{
    public class Validator
    {
        public static bool IsValidId(string input, int size)
        {
            //string patten = "@" + String.Format(@"^\d{{0}}$", size);
            //Regex reg = new Regex(patten);
            if (!Regex.IsMatch(input, @"^\d{" + size + "}$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidId(TextBox txtControl, int size)
        {
            if (!IsValidId(txtControl.Text.Trim(), size))
            {
                MessageBox.Show(txtControl.Tag.ToString(), "Error");
                txtControl.Text = "";
                txtControl.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidPhone(TextBox txtControl)
        {

            if (!Regex.IsMatch(txtControl.Text, @"^\(?\d{3}\)?-?\d{3}-?\d{4}$"))
            {
                MessageBox.Show(txtControl.Tag.ToString(), "Error");
                txtControl.Text = "";
                txtControl.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidEmail(TextBox txtControl)
        {
            //if (!Regex.IsMatch(txtControl.Text, @"^\w@\w.com$"))
            //{
            //    MessageBox.Show(txtControl.Tag.ToString(), "Error");
            //    txtControl.Text = "";
            //    txtControl.Focus();
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;
        }


        public static bool IsValidName(string input)
        {
            //for(var i = 0; i < input.Length; i++)
            //{
            //    if(!(Char.IsLetter(input[i]) || Char.IsWhiteSpace(input[i])))
            //    {
            //        return false;
            //    }
            //}

            //return true;
            //@"^[ A-Za-z/s]{32}$" 位字母，包含空格
            if (!Regex.IsMatch(input, @"^[A-Za-z/s]*$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidName(TextBox txtControl)
        {
            string input = txtControl.Text.Trim();
            //@"^[ A-Za-z/s]{32}$" 位字母，包含空格
            if (!IsValidName(txtControl.Text.Trim()))
            {
                MessageBox.Show(txtControl.Tag.ToString(), "Error");
                txtControl.Text = "";
                txtControl.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
