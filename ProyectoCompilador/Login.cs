using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ProyectoCompilador
{
    public partial class Login : Form
    {
        string usuario;
        string server = "Data Source = localhost\\SQLEXPRESS; Initial Catalog= ProyectoSistemas; Integrated Security = True ";
        SqlConnection conectar = new SqlConnection();

        public Login()
        {
            InitializeComponent();
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir el arreglo de bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
      

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AgregarUsuario agregarUsuario = new AgregarUsuario();
            agregarUsuario.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string password = txtcontrasena.Text;
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "Select contrasena from Usuarios where usuario=@usuario";
            SqlCommand cmd = new SqlCommand(query, conectar);
            cmd.Parameters.AddWithValue("@usuario", txtusuario.Text);
            object resultado = cmd.ExecuteScalar();         
            string hashedpassword = HashPassword(password);
            bool soniguales = string.Equals(resultado, hashedpassword);
            if (soniguales)
            {
                usuario = txtusuario.Text;
               
                Compilador compilador = new Compilador(usuario);
                compilador.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos");
            }
            conectar.Close();
        }
    }
}
