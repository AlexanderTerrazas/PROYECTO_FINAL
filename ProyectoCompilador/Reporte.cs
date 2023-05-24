using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProyectoCompilador
{
    public partial class Reporte : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog= ProyectoSistemas; Integrated Security = True ");
        public Reporte()
        {
            InitializeComponent();
        }

        private void quitarFiltro()
        {
            if (!CbFecha.Checked && !CbUsuario.Checked && !CbLenguaje.Checked)
            {
                string consulta = "select us.usuario 'Usuario', le.nombre 'Lenguaje', re.fecha_hora 'Fecha y Hora', re.nombre_archivo 'Archivo Salida' from Registro re INNER JOIN Usuarios us on re.idusuario = us.idusuario\tINNER JOIN Lenguajes le\ton re.idlenguaje = le.idlenguaje";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReport.DataSource = dt;
            }
            
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            quitarFiltro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos de texto (*.txt)|*.txt";
                saveDialog.Title = "Guardar archivo de texto";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            // Escribir encabezados de columnas
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                writer.Write(dgvReport.Columns[i].HeaderText);
                                if (i < dgvReport.Columns.Count - 1)
                                    writer.Write("\t"); // Tabulador como separador de columnas
                            }
                            writer.WriteLine();

                            // Escribir datos de celdas
                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    writer.Write(row.Cells[i].Value);
                                    if (i < dgvReport.Columns.Count - 1)
                                        writer.Write("\t"); // Tabulador como separador de columnas
                                }
                                writer.WriteLine();
                            }

                            writer.Close();
                        }

                        MessageBox.Show("Los datos se han exportado correctamente.", "Exportar a TXT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se produjo un error al exportar los datos: " + ex.Message, "Exportar a TXT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar a TXT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
    }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivo CSV (*.csv)|*.csv";
                saveDialog.Title = "Guardar archivo CSV";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                        {
                            // Escribir encabezados de columnas
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                writer.Write(dgvReport.Columns[i].HeaderText);
                                if (i < dgvReport.Columns.Count - 1)
                                    writer.Write(","); // Coma como separador de columnas
                            }
                            writer.WriteLine();

                            // Escribir datos de celdas
                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    if (row.Cells[i].Value != null)
                                    {
                                        string value = row.Cells[i].Value.ToString();
                                        // Escapar las comas dentro del valor
                                        value = value.Replace(",", "\\,");
                                        writer.Write(value);
                                    }

                                    if (i < dgvReport.Columns.Count - 1)
                                        writer.Write(","); // Coma como separador de columnas
                                }
                                writer.WriteLine();
                            }

                            writer.Close();
                        }

                        MessageBox.Show("Los datos se han exportado correctamente.", "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se produjo un error al exportar los datos: " + ex.Message, "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXLSX_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
            saveDialog.Title = "Guardar archivo CSV";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                ExportToExcel(dgvReport, saveDialog.FileName);
        }


        public void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            // Crear una instancia de Excel
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = workbook.ActiveSheet;

            try
            {
                // Encabezados de columna
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    sheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }

                // Datos de las filas
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        sheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // Guardar el archivo Excel
                workbook.SaveAs(filePath);
                workbook.Close();
                excel.Quit();

                MessageBox.Show("Exportación exitosa");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
            finally
            {
                ReleaseObject(sheet);
                ReleaseObject(workbook);
                ReleaseObject(excel);
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error al liberar el objeto: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        public DataTable getFiltro(bool usuario, bool lenguaje, bool fecha, string tUsuario, string tLenguaje, DateTime inicio, DateTime final)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select us.usuario 'Usuario', le.nombre 'Lenguaje', re.fecha_hora 'Fecha y Hora', re.nombre_archivo 'Archivo Salida' from Registro re INNER JOIN Usuarios us on re.idusuario = us.idusuario\tINNER JOIN Lenguajes le\ton re.idlenguaje = le.idlenguaje where";

            int n = 0;

            if (usuario)
            {
                if (n != 0)
                {
                    cmd.CommandText += " and us.nombre = @u";
                }
                else
                {
                    n++;
                    cmd.CommandText += " us.nombre = @u";
                }
                cmd.Parameters.AddWithValue("@u", tUsuario);
            }
            if (lenguaje)
            {
                if (n != 0)
                {
                    cmd.CommandText += " and le.nombre = @l";
                }
                else
                {
                    n++;
                    cmd.CommandText += " le.nombre = @u";
                }
                cmd.Parameters.AddWithValue("@l", tLenguaje);
            }
            if (fecha)
            {
                if (n != 0)
                {
                    cmd.CommandText += " and re.fecha_hora between @fi and @ff";
                }
                else
                {
                    n++;
                    cmd.CommandText += " re.fecha_hora between @fi and @ff";
                }
                cmd.Parameters.AddWithValue("@fi", inicio);
                cmd.Parameters.AddWithValue("@ff", final);
            }
            DataTable resultados = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            resultados.Load(reader);
            cmd.Dispose();
            reader.Close();
            conexion.Close();
            return resultados;
        }

        private void CbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            quitarFiltro();
        }

        private void CbLenguaje_CheckedChanged(object sender, EventArgs e)
        {
            quitarFiltro();
        }

        private void CbFecha_CheckedChanged(object sender, EventArgs e)
        {
            quitarFiltro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = getFiltro(CbUsuario.Checked, CbLenguaje.Checked, CbFecha.Checked,TxtUsuario.Text,TxtLenguaje.Text,DtpInicio.Value,DtpFin.Value);
        }
    }
}
