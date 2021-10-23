using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial
{
    public partial class Form2 : Form 
        
    {
        public string cadenaconxion = "Database=medsystem;Data Source=localhost;User Id=Erick;Password=1452";

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

                MySqlConnection con = new MySqlConnection(cadena_conexion);
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
            Close();
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
    }
}
