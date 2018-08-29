using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Front_Running
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()

        {

            InitializeComponent();

        }

        MainWindow registration = new MainWindow();

        Welcome_compliance welcomp = new Welcome_compliance();



        private void button1_Click(object sender, RoutedEventArgs e)

        {

            if (textBoxempid.Text.Length == 0)

            {

                errormessage.Text = "Enter employee id.";

                textBoxempid.Focus();

            }
            /*
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))

            {

                errormessage.Text = "Enter a valid email.";

                textBoxEmail.Select(0, textBoxEmail.Text.Length);

                textBoxEmail.Focus();

            }

            else

            {*/

            //    string email = textBoxEmail.Text;
            string empid = textBoxempid.Text;
                string password = passwordBox1.Password;

                SqlConnection con = new SqlConnection(@"Data Source=GRAD128-HP;Integrated Security = SSPI;Initial Catalog=Registration");

                con.Open();

                SqlCommand cmd = new SqlCommand("Select * from Registration where Empid='" + empid + "'  and pass_word='" + password + "'", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = cmd;

                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count > 0)

                {

                    string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();

                    welcomp.TextBlockName.Text = username;//Sending value from one form to another form.

                    welcomp.Show();

                    Close();

                }

                else

                {

                    errormessage.Text = "Sorry! Please enter existing empid/password.";

                }

                con.Close();

            }

        



        private void buttonRegister_Click(object sender, RoutedEventArgs e)

        {

            registration.Show();

            Close();

        }



    }

}
