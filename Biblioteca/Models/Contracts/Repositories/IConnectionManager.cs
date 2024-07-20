using System.Data.SqlClient;

namespace Biblioteca.Models.Contracts.Repositories
{
    public interface IConnectionManager
    {
        SqlConnection GetConnection();
    }
}
