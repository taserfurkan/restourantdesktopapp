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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


       

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(yonetici.Checked)
            {
                string user = kullanıcıadı.Text;
                string pass = sifre.Text;
                con = new SqlConnection(@"Data Source=DESKTOP-MJG0QFS;Initial Catalog=restorantapp;Integrated Security=True");
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;




                cmd.CommandText = "SELECT * FROM yoneticigiris where kullanıcıadı='" + kullanıcıadı.Text + "' AND sifre='" + sifre.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(" Giriş Başarılı", "UYARI");
                    Form2 form2 = new Form2();
                    form2.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.", "UYARI");
                }


                con.Close();
            }

            else if(isci.Checked)
            {
                string user = kullanıcıadı.Text;
                string pass = sifre.Text;
                con = new SqlConnection(@"Data Source=DESKTOP-MJG0QFS;Initial Catalog=restorantapp;Integrated Security=True");
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;



                cmd.CommandText = "SELECT * FROM iscigiris where ıd='" + kullanıcıadı.Text + "' AND _sıfre='" + sifre.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(" Giriş Başarılı", "UYARI");
                    Form3 form3 = new Form3();
                    form3.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.", "UYARI");
                }


                con.Close();
            }

            else
            {
                MessageBox.Show("Lütfen durumunuzu seçiniz");
            }
        }
    }
}
