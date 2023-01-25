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
    public class KontrahentConfiguration : IEntityTypeConfiguration<Kontrahent>
    {
        public void Configure(EntityTypeBuilder<Kontrahent> builder)
        {
            builder.Property(x => x.NazwaFirmy).HasMaxLength(32).IsRequired();// mozemy nie ustawiać długości znaków, wtedy nvarchar(max)
            builder.Property(x => x.Ulica).HasMaxLength(32).IsRequired(false);
            builder.Property(x => x.NumerBudynku).HasMaxLength(5).IsRequired(false);
            builder.Property(x => x.NumerLokalu).HasMaxLength(10).IsRequired(false);
            builder.Property(x => x.Nip).HasMaxLength(10).IsRequired(false);
        }
    }
}
