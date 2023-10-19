using Microsoft.EntityFrameworkCore;
using EFCoreUtils.DataAccess.Abstract;
using EFCoreUtils.Entities;

namespace EFCoreUtils.DataAccess.Concrete
{
    public class MusicianRepository : IMusicianRepository
    {
        private readonly AppDbContext _context;

        public MusicianRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Musician>> GetAllMusicians()
        {
            //AsNoTracking
            return await _context.Musicians
                .Include(m => m.MusicBand)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Musician> GetMusicianById(int musicianId)
        {
            return await _context.Musicians
                .Where(m => m.MusicianId == musicianId)
                .FirstOrDefaultAsync();
        }

        public async Task<Musician> CreateMusician(Musician musician)
        {
            //_context.Musicians.Add(musician);

            //State
            _context.Entry(musician).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return musician;
        }

        public async Task<Musician> UpdateMusician(Musician musician)
        {
            //_context.Musicians.Update(musician);

            //State
            _context.Musicians.Attach(musician);
            _context.Entry(musician).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return musician;
        }

        public async Task DeleteMusicianById(int musicianId)
        {
            var musician = await _context.Musicians.FindAsync(musicianId);
            if (musician != null)
            {
                musician.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Musician>> GetMusicBandByMusicianId(int musicianId)
        {
            return await _context.Musicians
                .Include(m => m.MusicBand)
                .Where(m => m.MusicianId == musicianId)
                .ToListAsync();
        }
    }
}
