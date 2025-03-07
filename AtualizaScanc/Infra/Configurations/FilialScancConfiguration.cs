using AtualizaScanc.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtualizaScanc.Infra.Configurations
{
    public class FilialScancConfiguration : IEntityTypeConfiguration<FilialScanc>
    {
        public void Configure(EntityTypeBuilder<FilialScanc> builder)
        {
            builder.ToTable("Filiais");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).HasColumnType("INTEGER").IsRequired();
            builder.Property(f => f.Name).HasColumnType("VARCHAR(100)");
            builder.Property(f => f.PathInstall).HasColumnType("VARCHAR(100)");
        }

    }


}
