using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLibrary;
using BusinessLibrary;

namespace Borsa
{
    public partial class frmUyeol : Form
    {
        public frmUyeol()
        {
            InitializeComponent();
        }
        public Kisi kisi;
        KisiElle uyeIslem;
        private void btnUyeol_Click(object sender, EventArgs e)
        {
            uyeIslem = new KisiElle();
            kisi = new Kisi();
            if(
                txtTc.Text is null 
                || string.IsNullOrWhiteSpace(txtTc.Text) 
                || string.IsNullOrWhiteSpace(txtAdi.Text) 
                //|| txtAd.Text.Trim().Length<1
                || txtSoyadi.Text is null || txtSoyadi.Text.Trim().Length < 1
                || txtKullaniciAdi.Text is null || txtKullaniciAdi.Text.Trim().Length < 1
                || txtParola.Text is null || txtParola.Text.Trim().Length < 1
                || txtTelefon.Text is null || txtTelefon.Text.Trim().Length < 1 
                || txtEposta.Text is null || txtEposta.Text.Trim().Length < 1
                || txtAdres.Text is null || txtAdres.Text.Trim().Length < 1 
                )
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz...!");
                txtTc.Focus();
            }
            else
            {
                kisi.Tcno = txtTc.Text;
                kisi.Ad = txtAdi.Text;
                kisi.Soyad = txtSoyadi.Text;
                kisi.KullaniciAd = txtKullaniciAdi.Text;
                kisi.Parola = txtParola.Text;
                kisi.Telefon = txtTelefon.Text;
                kisi.Eposta = txtEposta.Text;
                kisi.Adres = txtAdres.Text;

                if (uyeIslem.KisiEkle(kisi))
                {
                    MessageBox.Show("Üyelik işlemi başarılı...!");                    
                }
                else
                    MessageBox.Show("Kayıt başarılı olamadı...!\n" +
                        "Telefon veya Adres alanı dışında hiç bir alanı boş bırakmayınız...!\n" +
                        "TCno veya KullanıcıAdı veya Eposta daha önceden kullanılmış...!");
            }
        }

        private void txtTc_Validating(object sender, CancelEventArgs e)
        {   
            if (txtTc.Text.Trim().Length<1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtTc.Select(0, txtTc.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtTc, "Tc alanı boş geçilemez...!");
            }
        }

        private void txtAdi_Validating(object sender, CancelEventArgs e)
        {
            if (txtAdi.Text.Trim().Length < 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtAdi.Select(0, txtAdi.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtAdi, "Ad alanı boş geçilemez...!");
            }
        }

        private void txtSoyadi_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoyadi.Text.Trim().Length < 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtSoyadi.Select(0, txtSoyadi.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtSoyadi, "Soyad alanı boş geçilemez...!");
            }
        }

        private void txtKullaniciAdi_Validating(object sender, CancelEventArgs e)
        {
            if (txtKullaniciAdi.Text.Trim().Length < 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtKullaniciAdi.Select(0, txtKullaniciAdi.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtKullaniciAdi, "Kullanıcı Adı alanı boş geçilemez...!");
            }
        }

        private void txtParola_Validating(object sender, CancelEventArgs e)
        {
            if (txtParola.Text.Trim().Length < 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtParola.Select(0, txtParola.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtParola, "Parola alanı boş geçilemez...!");
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (txtTelefon.Text.Trim().Length < 1)
            //string.IsNullOrWhiteSpace(txtTelefon.Text)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtTelefon.Select(0, txtTelefon.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtTelefon, "Telefon alanı boş geçilemez...!");
            }
        }

        private void txtEposta_Validating(object sender, CancelEventArgs e)
        {
            if (txtEposta.Text.Trim().Length < 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtEposta.Select(0, txtEposta.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtEposta, "Eposta alanı boş geçilemez...!");
            }
        }

        private void txtAdres_Validating(object sender, CancelEventArgs e)
        {
            if (txtAdres.Text.Trim().Length < 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtAdres.Select(0, txtAdres.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                errorProvider1.SetError(txtAdres, "Adres alanı boş geçilemez...!");
            }
        }
    }
}
