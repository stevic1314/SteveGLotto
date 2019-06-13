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

        public DbSet<SteveGLotto.Models.EuroNumbers> tblEuroNumbers { get; set; }
        public DbSet<SteveGLotto.Models.LottoNumbers> tblLottoNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EuroNumbers>().ToTable("tblEuroNumbers");
            modelBuilder.Entity<LottoNumbers>().ToTable("tblLottoNumbers");
        }
    }
}
