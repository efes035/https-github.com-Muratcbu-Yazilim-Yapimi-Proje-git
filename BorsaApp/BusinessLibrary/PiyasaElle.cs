using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary;

namespace BusinessLibrary
{
    public class PiyasaElle
    {
           private PiyasaVTisle context = new PiyasaVTisle();
           public bool PiyasaEkle(Piyasa piyasa)
           {
               bool result = false;
               if (context.PiyasaEkle(piyasa))
               {
                   result = true;
               }
               return result;
           }

           public bool PiyasaOnayla(Piyasa piyasa)
           {
               bool result = false;
               if (context.PiyasaOnayla(piyasa))
               {
                   result = true;
               }
               return result;
           }
    }
}
