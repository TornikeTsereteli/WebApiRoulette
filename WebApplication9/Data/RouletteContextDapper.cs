using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using RoulleteGame;
using WebApplication9.Model;

namespace WebApplication9;

public class RouletteContextDapper
{
    private readonly IConfiguration _configuration;

    public RouletteContextDapper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public RPlayer GetPlayer(string userName)
    {
        using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("RouletteConnection"));
        // Ensure the query parameter is passed as an anonymous object or a Dictionary
        var parameters = new { arg1 = userName };

        // Use QueryFirstOrDefault to get a single result or null if not found
        return dbConnection.QueryFirstOrDefault<RPlayer>("SELECT * FROM RoulettePlayer WHERE UserName = @arg1 ", parameters);
    }

    public IEnumerable<RPlayer> GetPlayers()
    {
        using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("RouletteConnection"));
        return dbConnection.Query<RPlayer>("SELECT PlayerId, UserName, Balance FROM RoulettePlayer;");
    }

    public bool InsertPlayer(string userName,Decimal balance)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("RouletteConnection"));
        var player = new RPlayer()
        {
            Username = userName,
            Balance = balance,
            CreatedAt = DateTime.Now
        };
        // Exception could Be thrown
        try
        {
            connection.Execute(
                "INSERT INTO RoulettePlayer (Username, Balance, CreatedAt) VALUES (@Username, @Balance, @CreatedAt)",
                player);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool UpdatePlayerBalance(string userName, decimal balance)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("RouletteConnection"));
        var player = new RPlayer()
        {
            Username = userName,
            Balance = balance,
            CreatedAt = DateTime.Now
        };
        // Exception could Be thrown
        try
        {
            connection.Execute(@"
            UPDATE RoulettePlayer
            SET Balance = @Balance, CreatedAt = @CreatedAt
            WHERE Username = @Username;
        ", player);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }





}