// En el proyecto Contracts/Interfaces
using Microsoft.Data.SqlClient;

namespace ContractsDatos
{
    public interface IConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}

