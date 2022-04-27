using Microsoft.Extensions.Configuration;

namespace ECommercenet6.Persistence;

static class Configuration
{
   static  public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                "../../Presentation/ECommercenet6.WebApi"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("PostgreSql");
        }
    }
}