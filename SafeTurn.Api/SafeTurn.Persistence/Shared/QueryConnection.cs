using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SafeTurn.Persistence.Shared
{
    public class QueryConnection
    {
        protected SqlConnection Connection;

        public QueryConnection(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }


    }
}
