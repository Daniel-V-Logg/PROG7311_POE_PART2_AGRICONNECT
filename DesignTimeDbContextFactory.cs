using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using AgriEnergyConnect.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=agrienergy.db");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
