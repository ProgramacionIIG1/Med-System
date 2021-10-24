using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Parcial
{
    public partial class Form2 : Form

    {
        public string cadenaconxion = "Database=medsystem;Data Source=localhost;User Id=Erick;Password=1452";
        public int usMod;

        public Form2()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.ShowDialog();



        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.ShowDialog();
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente();
            paciente.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtTelefono.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            txtDireccion.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;

            try
            {
                string consulta = "select Nombre,Apellido,FechaNacimiento,Dui,Telefono,Sexo,Estado,Direccion from pacientes ";

                MySqlConnection con = new MySqlConnection(cadenaconxion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, con);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "medsystem");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "medsystem";
            }

            catch
            {

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cadenaconxion);
            conn.Open();
            if (txtNombre.Text == "" & txtApellido.Text == "" & txtTelefono.Text == "" & txtDireccion.Text == "")
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                String update = " ELETE FROM `pacientes` WHERE idPacientes ='" + usMod + "'";
                MySqlCommand sqlCommand = new MySqlCommand(update, conn);
                sqlCommand.Parameters.AddWithValue("@nm", txtNombre.Text);
                sqlCommand.Parameters.AddWithValue("@Ap", txtApellido.Text);
                sqlCommand.Parameters.AddWithValue("@Fn", dateTimePicker1.Value);
                sqlCommand.Parameters.AddWithValue("@Tl", Convert.ToInt32(txtTelefono.Text));
                sqlCommand.Parameters.AddWithValue("@Dir", txtDireccion.Text);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Cambios realizados con exito");
                    string consulta = "select * from pacientes";
                    MySqlConnection con = new MySqlConnection(cadenaconxion);
                    MySqlDataAdapter comando = new MySqlDataAdapter(consulta, con);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    comando.Fill(ds, "medsystem");
                    dataGridView1.DataSource = ds;
                    txtNombre.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    txtApellido.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtNombre.Clear();
                    dateTimePicker1.Enabled = false;
                    txtApellido.Clear();
                    txtTelefono.Clear();
                    txtDireccion.Clear();
                }
                catch (MySqlException k)
                {
                    MessageBox.Show(k.ToString());
                }
            }
            }
        

                private void btnNew_Click(object sender, EventArgs e)
                {
                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtTelefono.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    comboBox1.Enabled = true;
                    txtDireccion.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;

                    BtnAgregar.Visible = true;
                    btnNew.Visible = false;

                }

                private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
                {

                }

                private void btnMod_Click(object sender, EventArgs e)
                {
                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtTelefono.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    comboBox1.Enabled = true;
                    txtDireccion.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;

                    btnMod.Visible = false;
                    BtnConfirmar.Visible = true;

                }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cadenaconxion);
            conn.Open();
            if (txtNombre.Text == "" & txtApellido.Text == "" & txtTelefono.Text == "" & txtDireccion.Text == "")
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                String update = "UPDATE pacientes SET Nombre=@nm,Apellidos=@Ap,FechaNacimiento=@Fn,Telefono=@Tl,Direccion=@Dir WHERE idPacientes ='" + usMod + "'";
                MySqlCommand sqlCommand = new MySqlCommand(update, conn);
                sqlCommand.Parameters.AddWithValue("@nm", txtNombre.Text);
                sqlCommand.Parameters.AddWithValue("@Ap", txtApellido.Text);
                sqlCommand.Parameters.AddWithValue("@Fn", dateTimePicker1.Value);
                sqlCommand.Parameters.AddWithValue("@Tl", Convert.ToInt32(txtTelefono.Text));
                sqlCommand.Parameters.AddWithValue("@Dir", txtDireccion.Text);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Cambios realizados con exito");
                    string consulta = "select * from pacientes";
                    MySqlConnection con = new MySqlConnection(cadenaconxion);
                    MySqlDataAdapter comando = new MySqlDataAdapter(consulta, con);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    comando.Fill(ds, "medsystem");
                    dataGridView1.DataSource = ds;
                    txtNombre.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    txtApellido.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtNombre.Clear();
                    dateTimePicker1.Enabled = false;
                    txtApellido.Clear();
                    txtTelefono.Clear();
                    txtDireccion.Clear();
                }

                catch (MySqlException k)

                {
                    MessageBox.Show(k.ToString());
              }
            }
          }

        }
     }
            
    
        
    