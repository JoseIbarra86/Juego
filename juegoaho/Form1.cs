using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegoaho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string conexionString = null;

            conexionString = "Server=IBARRATI;Database=escuela;Trusted_Connection=True;";
            SqlConnection conexion;
            conexion = new SqlConnection(conexionString);
            SqlCommand comando;


            string query;

            query = "INSERT INTO registro VALUES ('" + textBox1.Text + "'," + textBox2.Text + ")";
            try
            {
               

                conexion.Open();
                comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();

                MessageBox.Show("Registro guardado");
                comando.Dispose();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Form2 formjugar = new Form2();
            formjugar.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 formjugar = new Form2();
            formjugar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string conexionString = null;

            conexionString = "Server=IBARRATI;Database=Escuela;Trusted_Connection=True;";
            SqlConnection conexion;
            conexion = new SqlConnection(conexionString);
            SqlCommand comando;
            SqlDataReader dataReader;
            string query;

            query = "SELECT * FROM registro";
            try
            {
                conexion.Open();
                comando = new SqlCommand(query, conexion);
                dataReader = comando.ExecuteReader();
                string data = "Nombre      |           No.ID\n";
                while (dataReader.Read())
                {
                    data += dataReader.GetValue(0) + "\t" + "\t" + dataReader.GetValue(1) + "\n";
                }


                MessageBox.Show(data);
                comando.Dispose();
                conexion.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    }

