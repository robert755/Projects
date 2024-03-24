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
    public partial class Form2 : Form
    {
        private List<string> movies = new List<string>();

        public Form2(string text)
        {
            InitializeComponent();
            label1.Text = "Welcome to our renting app, " + text;

        }

        private void closeBtn_Click_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string movie = textBox1.Text.Trim();
            bool movieFound = false;

            using (StreamReader streamReader = new StreamReader("FilmeDisponibile1.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] temp = line.Split(' ');
                    if (temp[0] == movie)
                    {
                        movieFound = true;
                        break;
                    }
                }
            }

            if (movieFound)
            {
                movies.Add(movie);
                listBoxMovie.Items.Add(movie);
            }
            else
            {
                MessageBox.Show("Acest film este indisponibil");
            }
        }

        private void rentBtn_Click(object sender, EventArgs e)
        {
            if (listBoxMovie.SelectedItem != null)
            {
                string selectedMovie = listBoxMovie.SelectedItem.ToString();
                DateTime startDateTime = dateTimePickerstart.Value;
                DateTime endDateTime = dateTimePickerend.Value;
                MessageBox.Show($"Ați închiriat filmul '{selectedMovie}' începând cu data de {startDateTime.ToShortDateString()} pana in data de {endDateTime.ToShortDateString()}");
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați un film pentru a închiria.");
            }

        }

        private void listBoxMovie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

