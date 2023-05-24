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

namespace ProyectoCompilador
{
    public partial class AgregarUsuario : Form
    {
        string server = "Data Source = localhost\\SQLEXPRESS; Initial Catalog= ProyectoSistemas; Integrated Security = True ";
        SqlConnection conectar = new SqlConnection();
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {

        }
        public static string EncriptarContra(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string contrasena = txtContrasena.Text;
            string hashedpassword = EncriptarContra(contrasena);
            string query = "insert into Usuarios(usuario,contrasena,nombre,correo,telefono) values (@usuario,@contrasena,@nombre,@correo,@telefono)";
            conectar.ConnectionString = server;
            conectar.Open();
            SqlCommand cmd = new SqlCommand(query, conectar);
            cmd.Parameters.AddWithValue("@usuario", txtUser.Text);
            cmd.Parameters.AddWithValue("contrasena", hashedpassword);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);

            try
            {
                MessageBox.Show("Usuario Agregado");
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            conectar.Close();
        }
    }
}
