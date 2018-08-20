using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectie
{
    public class DBTuincerntrum
    {

        private static ConnectionStringSettings conBierenSetting =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];

        private static DbProviderFactory factory =
            DbProviderFactories.GetFactory(conBierenSetting.ProviderName);



        public DbConnection GetConnection()
        {
            var conBieren = factory.CreateConnection();
            conBieren.ConnectionString = conBierenSetting.ConnectionString;
            return conBieren;
        }



        

    }
}
