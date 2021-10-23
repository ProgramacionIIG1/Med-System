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
        public string PacienteId;
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
            this.WindowState = FormWindowState.Maximized;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtTelefono.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            txtDireccion.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;


            try
            {
                string consulta = "SELECT pacientes.IdPaciente,pacientes.Nombre,pacientes.Apellido,pacientes.FechaNacimiento,pacientes.Dui,pacientes.Telefono,pacientes.Sexo,pacientes.Estado,pacientes.Direccion,tratamientos.TratamientosActuales,tratamientos.TratamientosPasados,tratamientos.FechaReceta FROM pacientes INNER JOIN tratamientos ON pacientes.IdPaciente = tratamientos.IdPaciente";
                string contar = "SELECT COUNT(pacientes.IdPaciente) AS contar FROM pacientes";
                MySqlConnection con = new MySqlConnection(cadenaconxion);
                MySqlCommand com = new MySqlCommand(contar, con);
                MySqlDataReader dtr;
                con.Open();
                dtr = com.ExecuteReader();
                dtr.Read();
                conteo.Text = dtr.GetString(0);
                con.Close();
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, con);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "medsystem");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "medsystem";
            }

            catch(MySqlException k)
            {
                MessageBox.Show(k.ToString());
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                    textBox3.Enabled = true;
                    label9.Visible = true;
                    txtCont.Visible = true;
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
            textBox3.Enabled = true;
            


                    btnMod.Visible = false;
                    BtnConfirmar.Visible = true;

                }

        private void btnElim_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cadenaconxion);
            conn.Open();
            if (txtNombre.Text == "" & txtApellido.Text == "" & txtTelefono.Text == "" & txtDireccion.Text == "")
            {
                MessageBox.Show("Hay campos vacios");
            }
            else
            {
                String eliminar = " DELETE FROM `pacientes` WHERE IdPaciente ='" + usMod + "'";
                MySqlCommand sqlCommand = new MySqlCommand(eliminar, conn);
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
                    textBox1.Enabled = false;
                    textBox3.Enabled = false;
                    txtNombre.Clear();
                    dateTimePicker1.Enabled = false;
                    txtApellido.Clear();
                    txtTelefono.Clear();
                    txtDireccion.Clear();
                    textBox1.Clear();
                    textBox3.Clear();
                }
                catch (MySqlException k)
                {
                    MessageBox.Show(k.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from pacientes where IdPaciente ='" + Convert.ToInt32(txtBuscar.Text) + "' ";
                MySqlConnection con = new MySqlConnection(cadenaconxion);
                con.Open();
                MySqlCommand comm = new MySqlCommand(consulta, con);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, con);
                MySqlDataReader dtr;
                dtr = comm.ExecuteReader();
                if (dtr.Read())
                {
                    txtNombre.Text = (dtr.GetString(1));
                    txtApellido.Text = (dtr.GetString(2));
                    dateTimePicker1.Value = (DateTime)dtr.GetValue(3);
                    textBox1.Text = (dtr.GetString(4));
                    txtTelefono.Text = (dtr.GetString(5));
                    comboBox1.Text = (dtr.GetString(6));
                    textBox3.Text = (dtr.GetString(7));
                    txtDireccion.Text = (dtr.GetString(8));
                    usMod = Convert.ToInt32(txtBuscar.Text);
                }
            }
            catch (MySqlException k)
            {
                MessageBox.Show(k.ToString());
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Class1 generarID = new Class1();
            PacienteId = "001" + Convert.ToString(generarID.genId9());
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaconxion);
            string myInsertQuery = "INSERT INTO pacientes (IdPaciente, Nombre, Apellido, FechaNacimiento,Dui, Telefono,Sexo,Estado, Direccion,IdUsuario  ) Value (@idpas, @nom, @ap, @fn,@dui, @tel,@sexo,@Esta, @direc,@IdUs) ";
            string insertUsuario = "INSERT INTO usuarios (IdUsuario,Nombre,Apellido,Contraseña) value (@IdUs,@nomb,@ape,@Contra)";
            MySqlCommand mySqlCommand = new MySqlCommand(myInsertQuery, mySqlConnection);
            MySqlCommand mySqlCommand1 = new MySqlCommand(insertUsuario, mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@idpas", Convert.ToInt32(PacienteId));
            mySqlCommand.Parameters.AddWithValue("@nom", txtNombre.Text);
            mySqlCommand.Parameters.AddWithValue("@ap", txtApellido.Text);
            mySqlCommand.Parameters.AddWithValue("@fn", dateTimePicker1.Value);
            mySqlCommand.Parameters.AddWithValue("@dui", textBox1.Text);
            mySqlCommand.Parameters.AddWithValue("@tel", Convert.ToInt32(txtTelefono.Text));
            mySqlCommand.Parameters.AddWithValue("@sexo",comboBox1.Text);
            mySqlCommand.Parameters.AddWithValue("@Esta", textBox3.Text);
            mySqlCommand.Parameters.AddWithValue("@direc", txtDireccion.Text);
            mySqlCommand.Parameters.AddWithValue("@IdUs", Convert.ToInt32(PacienteId) );
            mySqlCommand1.Parameters.AddWithValue("@IdUs",Convert.ToInt32(PacienteId));
            mySqlCommand1.Parameters.AddWithValue("@nomb", txtNombre.Text);
            mySqlCommand1.Parameters.AddWithValue("@ape", txtApellido.Text);
            mySqlCommand1.Parameters.AddWithValue("@Contra",txtCont.Text);
            mySqlConnection.Open();
            try
            {
                mySqlCommand1.ExecuteNonQuery();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("Usuario agregado con exito");
                BtnAgregar.Visible = false;
                btnNew.Visible = true;
                string consulta = "select * from pacientes";
                MySqlConnection con = new MySqlConnection(cadenaconxion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, con);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "medsystem");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "medsystem";
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
                label9.Visible = false;
                txtCont.Visible = false;
            }

            catch (MySqlException k)
            {
                MessageBox.Show(k.ToString());
            }
        }
    }
        }
    