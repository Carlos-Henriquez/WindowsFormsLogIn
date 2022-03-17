using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsLogIn
{
    public class DataLayer
    {
        public SqlConnection connection = new SqlConnection("Integrated Security=SSPi;Persist Security Info=False;Initial Catalog=BD_Balances;Data Source=CARLITOS-PC");

        public void ValidateUserCredentials(UserCredentials userCredentials)
        {
            SqlCommand command = new SqlCommand("Select * From Users Where Username='" + userCredentials.Username + "' AND Password='" + userCredentials.Password + "'", connection);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                connection.Open();
                SqlParameter username = new SqlParameter("@Username", userCredentials.Username);
                SqlParameter password = new SqlParameter("@Password", userCredentials.Password);

                if (reader.Read())
                {
                    MessageBox.Show("Inicio de sesion exitoso.");
                }
                else
                    MessageBox.Show("Usuario o contraseña invalidos.");

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
