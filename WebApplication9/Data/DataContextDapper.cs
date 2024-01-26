using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WebApplication9;

public class DataContextDapper
{
    private readonly IConfiguration _config;
    public DataContextDapper(IConfiguration config)
    {
        _config = config;
    }

    public IEnumerable<T> LoadData<T>(string sql)
    {
        IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return connection.Query<T>(sql);
    }
    
    public T LoadSingle<T>(string sql)
    {
        IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return connection.QuerySingle<T>(sql);
    }
    
    



    
}