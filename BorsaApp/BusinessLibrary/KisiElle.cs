using System;
using EntityLibrary;


namespace BusinessLibrary
{
    public class KisiElle
    {
        private KisiVTisle context = new KisiVTisle();

        public Kisi KisiAl(string kullaniciAd, string parola)
        {
            return context.KisiAl(kullaniciAd,parola);
        }

        public bool KisiEkle(Kisi kisi)
        {
            bool result = false;
            Kisi value = context.KisiAl(kisi.KullaniciAd, kisi.Parola);
            if (value == null)
            {
                result = context.KisiEkle(kisi);
            }
            return result;
        }

        public bool KisiGuncelle(Kisi kisi)
        {
            return context.KisiGuncelle(kisi);
        }
    }
}

