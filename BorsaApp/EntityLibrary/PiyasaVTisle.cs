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
    public class PiyasaVTisle
    {
        public bool PiyasaEkle(Piyasa piyasa)
        {
            bool result = false;
            //MessageBox.Show("TC no: " + kisi.Tcno);
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_piyasaEkle @KisiID, @UrunID, @Fiyat, @DovizID, @Miktar", baglanti);
                command.Parameters.Add(new SqlParameter("KisiID", piyasa.KisiID));
                command.Parameters.Add(new SqlParameter("UrunID", piyasa.UrunID));
                command.Parameters.Add(new SqlParameter("Fiyat", piyasa.Fiyat));
                command.Parameters.Add(new SqlParameter("DovizID", piyasa.DovizID));
                command.Parameters.Add(new SqlParameter("Miktar", piyasa.Miktar));
                baglanti.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                baglanti.Close();
            }
            return result;
        }

        public static decimal ToplamPiyasaGoster(Piyasa piyasa)
        {
            decimal toplam = 0;
            using (var baglanti = Database.Baglan())
            {
                baglanti.Open();
                using (var cmd = new SqlCommand("SELECT dbo.f_ToplamPiyasa(@kisiID,@DovizCinsi)", baglanti))
                {
                    cmd.Parameters.AddWithValue("@kisiID", piyasa.KisiID);
                    cmd.Parameters.AddWithValue("@DovizCinsi", piyasa.DovizID);
                    if(cmd.ExecuteScalar()!=DBNull.Value)
                        toplam =(decimal) cmd.ExecuteScalar();
                }
                baglanti.Close();
            }
            return toplam;
        }

        public static DataTable PiyasaOnayOnizleme()
        {
            DataTable dt = new DataTable();
            var baglanti = Database.Baglan();
            string command = "SELECT * FROM vw_PiyasaOnay ORDER BY OnayDurumu ASC, Tarih ASC";
            SqlDataAdapter dataadap = new SqlDataAdapter(command, baglanti);
            dataadap.Fill(dt);
            baglanti.Close();
            return dt;
        }

        public static DataTable KullaniciAdinaGorePiyasaArama(string kullaniciadi)
        {
            DataTable dt = new DataTable();
            var baglanti = Database.Baglan();
            string command = "SELECT * FROM dbo.f_KullaniciAdinaGorePiyasaAra('"+kullaniciadi+"') ORDER BY OnayDurumu ASC, Tarih ASC";
            SqlDataAdapter dataadap = new SqlDataAdapter(command, baglanti);
            dataadap.Fill(dt);
            baglanti.Close();
            return dt;
        }

        public bool PiyasaOnayla(Piyasa piyasa)
        {
            bool result = false;
            //MessageBox.Show("TC no: " + kisi.Tcno);
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_piyasaOnayla @PiyasaID,@OnayDurumu", baglanti);
                command.Parameters.Add(new SqlParameter("PiyasaID", piyasa.PiyasaID));
                command.Parameters.Add(new SqlParameter("OnayDurumu", piyasa.Onaydurumu));
                baglanti.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                baglanti.Close();
            }
            return result;
        }
    }
}
