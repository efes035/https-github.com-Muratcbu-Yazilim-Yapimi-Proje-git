using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using System.Data.SqlClient;
using System.Data;

namespace EntityLibrary
{
    public class UrunVTisle
    {
        public bool UrunEkle(Urun urun)
        {
            bool result = false;
            //MessageBox.Show("TC no: " + kisi.Tcno);
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_urunEkle @UrunAd, @OlcuBirimi, @Aciklama", baglanti);
                command.Parameters.Add(new SqlParameter("UrunAd", urun.UrunAd));
                command.Parameters.Add(new SqlParameter("OlcuBirim", urun.OlcuBirimiID));
                command.Parameters.Add(new SqlParameter("Aciklama", urun.Aciklama));
                baglanti.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                baglanti.Close();
            }
            return result;
        }

        public static decimal ToplamUrunGoster(Urun urun)
        {
            decimal toplam = 0;
            using (var baglanti = Database.Baglan())
            {
                baglanti.Open();
                using (var cmd = new SqlCommand("SELECT dbo.f_ToplamUrun(@UrunID)", baglanti))
                {
                    cmd.Parameters.AddWithValue("@kisiID", urun.UrunID);
                    if(cmd.ExecuteScalar()!=DBNull.Value)
                        toplam =(decimal) cmd.ExecuteScalar();
                }
                baglanti.Close();
            }
            return toplam;
        }

        public static DataTable UrunOnayOnizleme()
        {
            DataTable dt = new DataTable();
            var baglanti = Database.Baglan();
            string command = "SELECT * FROM vw_UrunOnay ORDER BY OnayDurumu ASC, Tarih ASC";
            SqlDataAdapter dataadap = new SqlDataAdapter(command, baglanti);
            dataadap.Fill(dt);
            baglanti.Close();
            return dt;
        }

        public static DataTable KullaniciAdinaGoreUrunArama(string kullaniciadi)
        {
            DataTable dt = new DataTable();
            var baglanti = Database.Baglan();
            string command = "SELECT * FROM dbo.f_KullaniciAdinaGoreUrunAra('"+kullaniciadi+"') ORDER BY OnayDurumu ASC, Tarih ASC";
            SqlDataAdapter dataadap = new SqlDataAdapter(command, baglanti);
            dataadap.Fill(dt);
            baglanti.Close();
            return dt;
        }

        public static DataTable UrunAl()
        {
            DataTable dt = new DataTable();
            var baglanti = Database.Baglan();
            string command = "SELECT UrunID, UrunAd FROM tblUrunler";
            SqlDataAdapter dataadap = new SqlDataAdapter(command, baglanti);
            dataadap.Fill(dt);
            baglanti.Close();
            return dt;
        }
        /*public bool UrunOnayla(Urun urun)
        {
            bool result = false;
            //MessageBox.Show("TC no: " + kisi.Tcno);
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_urunOnayla @UrunID,@OnayDurumu", baglanti);
                command.Parameters.Add(new SqlParameter("UrunID", urun.UrunID));
                command.Parameters.Add(new SqlParameter("OnayDurumu", urun.));
                baglanti.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                baglanti.Close();
            }
            return result;
        } */
    }
}
