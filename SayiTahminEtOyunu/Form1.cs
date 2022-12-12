using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahminEtOyunu
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int _RandomNumber;
        int _ClickCount = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 60;
            btnGuess.Enabled = false;
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            timer1.Start();
            _RandomNumber = rnd.Next(1,101);
            progressBar1.Value = progressBar1.Maximum;
            btnGuess.Enabled = true;
            lblInformation.Text = string.Empty;
            lblMessage.Text = string.Empty;

        }


        private void btnGuess_Click(object sender, EventArgs e)
        {
            int _TimeElapsed = Math.Abs(progressBar1.Value-60);
            int _Number = 0;
            _ClickCount++;

                try
            {
                _Number = int.Parse(txtInputNumber.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Sayı girmeyi unuttunuz ya da hatalı giriş yaptınız.");
            }
            lblInformation.Text = _Number.ToString();
            if (_RandomNumber > _Number)
            {
                lblInformation.Text += "=> küçük sayı girdiniz.";
            }
            else if (_RandomNumber < _Number)
            {
                lblInformation.Text += "=> büyük sayı girdiniz.";
            }

            else 
            {

                lblInformation.Text += $"TEBRİKLER BİLDİNİZ.";
                lblMessage.Text += _ClickCount + ". tahminde ve " + _TimeElapsed.ToString() + ".sn'ye de bildiniz.";
                timer1.Stop();
                btnGuess.Enabled = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value--;
        }
    }
}
