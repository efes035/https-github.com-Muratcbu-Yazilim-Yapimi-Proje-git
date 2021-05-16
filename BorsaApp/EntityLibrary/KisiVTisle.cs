using DataLibrary;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace EntityLibrary
{
    public class KisiVTisle
    {
        public bool KisiEkle(Kisi kisi)
        {
            bool result = false;
            //MessageBox.Show("TC no: " + kisi.Tcno);
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_kisiEkle @Tcno, @Ad, @Soyad, @Kullaniciad, @parola, @telefon, @eposta, @adres", baglanti);
                command.Parameters.Add(new SqlParameter("Tcno",kisi.Tcno));
                command.Parameters.Add(new SqlParameter("Ad", kisi.Ad));
                command.Parameters.Add(new SqlParameter("Soyad", kisi.Soyad));
                command.Parameters.Add(new SqlParameter("Kullaniciad", kisi.KullaniciAd));
                command.Parameters.Add(new SqlParameter("parola", kisi.Parola));
                command.Parameters.Add(new SqlParameter("Telefon", kisi.Telefon));
                command.Parameters.Add(new SqlParameter("eposta", kisi.Eposta));
                command.Parameters.Add(new SqlParameter("adres", kisi.Adres));
                baglanti.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                baglanti.Close();
            }
            return result;
        }
        
        public Kisi KisiAl(string kullaniciAd, string parola)
        {
            Kisi kisi = null;
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_kisiAl @kullaniciAd,@parola", baglanti);
                command.Parameters.Add(new SqlParameter("kullaniciAd", kullaniciAd));
                command.Parameters.Add(new SqlParameter("parola", parola));
                baglanti.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kisi = new Kisi();
                        kisi.KisiID = reader.GetInt32(0); //id
                        kisi.Tcno = reader.GetString(1);   //Tcno
                        kisi.Ad = reader.GetString(2); //gerçek isim
                        kisi.Soyad = reader.GetString(3);//soy isim
                        kisi.KullaniciAd = reader.GetString(4);//kullaniciAd
                        kisi.Parola = reader.GetString(5); //parola
                        kisi.Telefon = reader.GetString(6);//telefon
                        kisi.Eposta = reader.GetString(7);//eposta
                        kisi.Adres = reader.GetString(8);//adres
                        kisi.Yetki = reader.GetInt32(9);//yetki
                        kisi.Aktif = reader.GetInt32(10);//0 ise aktfi hesap, 1 ise pasif hesap
                    }
                }
                baglanti.Close();
            }
            return kisi;
        }
        
        private bool Containskisi(Kisi kisi)
        {
            bool result = false;
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("SELECT *FROM kisis WHERE kullaniciAd='" + kisi.KullaniciAd+ "' and parola='" + kisi.Parola + "'");
                command.Connection = baglanti;
                baglanti.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                baglanti.Close();
            }
            return result;
        }
  
        public bool KisiGuncelle(Kisi kisi)
        {
            bool result = false;
            using (var baglanti = Database.Baglan())
            {
                var command = new SqlCommand("sp_kisis_Update @id,@kullaniciAd,@parola", baglanti);
                command.Parameters.Add(new SqlParameter("id", kisi.KisiID));
                command.Parameters.Add(new SqlParameter("kullaniciAd", kisi.KullaniciAd));
                command.Parameters.Add(new SqlParameter("parola", kisi.Parola));

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
