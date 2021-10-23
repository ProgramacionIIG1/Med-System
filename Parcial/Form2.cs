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
        }
    }
}
