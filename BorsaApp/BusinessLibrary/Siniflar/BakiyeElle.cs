using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary;

namespace BusinessLibrary
{
    public class BakiyeElle
    {
        private BakiyeVTisle context = new BakiyeVTisle();
        public bool BakiyeEkle(Bakiye bakiye)
        {
            bool result = false;
            if (context.BakiyeEkle(bakiye))
            {
                result = true;
            }
            return result;
        }

        public bool BakiyeOnayla(Bakiye bakiye)
        {
            bool result = false;
            if (context.BakiyeOnayla(bakiye))
            {
                result = true;
            }
            return result;
        }
    }
}
