using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SteveGLotto.Models
{
    public class SteveGLottoContext : DbContext
    {
        public SteveGLottoContext (DbContextOptions<SteveGLottoContext> options)
            : base(options)
        {
        }

        public DbSet<SteveGLotto.Models.EuroDrawNumbers> tblEuroDrawNumbers { get; set; }
        public DbSet<SteveGLotto.Models.EuroLSNumbers> tblEuroLSNumbers { get; set; }
        public DbSet<SteveGLotto.Models.LottoDrawNumbers> tblLottoDrawNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EuroDrawNumbers>().ToTable("tblEuroDrawNumbers");
            modelBuilder.Entity<EuroLSNumbers>().ToTable("tblEuroLSNumbers");
            modelBuilder.Entity<LottoDrawNumbers>().ToTable("tblLottoDrawNumbers");
        }
    }
}
