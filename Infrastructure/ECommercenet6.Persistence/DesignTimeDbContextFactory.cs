using ECommercenet6.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ECommercenet6.Persistence;

public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<ECommercenet6ApiDbContext>
{
    public ECommercenet6ApiDbContext CreateDbContext(string[] args)
    {



        DbContextOptionsBuilder<ECommercenet6ApiDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
        return new ECommercenet6ApiDbContext(dbContextOptionsBuilder.Options);
    }
}