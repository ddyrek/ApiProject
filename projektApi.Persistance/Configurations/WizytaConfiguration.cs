using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projektApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektApi.Persistance.Configurations
{
    public class WizytaConfiguration : IEntityTypeConfiguration<Wizyta>
    {
        public void Configure(EntityTypeBuilder<Wizyta> builder)
        {
            builder.Property(x => x.Opis).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Kwota).HasPrecision(8).HasMaxLength(2).IsRequired(false);
        }
    }
}
