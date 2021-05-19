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
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader rd;

        



        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-MJG0QFS;Initial Catalog=restorantapp;Integrated Security=True");
            cmd = new SqlCommand();


            //combobox'un veri girilmesini engellemek
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Standard;
            comboBox2.FlatStyle = FlatStyle.Standard;
            comboBox3.FlatStyle = FlatStyle.Standard;
            comboBox4.FlatStyle = FlatStyle.Standard;

            //başlatılırken datagridview dolu olması için
            icecekler();

            //textboxlara veri girilmememsi lazım
            textBox1.Enabled = false;
            textBox2.Enabled = false;

            //masa içinoluşturduğum datagridview gözükmesi laızm
            masa1();

        }

        public void vsil()
        {//EKLEME VS YAPILDIĞINDA TEXTBOXLAR SİLİNİR
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 1;
        } 

        public void vsil1()
        {
            //EKLEME VS YAPILDIĞINDA TEXTBOXLAR SİLİNİR
            textBox3.Text = "";
            textBox4.Text = "";
            numericUpDown2.Value = 1;
        }

        public void vsil2()
        {
            //EKLEME VS YAPILDIĞINDA TEXTBOXLAR SİLİNİR
            textBox6.Text = "";
        }





        //--------------------------------------------
        //Açılır menü için dGV doldurma işlemleri

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int secilen = comboBox1.SelectedIndex;

            switch (secilen)
            {
                case 0:
                    icecekler();
                    break;

                case 1:
                    kahvaltı();
                    break;

                case 2:
                    fastfood();
                    break;

                case 3:
                    vegan();
                    break;

                case 4:
                    tatlılar();
                    break;


            }

        } //switch case ile combobox yönetimi
        public void icecekler()
        {
            con.Open();
            cmd = new SqlCommand("select *from icecekler", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void kahvaltı()
        {
            con.Open();
            cmd = new SqlCommand("select *from kahvaltı", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        public void fastfood()
        {
            con.Open();
            cmd = new SqlCommand("select *from fastfood", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void vegan()
        {
            con.Open();
            cmd = new SqlCommand("select *from vegan", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void tatlılar()
        {
            con.Open();
            cmd = new SqlCommand("select *from tatlılar", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }








        //-------------------------CELLDOUBLECLİCK DATAGRİDVİEW--------------------

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ındex = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[ındex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[ındex].Cells[2].Value.ToString();

        }


        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ındex = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[ındex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.Rows[ındex].Cells[1].Value.ToString();

        }







        //------------------MASALAR DGVDE GÖZÜKÜR-------------------------

        public void masa1()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa1", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa2()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa2", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa3()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa3", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa4()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa4", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa5()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa5", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa6 ()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa6", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa7()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa7", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa8()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa8", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa9()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa9", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void masa10()
        {
            con.Open();
            cmd = new SqlCommand("select *from masa10", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }






        //------------------RADİOBUTONLAR CLİCK OLDUĞUNDA DGV DE GÖZÜKÜR-----------------------
        private void radioButton1_Click(object sender, EventArgs e)
        {
            masa1();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            masa2();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            masa3();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            masa4();

        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            masa5();
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            masa6();
        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
            masa7();
        }

        private void radioButton8_Click(object sender, EventArgs e)
        {
            masa8();
        }

        private void radioButton9_Click(object sender, EventArgs e)
        {
            masa9();
        }

        private void radioButton10_Click(object sender, EventArgs e)
        {
            masa10();
        }







        //------------BUTONLAR-----------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                string ekle = "insert into masa1(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl, @a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa1();
            }

            else if (radioButton2.Checked)
            {
                con.Open();
                string ekle = "insert into masa2(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl, @a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa2();
            }

            else if (radioButton3.Checked)
            {
                con.Open();
                string ekle = "insert into masa3(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl, @a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa3();
            }

            else if (radioButton4.Checked)
            {
                con.Open();
                string ekle = "insert into masa4(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl,@a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa4();
            }

            else if (radioButton5.Checked)
            {
                con.Open();
                string ekle = "insert into masa5(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl, @a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa5();
            }

            else if (radioButton6.Checked)
            {
                con.Open();
                string ekle = "insert into masa6(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl,@a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa6();
            }

            else if (radioButton7.Checked)
            {
                con.Open();
                string ekle = "insert into masa7(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl,@a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa7();
            }

            else if (radioButton8.Checked)
            {
                con.Open();
                string ekle = "insert into masa8(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl,@a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa8();
            }

            else if (radioButton9.Checked)
            {
                con.Open();
                string ekle = "insert into masa9(ÜrünAdı, ToplamFiyat, Adet) values (@ıd, @tl, @a)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa9();
            }

            else if (radioButton10.Checked)
            {
                con.Open();
                string ekle = "insert into masa10(ÜrünAdı, Adet, ToplamFiyat) values (@ıd,@a, @tl)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa10();
            }

            else
                MessageBox.Show("Lütfen masa seçiniz!!!");
            
            vsil();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa1 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa1();
            }

            else if (radioButton2.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa2 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa2();
            }

            else if (radioButton3.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa3 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa3();
            }

            else if (radioButton4.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa4 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa4();
            }

            else if (radioButton5.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa5 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa5();
            }

            else if (radioButton6.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa6 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa6();
            }



            else if (radioButton7.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa7 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa7();
            }

            else if (radioButton8.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa8 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa8();
            }

            else if (radioButton9.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa9 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa9();
            }

            else if (radioButton10.Checked)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa10 where ÜrünAdı=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox1.Text);
                sil.ExecuteNonQuery();
                con.Close();
                masa10();
            }
            vsil();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa1 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.ExecuteNonQuery();
                con.Close();
                masa1();

            }
            else if (radioButton2.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa2 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa2();
            }

            else if (radioButton3.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa3 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa3();
            }

            else if (radioButton4.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa4 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa4();
            }

            else if (radioButton5.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa5 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa5();
            }

            else if (radioButton6.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa6 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa6();
            }



            else if (radioButton7.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa7 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa7();
            }

            else if (radioButton8.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa8 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa8();
            }

            else if (radioButton9.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa9 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa9();
            }

            else if (radioButton10.Checked)
            {
                con.Open();
                cmd = new SqlCommand("update masa10 set ÜrünAdı=@ıd, ToplamFiyat=@tl, Adet=@a where ÜrünAdı=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox1.Text);
                int fiyat = Convert.ToInt32(textBox2.Text);
                int adet = Convert.ToInt32(numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tl", fiyat * adet);
                cmd.Parameters.AddWithValue("@a", numericUpDown1.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                masa10();
            }
            vsil();
           
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if(durum==DialogResult.OK)
                {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from masa1 ", con);
                sil.ExecuteNonQuery();
                con.Close();
                masa1();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
                
            }

            else if (radioButton2.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa2 ", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa2();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
                
            }

            else if (radioButton3.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa3 ", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa3();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
                
            }

            else if (radioButton4.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa4 ", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa4();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
                
            }

            else if (radioButton5.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa5", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa5();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
                
            }

            else if (radioButton6.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa6", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa6();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
            }



            else if (radioButton7.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa7", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa7();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
            }

            else if (radioButton8.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa8", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa8();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
            }

            else if (radioButton9.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa9", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa9();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
            }

            else if (radioButton10.Checked)
            {
                DialogResult durum = new DialogResult();
                durum = MessageBox.Show("DİKKAT!! ONAY VERDİKTEN SONRA MASAYA AİT BÜTÜN İŞLEMLER SİLİNECEKTİR. FİŞ YAZDIRMAYI HATIRLATIRIZ!", "UYARI ", MessageBoxButtons.OKCancel);

                if (durum == DialogResult.OK)
                {
                    con.Open();
                    SqlCommand sil = new SqlCommand("delete from masa10", con);
                    sil.ExecuteNonQuery();
                    con.Close();
                    masa10();
                }

                else
                {
                    MessageBox.Show("Hiçbir İşlem Yapılmadı.", "UYARI");
                }
            }
            vsil();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Font baslık = new Font("Arial", 20, FontStyle.Bold);
            Font altbaslık = new Font("Arial", 16, FontStyle.Bold);
            Font icerik = new Font("Arial", 14, FontStyle.Regular);
            SolidBrush sb = new SolidBrush(Color.Black);
            StringFormat st = new StringFormat();
            


           
            e.Graphics.DrawString("AİLE LOKANTASI", baslık, sb, 300, 100, st);
            e.Graphics.DrawString("ÜRÜN ADI                 ADET                TUTAR", altbaslık, sb, 160, 300, st);
            e.Graphics.DrawString("-------------------------------------------------------------", altbaslık, sb, 160, 310, st);

            for(int i=0; i<dataGridView2.Rows.Count; i++)
            {
                e.Graphics.DrawString(Convert.ToString(dataGridView2.Rows[i].Cells[0].Value), icerik, sb, 160, 330+ i* 30, st);
                e.Graphics.DrawString(Convert.ToString(dataGridView2.Rows[i].Cells[1].Value), icerik, sb, 390, 330+ i*30, st);
                e.Graphics.DrawString(Convert.ToString(dataGridView2.Rows[i].Cells[2].Value) , icerik, sb, 560, 330+i*30, st);
            }

           
            e.Graphics.DrawString("--------------------------------------------------------------", altbaslık, sb, 160,330+ 20* (dataGridView2.Rows.Count));
            e.Graphics.DrawString("TOPLAM TUTAR=", altbaslık, sb,330,330 + 20*(dataGridView2.Rows.Count+1));

            int toplam = 0;
            for (int i=0; i<dataGridView2.Rows.Count;i++)
            {
                 toplam = toplam + Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
            }

            e.Graphics.DrawString(Convert.ToString( toplam), altbaslık, sb, 560, 330 + 20 * (dataGridView2.Rows.Count + 1));


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                con.Open();
                string ekle = "insert into icecekler(ÜrünID, ÜrünAdı, ÜrünFiyatı) values (@ıd, @ad, @tl)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown2.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("BAŞARILI", "UYARI");
                vsil1();
                icecekler();
            }

            if (comboBox2.SelectedIndex == 1)
            {
                con.Open();
                string ekle = "insert into kahvaltı(ÜrünID, ÜrünAdı, ÜrünFiyatı) values (@ıd, @ad, @tl)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown2.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("BAŞARILI", "UYARI");
                vsil1();
                kahvaltı();
            }


            if (comboBox2.SelectedIndex == 2)
            {
                con.Open();
                string ekle = "insert into fastfood(ÜrünID, ÜrünAdı, ÜrünFiyatı) values (@ıd, @ad, @tl)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown2.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("BAŞARILI", "UYARI");
                vsil1();
                fastfood();
            }

            if (comboBox2.SelectedIndex == 3)
            {
                con.Open();
                string ekle = "insert into vegan(ÜrünID, ÜrünAdı, ÜrünFiyatı) values (@ıd, @ad, @tl)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown2.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("BAŞARILI", "UYARI");
                vsil1();
                vegan();
            }

            if (comboBox2.SelectedIndex == 4)
            {
                con.Open();
                string ekle = "insert into tatlılar(ÜrünID, ÜrünAdı, ÜrünFiyatı) values (@ıd, @ad, @tl)";
                cmd = new SqlCommand(ekle, con);
                cmd.Parameters.AddWithValue("@ıd", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown2.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("BAŞARILI", "UYARI");
                vsil1();
                tatlılar();
            }

            




        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex==0)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from icecekler where ÜrünID=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox6.Text);
                sil.ExecuteNonQuery();
                con.Close();
                icecekler();
            }

            if (comboBox3.SelectedIndex == 1)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from kahvaltı where ÜrünID=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox6.Text);
                sil.ExecuteNonQuery();
                con.Close();
                kahvaltı();
            }

            if (comboBox3.SelectedIndex == 2)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from fastfood where ÜrünID=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox6.Text);
                sil.ExecuteNonQuery();
                con.Close();
                fastfood();
            }

            if (comboBox3.SelectedIndex == 3)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from vegan where ÜrünID=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox6.Text);
                sil.ExecuteNonQuery();
                con.Close();
                vegan();
            }

            if (comboBox3.SelectedIndex == 4)
            {
                con.Open();
                SqlCommand sil = new SqlCommand("delete from tatlılar where ÜrünID=@ıd", con);
                sil.Parameters.AddWithValue("@ıd", textBox6.Text);
                sil.ExecuteNonQuery();
                con.Close();
                tatlılar();
            }

            else
            {
                MessageBox.Show("LÜTFEN ALAN SEÇİNİZ");
            }

            vsil2();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(comboBox4.SelectedIndex==0)
            {
                   if (textBox1.Text != null)
            {
                        con.Open();
                        string arama = "Select *from icecekler where ÜrünID=@ıd";
                        cmd = new SqlCommand(arama, con);
                        cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                        rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            textBox7.Text = rd["ÜrünID"].ToString();
                            textBox5.Text = rd["ÜrünAdı"].ToString();
                            numericUpDown3.Value = Convert.ToInt32 (rd["ÜrünFiyatı"]);
                        }
                        con.Close();
                        icecekler();
                        
                }

                   else
                {
                    MessageBox.Show("LÜTFEN ÜRÜNID GİRİNİZ");
                }
            }

            if (comboBox4.SelectedIndex == 1)
            {
                if (textBox1.Text != null)
                {
                    con.Open();
                    string arama = "Select *from kahvaltı where ÜrünID=@ıd";
                    cmd = new SqlCommand(arama, con);
                    cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        textBox7.Text = rd["ÜrünID"].ToString();
                        textBox5.Text = rd["ÜrünAdı"].ToString();
                        numericUpDown3.Value = Convert.ToInt32(rd["ÜrünFiyatı"]);
                    }
                    con.Close();
                    kahvaltı();
                    
                }

                else
                {
                    MessageBox.Show("LÜTFEN ÜRÜNID GİRİNİZ");
                }
            }

            if (comboBox4.SelectedIndex == 2)
            {
                if (textBox1.Text != null)
                {
                    con.Open();
                    string arama = "Select *from fastfood where ÜrünID=@ıd";
                    cmd = new SqlCommand(arama, con);
                    cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        textBox7.Text = rd["ÜrünID"].ToString();
                        textBox5.Text = rd["ÜrünAdı"].ToString();
                        numericUpDown3.Value = Convert.ToInt32(rd["ÜrünFiyatı"]);
                    }
                    con.Close();
                    fastfood();
                    
                }

                else
                {
                    MessageBox.Show("LÜTFEN ÜRÜNID GİRİNİZ");
                }
            }


            if (comboBox4.SelectedIndex == 3)
            {
                if (textBox1.Text != null)
                {
                    con.Open();
                    string arama = "Select *from vegan where ÜrünID=@ıd";
                    cmd = new SqlCommand(arama, con);
                    cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        textBox7.Text = rd["ÜrünID"].ToString();
                        textBox5.Text = rd["ÜrünAdı"].ToString();
                        numericUpDown3.Value = Convert.ToInt32(rd["ÜrünFiyatı"]);
                    }
                    con.Close();
                    vegan();
                    
                }

                else
                {
                    MessageBox.Show("LÜTFEN ÜRÜNID GİRİNİZ");
                }
            }


            if (comboBox4.SelectedIndex == 4)
            {
                if (textBox1.Text != null)
                {
                    con.Open();
                    string arama = "Select *from tatlılar where ÜrünID=@ıd";
                    cmd = new SqlCommand(arama, con);
                    cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        textBox7.Text = rd["ÜrünID"].ToString();
                        textBox5.Text = rd["ÜrünAdı"].ToString();
                        numericUpDown3.Value = Convert.ToInt32(rd["ÜrünFiyatı"]);
                    }
                    con.Close();
                    tatlılar();

                    
                }

                else
                {
                    MessageBox.Show("LÜTFEN ÜRÜNID GİRİNİZ");
                }
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(comboBox4.SelectedIndex==0)
            {
                con.Open();
                cmd = new SqlCommand("update icecekler set ÜrünID=@ıd, ÜrünAdı=@ad, ÜrünFiyatı=@tl where ÜrünID=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                cmd.Parameters.AddWithValue("@ad", textBox5.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown3.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                icecekler();
                MessageBox.Show("BAŞARILI", "UYARI");
            }

            if (comboBox4.SelectedIndex == 1)
            {
                con.Open();
                cmd = new SqlCommand("update kahvaltı set ÜrünID=@ıd, ÜrünAdı=@ad, ÜrünFiyatı=@tl where ÜrünID=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                cmd.Parameters.AddWithValue("@ad", textBox5.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown3.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                kahvaltı();
                MessageBox.Show("BAŞARILI", "UYARI");
            }

            if (comboBox4.SelectedIndex == 2)
            {
                con.Open();
                cmd = new SqlCommand("update fastfood set ÜrünID=@ıd, ÜrünAdı=@ad, ÜrünFiyatı=@tl where ÜrünID=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                cmd.Parameters.AddWithValue("@ad", textBox5.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown3.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                fastfood();
                MessageBox.Show("BAŞARILI", "UYARI");
            }

            if (comboBox4.SelectedIndex == 3)
            {
                con.Open();
                cmd = new SqlCommand("update vegan set ÜrünID=@ıd, ÜrünAdı=@ad, ÜrünFiyatı=@tl where ÜrünID=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                cmd.Parameters.AddWithValue("@ad", textBox5.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown3.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                vegan();
                MessageBox.Show("BAŞARILI", "UYARI");
            }

            if (comboBox4.SelectedIndex == 4)
            {
                con.Open();
                cmd = new SqlCommand("update tatlılar set ÜrünID=@ıd, ÜrünAdı=@ad, ÜrünFiyatı=@tl where ÜrünID=@ıd ", con);
                cmd.Parameters.AddWithValue("@ıd", textBox7.Text);
                cmd.Parameters.AddWithValue("@ad", textBox5.Text);
                cmd.Parameters.AddWithValue("@tl", numericUpDown3.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                tatlılar();
                MessageBox.Show("BAŞARILI", "UYARI");
            }


        }
    }
}
