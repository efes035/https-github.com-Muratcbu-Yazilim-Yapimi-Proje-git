/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Configuration;
using System.Data.SqlClient;
//using System.Data;


namespace DataLibrary
{
    public class Database
    {
        private static Database instance = null;
        

        // Ayrı thread'lerde tekrar nesne oluşmasını önlemek için oluşturuldu.
        private static readonly object padlock = new object();

        // Nesneyi dışarıdan oluşturulmaya kapattık.
        private Database() { }

        public static Database CreateInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Database();
                    }

                    return instance;
                }
            }
        }

        
        public static SqlConnection Baglan()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["BorsaVTBaglantiStr"].ConnectionString);
        }
    }
}
