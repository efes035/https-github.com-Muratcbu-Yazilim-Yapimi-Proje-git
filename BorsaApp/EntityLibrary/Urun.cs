using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public int OlcuBirimiID { get; set; }
        public string Aciklama { get; set; }
        public Urun()
        {

        }
        public Urun(int urunid, string urunad, int olcubirimiid, string aciklama)
        {
            this.UrunID = urunid;
            this.UrunAd = urunad;
            this.OlcuBirimiID = olcubirimiid;
            this.Aciklama = aciklama;
        }
    }
    
}
