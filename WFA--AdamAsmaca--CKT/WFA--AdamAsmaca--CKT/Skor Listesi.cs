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
    public partial class Skor_Listesi : Form
    {
        OyunEkranı oyunEkranı;
        public Skor_Listesi(OyunEkranı oyunEkranı)
        {
            InitializeComponent();
            this.oyunEkranı = oyunEkranı;
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Skor_Listesi_Load(object sender, EventArgs e)
        {            
            AddSkorList();
        }
        public void AddSkorList()
        {
            int winCount = oyunEkranı.WinCount;
            string kullaniciAdi = oyunEkranı.KullaniciAdi2;
            if (winCount> int.Parse(label4.Text))
            {
                label3.Text = kullaniciAdi;
                label4.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label6.Text))
            {
                label5.Text = kullaniciAdi;
                label6.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label8.Text))
            {
                label7.Text = kullaniciAdi;
                label8.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label10.Text))
            {
                label9.Text = kullaniciAdi;
                label10.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label12.Text))
            {
                label11.Text = kullaniciAdi;
                label12.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label14.Text))
            {
                label13.Text = kullaniciAdi;
                label14.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label16.Text))
            {
                label15.Text = kullaniciAdi;
                label16.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label8.Text))
            {
                label7.Text = kullaniciAdi;
                label8.Text = winCount.ToString();
            }
            else if (winCount > int.Parse(label20.Text))
            {
                label19.Text = kullaniciAdi;
                label20.Text = winCount.ToString();
            }


        }
    }
}
