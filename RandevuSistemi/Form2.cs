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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=aracservis.accdb");

        private void goster()
        {
            OleDbDataAdapter getir = new OleDbDataAdapter("SELECT *FROM servis", baglantim);
            DataSet göster = new DataSet();
            getir.Fill(göster, "servis");
            dataGridView1.DataSource = göster.Tables["servis"];
            getir.Dispose();
            baglantim.Close();
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.Text = "RANDEVU BİLGİ SİSTEMİ";
            textBox5.MaxLength = 11;
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox5.CharacterCasing = CharacterCasing.Upper;
            textBox6.CharacterCasing = CharacterCasing.Upper;
            textBox8.CharacterCasing = CharacterCasing.Upper;

            comboBox1.Items.Add("Hatchback");
            comboBox1.Items.Add("Sedan");

            //Date time kullanımı
            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            comboBox2.Items.Add("08");
            comboBox2.Items.Add("09");
            comboBox2.Items.Add("10");
            comboBox2.Items.Add("11");
            comboBox2.Items.Add("12");
            comboBox2.Items.Add("13");
            comboBox2.Items.Add("14");
            comboBox2.Items.Add("15");
            comboBox2.Items.Add("16");
            comboBox2.Items.Add("17");


            comboBox3.Items.Add("00");
            comboBox3.Items.Add("30");

            comboBox4.Items.Add("Fren Bakımı");
            comboBox4.Items.Add("Yağ Değişimi");
            comboBox4.Items.Add("Ön Takım");
            comboBox4.Items.Add("Amortisör Kontrolü");
            comboBox4.Items.Add("Akü Kontrolü");
            comboBox4.Items.Add("Buji Bakımı ve Temizliği");
            comboBox4.Items.Add("Lastik Kontrolü");
            comboBox4.Items.Add("Aydınlatma Elemanları ");
            comboBox4.Items.Add("Radyatör Temizliği");
            comboBox4.Items.Add("Polen Filtresi Temizliği");
            comboBox4.Items.Add("Su Değişimi");
            comboBox4.Items.Add("Karbon Temizleme");
            comboBox4.Items.Add("Antifiriz Eklenmesi");
            comboBox4.Items.Add("Hava Filtresi");
            comboBox4.Items.Add("Trigger Kayışı");
            comboBox4.Items.Add("Rezitanslar");
            comboBox4.Items.Add("Klima Kontrolü");
            comboBox4.Items.Add("Egzoz Muayenesi");

            goster();
            timer1.Start();
            timer2.Start();
        }

        int s = 0, z = 0, c = 0; 

        private void button1_Click(object sender, EventArgs e)//ekle
        {
            //Telefon No veri kontorlü yapıyoruz
            if (textBox3.Text.Length < 11 || textBox3.Text == " ")
                label3.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label3.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            //Adı veri Kontorlü-- 
            if (textBox1.Text.Length < 2 || textBox1.Text == " ")
                label1.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label1.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            //Soyadı veri Kontorlü-- 
            if (textBox2.Text.Length < 2 || textBox2.Text == " ")
                label2.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label2.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            if (textBox4.Text.Length < 2 || textBox4.Text == " ")
                label4.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label4.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            if (textBox5.Text.Length < 2 || textBox5.Text == " ")
                label5.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label5.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            if (textBox6.Text.Length < 2 || textBox6.Text == " ")
                label6.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label6.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            if (textBox7.Text.Length < 2 || textBox7.Text == " ")
                label7.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label7.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            if (textBox8.Text.Length < 2 || textBox8.Text == " ")
                label8.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label8.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            //kayıt işlemlerine başlıyoruz. Hiç bir sorun yoksa
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text.Length == 11 && textBox3.Text != "" &&
                textBox1.Text.Length > 1 && textBox2.Text.Length > 1 && textBox4.Text != "" && textBox5.Text != "" &&
                textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox4.Text != "" && comboBox1.Text != "" && dateTimePicker1.Text != "" &&
               comboBox2.Text != "" &&comboBox3.Text != "" )
            {
                if (s >= 1)
                {
                    MessageBox.Show("Randevu Günü Başka Bir Araca Bu Saate Randevu Verilmiştir Lütfen Başka Bir Saati Seçiniz");
                }
                
               
                 baglantim.Open();
                 if (s == 0)
                    {
                        OleDbCommand eklekomutu = new OleDbCommand("INSERT INTO servis ([Ad],[Soyad],[Telefon],[Km],[Plaka],[Marka],[Uretimyili],[Model],[Aracturu],[Yapilanis],[Randevugunu],[Randevusaati],[durum]) Values (@Ad,@Soyad,@Telno,@Aracınkm,@Aracınplaka,@Aracınmarka,@Aracinüretimyili,@Aracınmodel,@Aractürü,@Yapılaniş,@Randevugün,@Randevusaat,@durum)", baglantim);
                        eklekomutu.Parameters.AddWithValue("@Ad", textBox1.Text);
                        eklekomutu.Parameters.AddWithValue("@Soyad", textBox2.Text);
                        eklekomutu.Parameters.AddWithValue("@Telno", textBox3.Text);
                        eklekomutu.Parameters.AddWithValue("@Aracınkm", textBox4.Text);
                        eklekomutu.Parameters.AddWithValue("@Aracınplaka", textBox5.Text);
                        eklekomutu.Parameters.AddWithValue("@Aracınmarka", textBox6.Text);
                        eklekomutu.Parameters.AddWithValue("@Aracınüretimyili", textBox7.Text);
                        eklekomutu.Parameters.AddWithValue("@Aracınmodel", textBox8.Text);
                        eklekomutu.Parameters.AddWithValue("@Aractürü", comboBox1.Text);
                        eklekomutu.Parameters.AddWithValue("@Yapılaniş", comboBox4.Text);
                        eklekomutu.Parameters.AddWithValue("@Randevugün", dateTimePicker1.Text);
                        eklekomutu.Parameters.AddWithValue("@Randevusaat", comboBox2.Text + comboBox3.Text);
                        eklekomutu.Parameters.AddWithValue("@durum", "onaylanmadı");
                        eklekomutu.ExecuteNonQuery();
                        baglantim.Close();
                        MessageBox.Show("Randevu Alındı", "Arac Randevu Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        goster();
                    }
                  
               baglantim.Close();
               timer2.Start();
               s = 0;
               temizle();
            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz..!", "Arac Randevu Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           /* baglantim.Open();
            OleDbCommand sorgu = new OleDbCommand("SELECT * FROM servis order by randevugunu", baglantim);
            OleDbDataReader datare;
            datare = sorgu.ExecuteReader();
            while (datare.Read())
            {
                string a = Convert.ToString(dateTimePicker1.Text);
                if (a == datare[9].ToString())
                {

                    OleDbCommand sorgu1 = new OleDbCommand("SELECT * FROM servis order by randevusaati", baglantim);
                    while (datare.Read())
                    {
                        string t = Convert.ToString(comboBox2.Text + comboBox3.Text);
                        if (t == datare[10].ToString())
                        {
                            s++;
                        }
                    }
                }
            }
            if (s >= 1)
            {
                MessageBox.Show("Randevu Günü Başka Bir Araca Bu Saate Randevu Verilmiştir Lütfen Başka Bir Saati Seçiniz");
            }
            if (s == 0)
            {
                OleDbCommand ekle = new OleDbCommand("INSERT INTO servis ([Ad],[Soyad],[Telefon],[Km],[Plaka],[Marka],[Uretimyili],[Model],[Aracturu],[Randevugunu],[Randevusaati],[durum]) Values (@Ad,@Soyad,@Telno,@Aracınkm,@Aracınplaka,@Aracınmarka,@Aracinüretimyili,@Aracınmodel,@Aractürü,@Randevugün,@Randevusaat,@durum)", baglantim);
                ekle.Parameters.AddWithValue("@Ad", textBox1.Text);
                ekle.Parameters.AddWithValue("@Soyad", textBox2.Text);
                ekle.Parameters.AddWithValue("@Telno", textBox3.Text);
                ekle.Parameters.AddWithValue("@Aracınkm", textBox4.Text);
                ekle.Parameters.AddWithValue("@Aracınplaka", textBox5.Text);
                ekle.Parameters.AddWithValue("@Aracınmarka", textBox6.Text);
                ekle.Parameters.AddWithValue("@Aracınüretimyili", textBox7.Text);
                ekle.Parameters.AddWithValue("@Aracınmodel", textBox8.Text);
                ekle.Parameters.AddWithValue("@Aractürü", comboBox1.Text);
                ekle.Parameters.AddWithValue("@Randevugün", dateTimePicker1.Text);
                ekle.Parameters.AddWithValue("@Randevusaat", comboBox2.Text + comboBox3.Text);
                ekle.Parameters.AddWithValue("@durum", "onaylanmadı");
                ekle.ExecuteNonQuery();

                MessageBox.Show("Randevu Alındı");
                goster();
            }
            baglantim.Close();
            timer2.Start();
             

            s = 0;
            temizle();*/
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label13.Text = DateTime.Now.ToShortDateString();
            label15.Text = DateTime.Now.ToLongTimeString();
            /*if (z == 0 && c == 0)
            {
                listBox1.Items.Add("Bugün Servise Gelecek Araç Yok!");
                c++;
            }*/
        }

        private void button2_Click(object sender, EventArgs e)//sil
        {
            DialogResult durum;
            durum = MessageBox.Show("Servis Rezervasyonunu İptal Etmek İstediğinizden Emin misiniz?.", "ARAÇ BAKIM SERVİS REZERVASYONU", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (durum == DialogResult.Yes)
            {
                baglantim.Open();
                OleDbCommand sil = new OleDbCommand("DELETE From servis Where [Plaka]=@Aracınplaka", baglantim);
                sil.Parameters.AddWithValue("@Aracınplaka", textBox5.Text);
                sil.ExecuteNonQuery();
                sil.Dispose();
                MessageBox.Show("Rezervasyon İptal Edildi.", "ARAÇ SERVİS RANDEVU SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                baglantim.Close();

                goster();
                temizle();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* int secili = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secili].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secili].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secili].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secili].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secili].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secili].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secili].Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secili].Cells[8].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secili].Cells[9].Value.ToString();*/
        }

        private void button3_Click(object sender, EventArgs e)//guncelle
        {
            //Telefon No veri kontorlü yapıyoruz
            if (textBox3.Text.Length < 11 || textBox3.Text == " ")
                label3.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label3.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            //Adı veri Kontorlü-- 
            if (textBox1.Text.Length < 2 || textBox1.Text == " ")
                label1.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label1.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            //Soyadı veri Kontorlü-- 
            if (textBox2.Text.Length < 2 || textBox2.Text == " ")
                label2.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label2.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            if (textBox4.Text.Length < 2 || textBox4.Text == " ")
                label4.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label4.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            if (textBox5.Text.Length < 2 || textBox5.Text == " ")
                label5.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label5.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            if (textBox6.Text.Length < 2 || textBox6.Text == " ")
                label6.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label6.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            if (textBox7.Text.Length < 2 || textBox7.Text == " ")
                label7.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label7.ForeColor = Color.Black; //tc k.no yazısı siyah olucak
            if (textBox8.Text.Length < 2 || textBox8.Text == " ")
                label8.ForeColor = Color.Red; //tc k.no yazısı kırmızı olucak
            else
                label8.ForeColor = Color.Black; //tc k.no yazısı siyah olucak

            //kayıt işlemlerine başlıyoruz. Hiç bir sorun yoksa
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text.Length == 11 && textBox3.Text != "" &&
                textBox1.Text.Length > 1 && textBox2.Text.Length > 1 && textBox4.Text != "" && textBox5.Text != "" &&
                textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox1.Text != "" && comboBox4.Text != "" && dateTimePicker1.Text != "" &&
               comboBox2.Text != "" && comboBox3.Text != "")
            {
                //güncelle işlemi
                try
                {
                    baglantim.Open();
                    OleDbCommand guncellekomutu = new OleDbCommand("update servis SET [Ad]=@Ad,[Soyad]=@Soyad,[Telefon]=@Telno,[Km]=@Aracınkm,[Plaka]=@Aracınplaka,[Marka]=@Aracınmarka,[Uretimyili]=@Aracınüretimyili, [Model]=@Aracınmodel,[Aracturu]=@Aractürü,[Yapilanis]=@Yapılaniş ,[Randevugunu]=@Randevugün,[Randevusaati]=@Randevusaat Where [Plaka]=@Aracınplaka ", baglantim);
                    guncellekomutu.Parameters.AddWithValue("@Ad", textBox1.Text);
                    guncellekomutu.Parameters.AddWithValue("@Soyad", textBox2.Text);
                    guncellekomutu.Parameters.AddWithValue("@Telno", textBox3.Text);
                    guncellekomutu.Parameters.AddWithValue("@Aracınkm", textBox4.Text);
                    guncellekomutu.Parameters.AddWithValue("@Aracınplaka", textBox5.Text);
                    guncellekomutu.Parameters.AddWithValue("@Aracınmarka", textBox6.Text);
                    guncellekomutu.Parameters.AddWithValue("@Aracınüretimyili", textBox7.Text);
                    guncellekomutu.Parameters.AddWithValue("@Aracınmodel", textBox8.Text);
                    guncellekomutu.Parameters.AddWithValue("@Aractürü", comboBox1.Text);
                    guncellekomutu.Parameters.AddWithValue("@Yapılaniş", comboBox4.Text);
                    guncellekomutu.Parameters.AddWithValue("@Randevugün", dateTimePicker1.Text);
                    guncellekomutu.Parameters.AddWithValue("@Randevusaat", comboBox2.Text + comboBox3.Text);
                    guncellekomutu.Parameters.AddWithValue("@durum", "onaylanmadı");
                    guncellekomutu.ExecuteNonQuery();
                    baglantim.Close();
                    MessageBox.Show("Randevu bilgileri güncellendi..!", "ARAÇ SERVİS RANDEVU SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 goster();
                 temizle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ARAÇ SERVİS RANDEVU SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz..!", "ARAÇ SERVİS RANDEVU SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }
  

        private void timer2_Tick(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            baglantim.Open();
            OleDbCommand sorgu = new OleDbCommand("SELECT * FROM servis", baglantim);

            OleDbDataReader datare = sorgu.ExecuteReader();

            while (datare.Read())
            {
                string a = Convert.ToString(DateTime.Now.ToLongDateString());
                if (a == datare[10].ToString())
                {
                    z++;
                    //listBox1.Items.Add(datare[4].ToString());
                }
            }
            datare.Close();
            baglantim.Close();

            goster();
            timer2.Stop();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            // Tc kimlik  numarası sayılardan oluşur. Bu yüzden harf yazılmaz.
            if (textBox3.Text.Length < 11)

                errorProvider1.SetError(textBox3, "Telefon No 11 karakter olmalı..");
            else
                errorProvider1.Clear();
        }

        private void button4_Click(object sender, EventArgs e) //arama
        {
            bool kayit_arama_durumu = false;
            if (textBox3.Text.Length == 11)
            {
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from servis where telefon = '" + textBox3.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    textBox1.Text = kayitokuma.GetValue(0).ToString();
                    textBox2.Text = kayitokuma.GetValue(1).ToString();
                    textBox4.Text = kayitokuma.GetValue(3).ToString();
                    textBox5.Text = kayitokuma.GetValue(4).ToString();
                    textBox6.Text = kayitokuma.GetValue(5).ToString();
                    textBox7.Text = kayitokuma.GetValue(6).ToString();
                    textBox8.Text = kayitokuma.GetValue(7).ToString();
                    comboBox1.Text = kayitokuma.GetValue(8).ToString();
                    comboBox4.Text = kayitokuma.GetValue(9).ToString();
                    dateTimePicker1.Text = kayitokuma.GetValue(10).ToString();
                    break;
                }
                if (kayit_arama_durumu == false)
                    MessageBox.Show("Aranan kayıt bulunamadı !. ", "ARAÇ SERVİS RANDEVU SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglantim.Close();
            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli bir Telefon No Giriniz. !. ", "ARAÇ SERVİS RANDEVU SİSTEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                temizle();
            }
        }

    }
}
