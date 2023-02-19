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
    public partial class OyunEkranı : Form
    {
        public int Süre;
        public string KullaniciAdi2;
        public int Count;
        public int WinCount = 0;
        public int FalseCount = 0;
        string[] kelimeler = { "ARABA", "BUZDOLABI", "AYAKKABI", "TELEVİZYON", "BİLGİSAYAR", "ROKETATAR", "TÜFEK" };

        List<Turn> turns = new List<Turn>();
        Turn currentTurn = null;
        public Form MainForm = null;
        
        public OyunEkranı()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OyunEkranı_Load(object sender, EventArgs e)
        {
            Süre = 120;
            label3.Text = $"Kullanıcı Adı = {KullaniciAdi2}";
            NewGame();
        }

        private void NewGame()
        {
            if (currentTurn != null)
            {
                turns.Add(currentTurn);
                List<Control> removedControls = new List<Control>();
                removedControls.AddRange(GetLabelsByName("lblLetter"));
                removedControls.AddRange(GetLabelsByName("MatchedLetter"));

                foreach (Control ctrl in removedControls)
                {
                    Controls.Remove(ctrl);
                }
                FalseCount = 0;
            }
            
            Count = 0;
            Turn newTurn = new Turn();

            newTurn.Word = KelimeOluştur(kelimeler);

            currentTurn = newTurn;


            for (int i = 0; i < currentTurn.Word.Length; i++)
            {
                Label lbl = new Label();
                lbl.Text = "_";
                lbl.Font = new Font("Calibr", 21, FontStyle.Bold);
                lbl.Height = 40;
                lbl.Width = 50;
                lbl.Location = new Point(((i + 1) * lbl.Width) + 50, 250);
                lbl.Name = "lblLetter" + i;
                Controls.Add(lbl);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();

            Control[] ctrls = GetLabelsByName("lblLetter");

            int currentCount = Count;
            for (int i = 1; i < currentTurn.Word.Length + 1; i++)
            {
                Control lbl = ctrls[i - 1];
                if (txtHarf.Text.ToUpper() == currentTurn.Word[i - 1].ToString())
                {
                    Label lblHarf = new Label();
                    lblHarf.Text = currentTurn.Word[i - 1].ToString();
                    lblHarf.Location = new Point(lbl.Location.X, lbl.Location.Y - 35);
                    lblHarf.Height = 50;
                    lblHarf.Width = lbl.Width;
                    lblHarf.Font = lbl.Font;
                    lblHarf.Name = "MatchedLetter" + i;
                    Controls.Add(lblHarf);
                    Count++;
                }                              
                
            }
            if (Count==currentCount)
            {
                FalseCount++;
                if (FalseCount==5)
                {
                    LostGame();
                }
            }            
            else if (Count == currentTurn.Word.Length)
            {
                WinGame();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Süre--;
            label1.Text = $"Kalan Süre = {Süre}";
            
            if (Süre == 0)
            {
                LostGame();

            }

        }

        private void LostGame()
        {
            timer1.Stop();
            Skor_Listesi skorListesi = new Skor_Listesi(this);            
            skorListesi.AddSkorList();            
            DialogResult dr = MessageBox.Show($"Tebrikler {WinCount} adet kelime bildiniz Tekrar oynamak İster misiniz.", "Tebrikler.", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                turns.Clear();
                WinCount = 0;
                Süre = 120;
                NewGame();
            }
            else
            {               
                this.MainForm.Show();
                this.Close();
            }
        }

       

        private void WinGame()
        {
            currentTurn.Success = true;
            lblWinCount.Text = (++WinCount).ToString();                     
            NewGame();
            
        }

        private Control[] GetLabelsByName(string name)
        {
            List<Control> controls = new List<Control>();

            foreach (Control control in Controls)
            {
                if (control is Label lbl && lbl.Name.StartsWith(name))
                    controls.Add(control);

            }

            return controls.ToArray();
        }

        static string KelimeOluştur(string[] kelimeler)
        {
            int kelimeNo = new Random().Next(0, kelimeler.Length);
            string kelimeHarfler = kelimeler[kelimeNo];

            return kelimeHarfler;

        }
        
    }
}
