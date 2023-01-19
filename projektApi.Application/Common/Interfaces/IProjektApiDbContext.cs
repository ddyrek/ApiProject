using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projektApi.Domain.Entities;

namespace projektApi.Application.Common.Interfaces
{
    public interface IProjektApiDbContext
    {
        DbSet<Pies> Psy { get; set; }
        DbSet<Kontrahent> Kontrahenci { get; set; }
        DbSet<Klient> Klienci { get; set; }
        DbSet<Wizyta> Wizyty { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
