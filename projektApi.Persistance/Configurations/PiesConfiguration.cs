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
    public class PiesConfiguration : IEntityTypeConfiguration<Pies>
    {
        public void Configure(EntityTypeBuilder<Pies> builder)
        {
            builder.HasKey(x => x.Id); //jeśli inne pole jest PK, tu wskazujemy
            builder.Property(x => x.Name).HasMaxLength(70).IsRequired();// mozemy nie ustawiać długości znaków, wtedy nvarchar(max)
        }
    }
}
