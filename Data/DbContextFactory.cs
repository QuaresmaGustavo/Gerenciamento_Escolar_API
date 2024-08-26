using API_APSNET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Configure a string de conexão
        optionsBuilder.UseMySql("Server=Localhost;Database=db_aspnet;User=root;Password=;",
                                new MySqlServerVersion(new Version(8, 0, 21)));

        return new AppDbContext(optionsBuilder.Options);
    }
}
