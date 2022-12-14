using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday.Migrations.Factories
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        MigrationDbContext IDesignTimeDbContextFactory<MigrationDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MigrationDbContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключаения из файла appsettings.json
            string connectionString = config.GetConnectionString("ApplicationConnection");
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new MigrationDbContext(optionsBuilder.Options);
        }
    }
}
