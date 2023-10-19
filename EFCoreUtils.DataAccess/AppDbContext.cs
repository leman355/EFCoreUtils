using EFCoreUtils.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreUtils.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<MusicBand> MusicBands { get; set; }
        public DbSet<Musician> Musicians { get; set; }
    }
}
