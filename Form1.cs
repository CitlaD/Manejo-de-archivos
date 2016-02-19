using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace crear_archivo_txt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Enabled = false;
        }
        TextWriter Texto;
        String ruta,Leerruta;

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (textBox1.Text != "")
            {

                FolderBrowserDialog fod = new FolderBrowserDialog();
                fod.Description = "Seleccione la ruta donde desea guardar el documento";
                fod.RootFolder = Environment.SpecialFolder.Desktop;
                if (fod.ShowDialog() == DialogResult.OK)
                {
                    ruta = fod.SelectedPath;
                    String mensaje;
                    mensaje = richTextBox1.Text;
                    Texto = new StreamWriter(ruta + "\\" + textBox1.Text + ".txt");
                    Texto.Write(mensaje);
                    Texto.Close();
                    MessageBox.Show("Texto guardado");
                }
            }
            else MessageBox.Show("Escribe un nombre ");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

             OpenFileDialog open = new OpenFileDialog();
           open.Filter=" Archivos txt(*.txt)|*.txt";
           open.Title = "Archivos .txt";
           if(open.ShowDialog()==DialogResult.OK)
           {
               Leerruta=open.FileName;
               textBox2.Text = Leerruta;
               StreamReader file = new StreamReader(Leerruta);
               while (file.Peek() != -1)
               {
                   richTextBox1.Text += file.ReadLine() + "\n";
               }
               file.Close();
           }
           open.Dispose();                       

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = Leerruta;

           String mensaje;
           mensaje = richTextBox1.Text;
           Texto = new StreamWriter(Leerruta);
           Texto.Write(mensaje);
           Texto.Close();
           MessageBox.Show("Cambios guardados");
        }
    }
}
