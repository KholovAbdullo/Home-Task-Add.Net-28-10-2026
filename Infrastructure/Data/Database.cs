using Npgsql;

namespace Infrastructure.Data;

public class Database
{
    private string connectionString = "Host=localhost;Port=5432;Database=Practs;Username=postgres;Password=1234";
    public NpgsqlConnection Connection() => new NpgsqlConnection(connectionString);
}
