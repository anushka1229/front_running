    using System.Collections.Generic;

    using System.Linq;

    using System.Text;

    using System.Windows;

    using System.Windows.Controls;

    using System.Windows.Data;

    using System.Windows.Documents;

    using System.Windows.Input;

    using System.Windows.Media;

    using System.Windows.Media.Imaging;

    using System.Windows.Shapes;

    using System.Data;

    using System.Data.SqlClient;

    using System.Text.RegularExpressions;



    namespace Front_Running

    {

    /// <summary>

    /// Interaction logic for Registration.xaml

    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




            private void Login_Click(object sender, RoutedEventArgs e)

            {

                Login login = new Login();

                login.Show();

                Close();

            }



            private void button2_Click(object sender, RoutedEventArgs e)

            {

                Reset();

            }



            public void Reset()

            {
                textBlockempId.Text = "";

                textBoxFirstName.Text = "";

                textBoxLastName.Text = "";

          

                textBoxAddress.Text = "";

                passwordBox1.Password = "";

                passwordBoxConfirm.Password = "";

            }

            private void button3_Click(object sender, RoutedEventArgs e)

            {

                Close();

            }



            private void Submit_Click(object sender, RoutedEventArgs e)

            {

                if (textBoxempId.Text.Length == 0)

                {

                    errormessage.Text = "Enter an employee id.";

                    textBoxempId.Focus();

                }

              /*  else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))

                {

                    errormessage.Text = "Enter a valid email.";

                    textBoxEmail.Select(0, textBoxEmail.Text.Length);

                    textBoxEmail.Focus();

                }

                else

                {*/
                    
                    string firstname = textBoxFirstName.Text;

                    string lastname = textBoxLastName.Text;

                    string empId = textBoxempId.Text;

                    string password = passwordBox1.Password;

                    if (passwordBox1.Password.Length == 0)

                    {

                        errormessage.Text = "Enter password.";

                        passwordBox1.Focus();

                    }

                    else if (passwordBoxConfirm.Password.Length == 0)

                    {

                        errormessage.Text = "Enter Confirm password.";

                        passwordBoxConfirm.Focus();

                    }

                    else if (passwordBox1.Password != passwordBoxConfirm.Password)

                    {

                        errormessage.Text = "Confirm password must be same as password.";

                        passwordBoxConfirm.Focus();

                    }

                    else

                    {

                        errormessage.Text = "";

                        string address = textBoxAddress.Text;

                        SqlConnection con = new SqlConnection(@"Data Source=GRAD128-HP;Integrated Security = SSPI;Initial Catalog=Registration");

                        con.Open();

                       SqlCommand cmd = new SqlCommand($"Insert into Registration (empid, FirstName, LastName, Pass_word, address) values('{empId}','{firstname}','{lastname}','{password}','{address}')", con);

                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();

                        con.Close();

                        errormessage.Text = "You have Registered successfully.";

                        Reset();

                    }

                }

            }

        }

    
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
