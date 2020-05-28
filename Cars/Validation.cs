using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cars
{
    class Validation
    {
        public static string if_word(string var)
        {
            if (!Regex.IsMatch(var, @"^[a-z]*$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Error: ", "Wrong text", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //new ItemForm().Show();
            }
            return var;
        }
        public static double if_price(string var)
        {
            if (!double.TryParse(var, out double result) || double.Parse(var) <= 0)
            {
                MessageBox.Show("Error: ", "Wrong price", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //new ItemForm().Show();
                //return 0;
            }
            return result;
        }
        public static int if_year(string var)
        {
            if (!int.TryParse(var, out int result) || int.Parse(var) <=1800 || int.Parse(var) >= DateTime.Today.Year)
            {
                MessageBox.Show("Error: ", "Wrong lenght", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //new ItemForm().Show();
            }
            return result;
        }
    }
}
