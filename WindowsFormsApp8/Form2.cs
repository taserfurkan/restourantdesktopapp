using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader rd;

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {



            con = new SqlConnection(@"Data Source=DESKTOP-MJG0QFS;Initial Catalog=restorantapp;Integrated Security=True");
            cmd = new SqlCommand();

            //Burası tarih aldığım kısım. kullanıcının veri girmesini engellemek için Enable özellği false olmalı
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;

            //Bütün butonlarımı aktif olarak kullanmak istiyorum.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;

            //comboox1 gider tablosu için item doldurma vs.
            comboBox1.Items.Add("Fatura");
            comboBox1.Items.Add("Kira");
            comboBox1.Items.Add("Dükkan Alışverişi");
            comboBox1.Items.Add("SSK Ödemeleri");
            comboBox1.Items.Add("İşçi Ödemeleri");
            comboBox1.Items.Add("Diğer");
            comboBox1.FlatStyle = FlatStyle.Standard;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Sorted = false;


            //combobox2 gelir tablosu için item doldurma vs.
            comboBox2.Items.Add("Restourant Geliri");
            comboBox2.Items.Add("Kira Gelirleri");
            comboBox2.FlatStyle = FlatStyle.Standard;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Sorted = false;


            //datetimepicker için özellikler
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.MinDate = new DateTime(1970, 1, 1);
            dateTimePicker1.ShowUpDown = false;


            //errorprovider için tc 11 haneli olmalıdır
            textBox6.MaxLength = 11;

            //tabpage isimleri
            tabPage1.Text = "İşçiler";
            tabPage2.Text = "Gelir-Gider";

            //picturebox resmimi tam alması için;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            //Toplam tutarlara veri girilmemesi lazım
            textBox7.Enabled = false;
            textBox10.Enabled = false;

            //RESİM İÇİN SADECE BUTON KULLANILSIN 
            textBox3.Enabled = false;


            //form ekranım yüklenirken datagridviewler dolu olması lazım.
            yenile();
            yenile2();
            yenile3();
            yenile4();
            yenile5();


            //toplamları aldığım fonk.
            toplam();
            toplam2();




        }










        //-------------------------------------------------------
        //BU satırdan aşağısı yönetici girişi tabcontrol1 sayfası

        private void button2_Click(object sender, EventArgs e)
        {

            cmd.Connection = con;
            yenile();


        }

        public void yenile()
        {
            //dgv yenileme fonksiyonudur
            cmd.Connection = con;
            con.Open();
            string kayıt = "SELECT *from iscibilgileri";
            cmd = new SqlCommand(kayıt, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            //yeni işçi eklemek için
            con.Open();
            string ekle = "insert into iscibilgileri(TC, Ad, Soyad, TelefonNumarası, DoğumTarihi, İşeGirişTarihi, İştenÇıkışTarihi, Resim) values (@tc, @ad, @soyad, @tel, @dog, @isg, @isc, @res)";
            cmd = new SqlCommand(ekle, con);
            cmd.Parameters.AddWithValue("@tc", textBox6.Text);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@tel", maskedTextBox3.Text);
            cmd.Parameters.AddWithValue("@dog", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@isg", textBox4.Text);
            cmd.Parameters.AddWithValue("@isc", textBox5.Text);
            cmd.Parameters.AddWithValue("@res", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile();
            MessageBox.Show("Başarılı");

            verisil();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ara();
        }
        public void ara()
        {

            if (textBox1.Text != null)
            {
                con.Open();
                string arama = "Select *from iscibilgileri where Ad=@isim";
                cmd = new SqlCommand(arama, con);
                cmd.Parameters.AddWithValue("@isim", textBox1.Text);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox6.Text = rd["TC"].ToString();
                    textBox1.Text = rd["Ad"].ToString();
                    textBox2.Text = rd["Soyad"].ToString();
                    maskedTextBox3.Text = rd["TelefonNumarası"].ToString();
                    dateTimePicker2.Text = rd["DoğumTarihi"].ToString();
                    textBox4.Text = rd["İşeGirişTarihi"].ToString();
                    textBox5.Text = rd["İştenÇıkışTarihi"].ToString();
                    textBox3.Text = rd["Resim"].ToString();

                    pictureBox1.ImageLocation = textBox3.Text;
                }
                con.Close();
                yenile();
            }

            else
                MessageBox.Show("Arama Yapabilmeniz İçin Ad Kısmını Doldurunuz!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sil();
            yenile();
        }

        public void sil()
        {

            con.Open();
            SqlCommand sil = new SqlCommand("delete from iscibilgileri where TC=@tc", con);
            sil.Parameters.AddWithValue("@tc", textBox6.Text);
            sil.ExecuteNonQuery();
            con.Close();

            DialogResult durum = new DialogResult();

            durum = MessageBox.Show("Kaydı Silmek İstiyormusunuz?", "Uyarı ", MessageBoxButtons.OKCancel);

            if (durum == DialogResult.OK)
            {
                con.Open();

                SqlCommand kayıtsil = new SqlCommand("delete from iscibilgileri where TC=@c", con);
                sil.Parameters.AddWithValue("@c", textBox6.Text);
                sil.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt Silindi...");
                con.Close();
            }
            else
            {
                MessageBox.Show("Hiçbir İşlem Yapılmadı");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string guncelle = "update iscibilgileri set Ad=@ad,Soyad=@soyad,TelefonNumarası=@tel,DoğumTarihi=@dog, İşeGirişTarihi=@isg, İştenÇıkışTarihi=@ict, Resim=@res where TC=@tc";
            cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@tc", textBox6.Text);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@tel", maskedTextBox3.Text);
            cmd.Parameters.AddWithValue("@dog", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@isg", textBox4.Text);
            cmd.Parameters.AddWithValue("@ict", textBox5.Text);
            cmd.Parameters.AddWithValue("@res", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            yenile();
        }

        public void verisil()
        {
            //kullanıcı silme işlemi yaptığında bütün textbox silinmesi için oluşturulmuş fonk.
            textBox6.Text = "  ";
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox3.Text = "";
            dateTimePicker2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";

            pictureBox1.ImageLocation = textBox3.Text;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            verisil();
        }

        //tc max 11 hane olacağından error provider ayarlama
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length < 11 || textBox6.Text.Length > 11)
            {
                errorProvider1.SetError(textBox6, "TC NO 11 karakter olmalıdır.");
            }

            else
            {
                errorProvider1.Clear();
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox3.Text = openFileDialog1.FileName;


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//çift click ile dgv deki verileri textboxlara doldurma
            int ınd = dataGridView1.SelectedCells[0].RowIndex;
            textBox6.Text = dataGridView1.Rows[ınd].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[ınd].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[ınd].Cells[2].Value.ToString();
            maskedTextBox3.Text = dataGridView1.Rows[ınd].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[ınd].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[ınd].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[ınd].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.Rows[ınd].Cells[7].Value.ToString();

            ara();
        }



        //-------------------------------------------------------
        //Buraya kadar olan kodlar yönetici girişi tabcontrol1 sayfası









        //-------------------------------------------------------
        //Buradan aşağısı yönetici girişi tabcontrol2 gider groupbox
        private void button10_Click(object sender, EventArgs e)
        {
            yenile2();
        }


        public void yenile2()
        {
            con.Open();
            string yenile = "SELECT *from ggtablo";
            cmd = new SqlCommand(yenile, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = dateTimePicker1.Text;


            con.Open();
            string ekle2 = "insert into ggtablo (HarcamaTürü, HarcamaTutarı, HarcamaDetayı, HarcamaTarihi) values (@htü, @ht, @hd, @hta)";
            cmd = new SqlCommand(ekle2, con);
            cmd.Parameters.AddWithValue("@htü", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ht", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@hd", textBox8.Text);
            cmd.Parameters.AddWithValue("@hta", maskedTextBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile2();
            MessageBox.Show("Başarılı");

            toplam();


        }

        private void button9_Click(object sender, EventArgs e)
        {


            con.Open();
            string guncelle = "update ggtablo set HarcamaTürü=@ht,HarcamaTutarı=@htu,HarcamaTarihi=@htt where HarcamaDetayı=@hd ";
            cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@ht", comboBox1.Text);
            cmd.Parameters.AddWithValue("@htu", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@hd", textBox8.Text);
            cmd.Parameters.AddWithValue("@htt", maskedTextBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile2();

            toplam();


        }


        private void button8_Click(object sender, EventArgs e)
        {
            sil2();
            toplam();

        }

        public void sil2()
        {
            con.Open();
            SqlCommand sil = new SqlCommand("delete from ggtablo where HarcamaDetayı=@hd", con);
            sil.Parameters.AddWithValue("@hd", textBox8.Text);
            sil.ExecuteNonQuery();
            con.Close();

            DialogResult durum = new DialogResult();
            durum = MessageBox.Show("Kaydı Silmek İstiyormusunuz?", "Uyarı", MessageBoxButtons.OKCancel);

            if (durum == DialogResult.OK)
            {
                con.Open();
                SqlCommand kayıtsil = new SqlCommand("delete from ggtablo where HarcamaDetayı=@hd", con);
                kayıtsil.Parameters.AddWithValue("@hd", textBox8.Text);
                kayıtsil.ExecuteNonQuery();
                con.Close();
            }

            else
            {
                MessageBox.Show("Hiçbir İşlem Yapılmadı");
            }
            vericsilme();
            yenile2();
        }

        public void vericsilme()
        {//TEXTBOXLARINI SİLME
            comboBox1.Text = "";
            textBox8.Text = "";
            numericUpDown1.Text = "";
            maskedTextBox1.Text = "";
        }


        private void button11_Click(object sender, EventArgs e)
        {
            ara2();
        }

        public void ara2()
        {
            con.Open();
            string arama = "Select *from ggtablo where HarcamaDetayı=@hd";
            if (arama == null)
            {
                MessageBox.Show("Böyle bir sonuç mevcut değil");
            }
            cmd = new SqlCommand(arama, con);
            cmd.Parameters.AddWithValue("@hd", textBox8.Text);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Text = rd["HarcamaTürü"].ToString();
                numericUpDown1.Text = rd["HarcamaTutarı"].ToString();
                textBox8.Text = rd["HarcamaDetayı"].ToString();
                maskedTextBox1.Text = rd["HarcamaTarihi"].ToString();
            }
            con.Close();
        }


        private void button18_Click(object sender, EventArgs e)
        {

            toplam();
        }

        public void toplam()
        {
            con.Open();
            string toplam = "select sum(HarcamaTutarı) from ggtablo";
            cmd = new SqlCommand(toplam, con);
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                textBox7.Text = rd[0].ToString();
            }
            con.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ınd = dataGridView2.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView2.Rows[ınd].Cells[0].Value.ToString();
            numericUpDown1.Text = dataGridView2.Rows[ınd].Cells[1].Value.ToString();
            textBox8.Text = dataGridView2.Rows[ınd].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView2.Rows[ınd].Cells[3].Value.ToString();
        }


        //Buradan yukarısı yönetici girişi tabcontrol2 gider groupbox
        //-------------------------------------------------------





        //--------------------------------------------
        //Buradan aşağısı tabcontrol2 gelir tablosu 


        private void button16_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Text = dateTimePicker1.Text;


            con.Open();
            string ekle2 = "insert into ggtablo2 (GelirTürü, Tutar, Detay, Tarih) values (@gt, @t, @d, @ta)";
            cmd = new SqlCommand(ekle2, con);
            cmd.Parameters.AddWithValue("@gt", comboBox2.Text);
            cmd.Parameters.AddWithValue("@t", numericUpDown2.Text);
            cmd.Parameters.AddWithValue("@d", textBox9.Text);
            cmd.Parameters.AddWithValue("@ta", maskedTextBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile3();
            MessageBox.Show("Başarılı");
            toplam2();
        }

        public void yenile3()
        {
            con.Open();
            string kayıt = "SELECT *from ggtablo2";
            cmd = new SqlCommand(kayıt, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            yenile3();
        }

        public void sil3()
        {
            con.Open();
            SqlCommand sil = new SqlCommand("delete from ggtablo2 where Detay=@d", con);
            sil.Parameters.AddWithValue("@d", textBox9.Text);
            sil.ExecuteNonQuery();
            con.Close();

            DialogResult durum = new DialogResult();
            durum = MessageBox.Show("Kaydı Silmek İstiyormusunuz?", "Uyarı", MessageBoxButtons.OKCancel);

            if (durum == DialogResult.OK)
            {
                con.Open();
                SqlCommand kayıtsil = new SqlCommand("delete from ggtablo2 where Detay=@d", con);
                kayıtsil.Parameters.AddWithValue("@d", textBox9.Text);
                kayıtsil.ExecuteNonQuery();
                con.Close();
            }

            else
            {
                MessageBox.Show("Hiçbir İşlem Yapılmadı");
            }
            vericisilme1();
            yenile3();
            toplam2();
        }

        public void vericisilme1()
        {//TEXTBOX VEİLERİNİ SİLME
            comboBox2.Text = "";
            textBox9.Text = "";
            numericUpDown2.Text = "";
            maskedTextBox2.Text = "";

        }

        public void ara3()
        {
            con.Open();
            string arama = "Select *from ggtablo2 where Detay=@d";
            if (arama == null)
            {
                MessageBox.Show("Böyle bir sonuç mevcut değil");
            }
            cmd = new SqlCommand(arama, con);
            cmd.Parameters.AddWithValue("@d", textBox9.Text);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Text = rd["GelirTürü"].ToString();
                numericUpDown2.Text = rd["Tutar"].ToString();
                textBox9.Text = rd["Detay"].ToString();
                maskedTextBox2.Text = rd["Tarih"].ToString();
            }
            con.Close();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            sil3();
            toplam2();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ara3();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.Open();
            string guncelle = "update ggtablo2 set GelirTürü=@t,Tutar=@hu,Tarih=@tt where Detay=@d ";
            cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@t", comboBox2.Text);
            cmd.Parameters.AddWithValue("@hu", numericUpDown2.Text);
            cmd.Parameters.AddWithValue("@d", textBox9.Text);
            cmd.Parameters.AddWithValue("@tt", maskedTextBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile3();
            toplam2();

        }
        private void button19_Click(object sender, EventArgs e)
        {
            toplam2();
        }

        public void toplam2()
        {
            //GELİR GİDER DEKİ BÜTÜN TOPLAMI BULMAK İÇİN FONKS.
            con.Open();
            string toplam2 = "select sum(Tutar) from ggtablo2";
            cmd = new SqlCommand(toplam2, con);
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                textBox10.Text = rd[0].ToString();
            }
            con.Close();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //ÇİFT TIK İLE TEXTBOX DOLDURMA
            int ınd = dataGridView3.SelectedCells[0].RowIndex;
            comboBox2.Text = dataGridView3.Rows[ınd].Cells[0].Value.ToString();
            numericUpDown2.Text = dataGridView3.Rows[ınd].Cells[1].Value.ToString();
            textBox9.Text = dataGridView3.Rows[ınd].Cells[2].Value.ToString();
            maskedTextBox2.Text = dataGridView3.Rows[ınd].Cells[3].Value.ToString();
        }

        //----------------------------------------------------------






        //------------------------------------------------------
        //Buradan Aşağısı tabcontrol3 şifre işlemleri vs

        public void yenile4()
        {
            con.Open();
            string kayıt = "SELECT *from yoneticigiris";
            cmd = new SqlCommand(kayıt, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();

        }

        public void v_sil2()
        {
            textBox11.Text = "";
            textBox12.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            con.Open();
            string ekle = "insert into yoneticigiris(Kullanıcıadı, sifre) values (@ıd, @sifre)";
            cmd = new SqlCommand(ekle, con);
            cmd.Parameters.AddWithValue("@ıd", textBox11.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox12.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile4();
            v_sil2();
            MessageBox.Show("Başarılı");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sil = new SqlCommand("delete from yoneticigiris where kullanıcıadı=@ıd", con);
            sil.Parameters.AddWithValue("@ıd", textBox11.Text);
            sil.ExecuteNonQuery();
            con.Close();

            DialogResult durum = new DialogResult();
            durum = MessageBox.Show("Kaydı Silmek İstiyormusunuz?", "Uyarı", MessageBoxButtons.OKCancel);

            if (durum == DialogResult.OK)
            {
                con.Open();
                SqlCommand kayıtsil = new SqlCommand("delete from yoneticigiris where kullanıcıadı=@ıd", con);
                kayıtsil.Parameters.AddWithValue("@ıd", textBox11.Text);
                kayıtsil.ExecuteNonQuery();
                con.Close();
                yenile4();
                v_sil2();
            }

            else
            {
                MessageBox.Show("Hiçbir İşlem Yapılmadı");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            con.Open();
            string guncelle = "update yoneticigiris set kullanıcıadı=@ıd, sifre=@psw where kullanıcıadı=@ıd ";
            cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@ıd", textBox11.Text);
            cmd.Parameters.AddWithValue("@psw", textBox12.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile4();
            v_sil2();
            MessageBox.Show("İşlem Yapıldı");
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ınd = dataGridView4.SelectedCells[0].RowIndex;
            textBox11.Text = dataGridView4.Rows[ınd].Cells[0].Value.ToString();
            textBox12.Text = dataGridView4.Rows[ınd].Cells[1].Value.ToString();
        }




        public void yenile5()
        {
            con.Open();
            string kayıt = "SELECT *from iscigiris";
            cmd = new SqlCommand(kayıt, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            con.Close();
        }
        public void v_sil()
        {
            textBox13.Text = "";
            textBox14.Text = "";
        }
        private void button23_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into iscigiris (ıd, _sıfre) values (@ıd, @sıfre)", con);
            cmd.Parameters.AddWithValue("ıd", textBox13.Text);
            cmd.Parameters.AddWithValue("@sıfre", textBox14.Text);
            cmd.ExecuteNonQuery();            
            con.Close();

            yenile5();
            v_sil();

            MessageBox.Show("Başarılı");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sil = new SqlCommand("delete from iscigiris where ıd=@ıd", con);
            sil.Parameters.AddWithValue("@ıd", textBox13.Text);
            sil.ExecuteNonQuery();
            con.Close();

            DialogResult durum = new DialogResult();
            durum = MessageBox.Show("Kaydı Silmek İstiyormusunuz?", "Uyarı", MessageBoxButtons.OKCancel);

            if (durum == DialogResult.OK)
            {
                con.Open();
                SqlCommand kayıtsil = new SqlCommand("delete from iscigiris where ıd=@ıd", con);
                kayıtsil.Parameters.AddWithValue("@ıd", textBox13.Text);
                kayıtsil.ExecuteNonQuery();
                con.Close();
                yenile5();
                v_sil();
            }

            else
            {
                MessageBox.Show("Hiçbir İşlem Yapılmadı");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            con.Open();
            string guncelle = "update iscigiris set ıd=@ıd, _sifre=@psw where ıd=@ıd ";
            cmd = new SqlCommand(guncelle, con);
            cmd.Parameters.AddWithValue("@ıd", textBox13.Text);
            cmd.Parameters.AddWithValue("@psw", textBox14.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            yenile4();
            MessageBox.Show("İşlem Yapıldı");
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ınd = dataGridView5.SelectedCells[0].RowIndex;
            textBox13.Text = dataGridView5.Rows[ınd].Cells[0].Value.ToString();
            textBox14.Text = dataGridView5.Rows[ınd].Cells[1].Value.ToString();
        }
        
    }
    }

    

