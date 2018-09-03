using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBVideo
{
    public class DBconnectie
    {
        private static ConnectionStringSettings conVideoSetting = ConfigurationManager.ConnectionStrings["videoAdo"];

        private static DbProviderFactory factory =
            DbProviderFactories.GetFactory(conVideoSetting.ProviderName);



        public DbConnection GetConnection()
        {
            var connection = factory.CreateConnection();
            connection.ConnectionString = conVideoSetting.ConnectionString;
            return connection;
        }
    }
}
