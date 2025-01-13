

using Microsoft.Extensions.Configuration;

namespace COMB.SpaParking.Persistence;
static class Configuration
{
    static Configuration()
    {
        Properties = new PropertiesContainer();
    }   

    public static void Load(IConfiguration configuration)
    {
        // Load from file
        var _namespace = typeof(Configuration).Namespace ?? throw new ArgumentNullException();
        var section = configuration.GetSection(_namespace);
        var connectionString= section["ConnectionString:DefaultConnection"] ?? throw new ArgumentNullException();
        Properties.ConnectionString = connectionString;
    }

    public static PropertiesContainer Properties { get; internal set; }

    public enum SqlEngine { SqlServer, InMemory }
    public sealed class PropertiesContainer
    {
        public SqlEngine SqlEngine { get; set; } = SqlEngine.SqlServer;
        public string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=COMBParkingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}   


