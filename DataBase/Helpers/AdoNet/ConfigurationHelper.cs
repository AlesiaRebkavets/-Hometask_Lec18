using Microsoft.Extensions.Configuration;

namespace DataBase;

public static class ConfigurationHelper
{
    public static IConfiguration Configuration;

    public static string LocalDbConnectionString { get; set; }

    // method configures connection to SQL Server for further usage in ADO.NET helper
    static ConfigurationHelper()
    {
        Configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
        SetValues();
    }

    // setting values using connection string from "config.json" file
    public static void SetValues()
    {
        LocalDbConnectionString = Configuration.GetConnectionString("adonetdb");
    }
}