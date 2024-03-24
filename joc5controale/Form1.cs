using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace joc5controale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConButton_Click(object sender, EventArgs e)
        {
            StreamReader streamReder = new StreamReader("Parolajoc.txt", true);
            string line = string.Empty;
            while ((line = streamReder.ReadLine()) != null)
            {
                string[] temp = line.Split(' ');

                if (temp[0] == textBox1.Text && temp[1] == textBox2.Text)
                {
                    Form2 secondForm = new Form2(textBox1.Text);
                    secondForm.Show();


                }
            }
        }
    }
}

