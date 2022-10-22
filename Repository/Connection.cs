
using Microsoft.AspNetCore.Connections;
using System.Data.SqlClient;

namespace HOLACODERCLASE14APIS.Repository
{
    public class Connection
    {
        public static string connectionString()
        {

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "NIKITODEVSS1";
            conecctionbuilder.InitialCatalog = "SistemaGestion1";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            return (cs);
        }



    }
}
