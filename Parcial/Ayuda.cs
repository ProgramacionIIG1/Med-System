﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial
{
    public partial class Ayuda : Form
    {

        private object texto;
        private object text;

        public Ayuda()
        {
            InitializeComponent();
        }

        private void Ayuda_Load(object sender, EventArgs e)
        {
            StreamReader Archivo = new StreamReader("\\DELL\\source\\repos\\Med-System\\Parcial\\ayuda.txt");
            string Linea = "";
            ArrayList Contenido = new ArrayList();
            while (Linea != null)
            {
                Linea = Archivo.ReadLine();
                if (Linea != null)
                    Contenido.Add(Linea);
                textBox1.Text = Linea;
            }
            Archivo.Close();
            textBox1.Text = "";

            foreach (string Linea_mostrar in Contenido)
            {
                textBox1.Text = textBox1.Text + Linea_mostrar;
            }

        }
    }
}
