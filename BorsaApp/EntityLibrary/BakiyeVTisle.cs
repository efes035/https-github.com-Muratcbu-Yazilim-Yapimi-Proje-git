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
    public class BakiyeVTisle
    {
        public bool BakiyeEkle(Bakiye bakiye)
        {
            bool result = false;
            //MessageBox.Show("TC no: " + kisi.Tcno);
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_bakiyeEkle @KisiID, @Bakiye, @DovizCinsi", baglanti);
                command.Parameters.Add(new SqlParameter("KisiID", bakiye.KisiID));
                command.Parameters.Add(new SqlParameter("Bakiye", bakiye.Bakiyepara));
                command.Parameters.Add(new SqlParameter("DovizCinsi", bakiye.Dovizcinsi));
                baglanti.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                baglanti.Close();
            }
            return result;
        }

        public static decimal ToplamBakiyeGoster(Bakiye bakiye)
        {
            decimal toplam = 0;
            using (var baglanti = Database.Baglan())
            {
                baglanti.Open();
                using (var cmd = new SqlCommand("SELECT dbo.f_ToplamBakiye(@kisiID,@DovizCinsi)", baglanti))
                {
                    cmd.Parameters.AddWithValue("@kisiID", bakiye.KisiID);
                    cmd.Parameters.AddWithValue("@DovizCinsi", bakiye.Dovizcinsi);
                    if(cmd.ExecuteScalar()!=DBNull.Value)
                        toplam =(decimal) cmd.ExecuteScalar();
                }
                baglanti.Close();
            }
            return toplam;
        }

        public static DataTable BakiyeOnayOnizleme()
        {
            DataTable dt = new DataTable();
            var baglanti = Database.Baglan();
            string command = "SELECT * FROM vw_BakiyeOnay ORDER BY OnayDurumu ASC, Tarih ASC";
            SqlDataAdapter dataadap = new SqlDataAdapter(command, baglanti);
            dataadap.Fill(dt);
            baglanti.Close();
            return dt;
        }

        public static DataTable KullaniciAdinaGoreBakiyeArama(string kullaniciadi)
        {
            DataTable dt = new DataTable();
            var baglanti = Database.Baglan();
            string command = "SELECT * FROM dbo.f_KullaniciAdinaGoreBakiyeAra('"+kullaniciadi+"') ORDER BY OnayDurumu ASC, Tarih ASC";
            SqlDataAdapter dataadap = new SqlDataAdapter(command, baglanti);
            dataadap.Fill(dt);
            baglanti.Close();
            return dt;
        }

        public bool BakiyeOnayla(Bakiye bakiye)
        {
            bool result = false;
            //MessageBox.Show("TC no: " + kisi.Tcno);
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_bakiyeOnayla @BakiyeID,@OnayDurumu", baglanti);
                command.Parameters.Add(new SqlParameter("BakiyeID", bakiye.BakiyeID));
                command.Parameters.Add(new SqlParameter("OnayDurumu", bakiye.OnayDurumu));
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
