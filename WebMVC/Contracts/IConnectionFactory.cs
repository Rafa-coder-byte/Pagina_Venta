// En el proyecto Contracts/Interfaces
using Microsoft.Data.SqlClient;

namespace Contracts
{
    public interface IConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}

