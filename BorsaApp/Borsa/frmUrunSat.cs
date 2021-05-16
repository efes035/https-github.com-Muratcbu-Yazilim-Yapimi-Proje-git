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
    public partial class frmUrunSat : Form
    {
        int _kisiID;
        public frmUrunSat(int kisiID)
        {
            InitializeComponent();
            _kisiID = kisiID;
        }
        DataTable dataTable = new();
        DataTable dataTableUrun = new();
        Urun urun;
        UrunElle urunislem;
        Piyasa piyasa;
        PiyasaElle piyasaislem;

        private void btnMalekle_Click(object sender, EventArgs e)
        { 
            try
            {
                urun = new Urun();
                //piyasa = new Piyasa();
                urunislem = new UrunElle();
                piyasaislem = new PiyasaElle();
                piyasa.KisiID = _kisiID;
                piyasa.UrunID = Convert.ToInt32(cmbUrun.SelectedValue);
                piyasa.Fiyat = Convert.ToDecimal(txtFiyat.Text);
                piyasa.DovizID = Convert.ToInt32(cmbDoviz.SelectedValue);
                piyasa.Miktar=Convert.ToDouble(txtMiktar.Text);
                if (piyasaislem.PiyasaEkle(piyasa))
                {
                    MessageBox.Show("Yeni ürün eklendi! Onay bekliyor...!");
                }
            }
            catch
            {
                MessageBox.Show("Yeni ürün eklenemedi!\n" +
                    "Ürüm miktarı veya Fiyat girerken sadece rakam kullanınız!");
            }
        }

        private void frmUrunSat_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Aktif kullanıcı ID= " + _kisiID.ToString());
            cmbDovizDoldur();
            cmbUrunDoldur();
            piyasa = new Piyasa
            {
                KisiID = _kisiID,
                DovizID = Convert.ToInt32(cmbDoviz.SelectedValue),
                UrunID = Convert.ToInt32(cmbUrun.SelectedValue)
            };
            //txtMevcutpara.Text = BakiyeVTisle.ToplamBakiyeGoster(bakiye).ToString();
        }
        private void cmbUrunDoldur ()
        {
            dataTableUrun = UrunVTisle.UrunAl();
            cmbUrun.ValueMember = dataTableUrun.Columns[0].ToString();
            cmbUrun.DisplayMember = dataTableUrun.Columns[1].ToString();
            cmbUrun.DataSource = dataTableUrun;
        }
        private void cmbDovizDoldur()
        {
            dataTable = DovizVTisle.DovizAl();
            cmbDoviz.ValueMember = dataTable.Columns[0].ToString();
            cmbDoviz.DisplayMember = dataTable.Columns[1].ToString();
            cmbDoviz.DataSource = dataTable;
        }
    }
}
