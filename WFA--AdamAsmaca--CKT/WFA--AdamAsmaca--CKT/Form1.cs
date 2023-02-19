using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA__AdamAsmaca__CKT
{
    public partial class AnaEkran : Form
    {
        OyunEkranı oyunEkranı = new OyunEkranı();
        public AnaEkran()
        {
            InitializeComponent();
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            oyunEkranı.KullaniciAdi2 = txtOyuncuAdi.Text;
            if (oyunEkranı.KullaniciAdi2 =="")
            {
                MessageBox.Show("Lütfen geçerli bir kullanıcı adı giriniz.");
                txtOyuncuAdi.Text = "";
            }
            else 
            {
                oyunEkranı.Show();
                oyunEkranı.MainForm = this;
                this.Hide();

            }
        }

        private void btnSkorListesi_Click(object sender, EventArgs e)
        {
            Skor_Listesi SkorListesi = new Skor_Listesi(oyunEkranı);
            SkorListesi.Show();
            this.Hide();
        }
    }
}
