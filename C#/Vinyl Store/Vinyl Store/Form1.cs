using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vinyl_Store.ServiceReference1;

namespace Vinyl_Store
{
    public partial class Form1 : Form
    {SqlConnection myCon = new SqlConnection();
        DataSet dsAlbume = new DataSet();
        DataSet dsCantece = new DataSet();
        public Form1()
        { InitializeComponent();
            myCon.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ciceu\OneDrive\Desktop\AN 3\sem2\informatica industriala\Vinyl Store\Vinyl Store\MusicStore.mdf;Integrated Security=True";
            myCon.Open();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {Vinyl_Store.ServiceReference1.WebService1SoapClient service = new Vinyl_Store.ServiceReference1.WebService1SoapClient();
           string color = textBox1.Text.Trim();
                    var albumNames = service.GetAlbumsByColor(color);
                    Albume.Items.Clear();
                    foreach (string albumName in albumNames)
                    {Albume.Items.Add(albumName);
                    }
                    textBox1.Clear();
                
            }
        private void Albume_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Albume.SelectedIndex != -1)
            {string albumName = Albume.SelectedItem.ToString();
                ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
                string[] songTitles = service.GetSongsByAlbum(albumName);
                  Tracklist.Items.Clear();
                foreach (string songTitle in songTitles)
                {Tracklist.Items.Add(songTitle);
                }
            }

        }
        private void allAlbums_Click(object sender, EventArgs e)
        { ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
            dsAlbume = service.GetAlbums();
            Albume.Items.Clear();
            Tracklist.Items.Clear();
            foreach (DataRow row in dsAlbume.Tables["Albume"].Rows)
            {string albumName = row["NumeAlbum"].ToString();
                Albume.Items.Add(albumName);
            }


        }
        private void AddBtn_Click(object sender, EventArgs e)
        {ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
            int albumId = Convert.ToInt32(textBox2.Text);
            string albumName = textBox3.Text;
            string cdColor = textBox4.Text;
            service.AddAlbums(albumId, albumName, cdColor);
            MessageBox.Show("Album adăugat cu succes!");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
            int albumId = Convert.ToInt32(textBox5.Text);
            string albumName = textBox6.Text;
            string cdColor = textBox7.Text;
            service.UpdateAlbum(albumId, albumName, cdColor);
            MessageBox.Show("Albumul a fost modificat!");
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {ServiceReference1.WebService1SoapClient service = new ServiceReference1.WebService1SoapClient();
            int albumId = Convert.ToInt32(textBox8.Text);
            service.DeleteAlbum(albumId);
            MessageBox.Show("Albumul a fost sters");
            textBox8.Clear();

        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.Albume = new System.Windows.Forms.ListBox();
            this.Tracklist = new System.Windows.Forms.ListBox();
            this.allAlbums = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 159);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(129, 158);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // Albume
            // 
            this.Albume.FormattingEnabled = true;
            this.Albume.ItemHeight = 16;
            this.Albume.Location = new System.Drawing.Point(266, 48);
            this.Albume.Name = "Albume";
            this.Albume.Size = new System.Drawing.Size(120, 196);
            this.Albume.TabIndex = 2;
            this.Albume.SelectedIndexChanged += new System.EventHandler(this.Albume_SelectedIndexChanged);
            // 
            // Tracklist
            // 
            this.Tracklist.FormattingEnabled = true;
            this.Tracklist.ItemHeight = 16;
            this.Tracklist.Location = new System.Drawing.Point(454, 48);
            this.Tracklist.Name = "Tracklist";
            this.Tracklist.Size = new System.Drawing.Size(139, 196);
            this.Tracklist.TabIndex = 3;
            // 
            // allAlbums
            // 
            this.allAlbums.Location = new System.Drawing.Point(129, 29);
            this.allAlbums.Name = "allAlbums";
            this.allAlbums.Size = new System.Drawing.Size(75, 23);
            this.allAlbums.TabIndex = 4;
            this.allAlbums.Text = "Search";
            this.allAlbums.UseVisualStyleBackColor = true;
            this.allAlbums.Click += new System.EventHandler(this.allAlbums_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search all albums";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search albums based of color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Albums Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Promotional Singles:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(13, 314);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 342);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(13, 370);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 11;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(21, 398);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 12;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Add an Album:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(180, 314);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 14;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(180, 342);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 15;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(180, 370);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Update an Album:";
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(191, 398);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 18;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(353, 314);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Delete an Album:";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(365, 341);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 21;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(710, 453);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allAlbums);
            this.Controls.Add(this.Tracklist);
            this.Controls.Add(this.Albume);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
    }

