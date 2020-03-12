using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RandevuSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=aracservis.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text;

            baglantim.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM login where kullaniciadi='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'", baglantim);
            OleDbDataReader komutokuma = komut.ExecuteReader();
            if (komutokuma.Read())
            {
                Form2 form2 = new Form2();
                form2.Show();

                MessageBox.Show("Başarılı Giriş Yaptınız..");
              
            }
            else
                MessageBox.Show("Hatalı Giriş Yaptınız..");
            baglantim.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}
