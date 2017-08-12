using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VRANDER_01
{
    public partial class Signup : Form
    {
        private static string conString = "Server=Lenovo-PC\\SQLEXPRESS; Database=InClassExercise; User=PrimeUser; Password=12345";
        private SqlConnection connection = new SqlConnection(conString);

        SqlCommand cmd;
        //SqlDataAdapter adapter;
        DataTable table = new DataTable();
        //Signup signup = new Signup();
        public Signup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string firstname = tbFirstname.Text;
            string lastname = tbLastname.Text;
            string street = tbAddress.Text;
            string city = tbCity.Text;
            string province = tbProvince.Text;
            string postal = tbPostal.Text;
            string country = cbCountry.Text;
            string email = tbEmail.Text;
            string phone = tbPhone.Text;

            if (username == "" || password == "" || firstname == "" || lastname == "" || street == "" || city == "" || province == "" || postal == "" || country == "" || email == "" || phone == "")
            {
                string msg = "Please fill in all fields.";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cmd = new SqlCommand("INSERT UserInfo (FirstName, LastName, Username, Password, Street, City, Province, PostalCode, Country, Email, Phone) VALUES ('"+firstname+"', '"+lastname+"', '"+username+"', '"+password+"', '"+street+"', '"+city+"', '"+province+"', '"+postal+"','"+country+"', '"+email+"', '"+phone+"')",connection);
            cmd.Connection.Open();
          int i =  cmd.ExecuteNonQuery();
          connection.Close();

          if (i != 0)
          {
              MessageBox.Show("You've Succesfully Registered!");
            //  signup.Close();
          }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
