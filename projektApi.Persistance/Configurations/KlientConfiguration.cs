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
    public class KlientConfiguration : IEntityTypeConfiguration<Klient>
    {
        public void Configure(EntityTypeBuilder<Klient> builder)
        {
            //HasColumnName - wykorzystujemy też gdy chcemy zmapować pola na nazwy wałsne np. gdy podejście DBFirst
            //ValeObject
            builder.OwnsOne(p => p.KlientName).Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.OwnsOne(p => p.KlientName).Property(p => p.Surname).HasColumnName("Surname").IsRequired();
        }
    }
}
