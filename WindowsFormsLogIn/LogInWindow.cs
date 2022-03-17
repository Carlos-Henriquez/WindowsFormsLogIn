using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //borrar luego 

namespace WindowsFormsLogIn
{
    public partial class LogInWindow : Form
    {
        private DataLayer _datalayer;
        private UserCredentials _userCredentials;

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnLogIn_Click(object sender, EventArgs e)
        {
            UserCredentials userCredentials = new UserCredentials();
            userCredentials.Username = txtUsername.Text;
            userCredentials.Password = txtPassword.Text;

            SqlConnection connection = new SqlConnection("Integrated Security=SSPi;Persist Security Info=False;Initial Catalog=BD_Balances;Data Source=CARLITOS-PC");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Users Where Username='" + userCredentials.Username + "' AND Password='" + userCredentials.Password + "'", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Inicio de sesion exitoso.");
            }
            else
                MessageBox.Show("Usuario o contraseña invalidos.");

        }
    }
}
