using AtualizaScanc.Domain;
using AtualizaScanc.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualizaScanc.Infra
{
    internal class FilialScancContext : DbContext
    {
        public DbSet<FilialScanc> FiliaisScanc { get; set; }

        public string DbPath { get; }

        public FilialScancContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "scancfiliais.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilialScancContext).Assembly);
            modelBuilder.ApplyConfiguration(new FilialScancConfiguration());
        }

    }
}
