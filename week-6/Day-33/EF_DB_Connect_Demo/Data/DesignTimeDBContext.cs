using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using EF_DB_Connect_Demo.Modules;

namespace EF_DB_Connect_Demo.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TrainingContext>
    {
        public TrainingContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var conn = config.GetConnectionString("Default") ??
                       "Data Source = LAPTOP - 6IO1N8R8\\SQLEXPRESS02; Initial Catalog = EF_Demo; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate = True; Application Intent = ReadWrite; Multi Subnet Failover = False";

            var options = new DbContextOptionsBuilder<TrainingContext>()
                .UseSqlServer(conn)
                .Options;

            return new TrainingContext(options);

        }
    }
}