using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    // configuring connection to SqlServer and database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = new SqlConnectionStringBuilder()
        {
            DataSource = "localhost",
            InitialCatalog = "master",
            TrustServerCertificate = true,
            IntegratedSecurity = true,
            Encrypt = false,
        }.ConnectionString;

        optionsBuilder.UseSqlServer(connection,
            options => { options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null); });
    }
}