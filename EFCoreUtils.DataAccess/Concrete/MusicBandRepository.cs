using Microsoft.EntityFrameworkCore;
using EFCoreUtils.DataAccess.Abstract;
using EFCoreUtils.Entities;

namespace EFCoreUtils.DataAccess.Concrete
{
    public class MusicBandRepository : IMusicBandRepository
    {
        private readonly AppDbContext _context;

        public MusicBandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MusicBand>> GetAllMusicBands()
        {
            return await _context.MusicBands
                .Include(m=>m.Musicians)
                .ToListAsync();
        }

        public async Task<MusicBand> GetMusicBandById(int musicBandId)
        {
            return await _context.MusicBands
                .Include(m => m.Musicians)
                .Where(mb => mb.MusicBandId == musicBandId)
                .FirstOrDefaultAsync();
        }

        public async Task<MusicBand> CreateMusicBand(MusicBand musicBand)
        {
            _context.MusicBands.Add(musicBand);
            await _context.SaveChangesAsync();
            return musicBand;
        }

        public async Task<MusicBand> UpdateMusicBand(MusicBand musicBand)
        {
            _context.MusicBands.Update(musicBand);
            await _context.SaveChangesAsync();
            return musicBand;
        }

        public async Task DeleteMusicBandById(int musicBandId)
        {
            var musicBand = await _context.MusicBands.FindAsync(musicBandId);
            if (musicBand != null)
            {
                musicBand.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MusicBand> GetMusiciansByMusicBandId(int musicBandId)
        {
            return await _context.MusicBands
                .Include(mb => mb.Musicians)
                .Where(mb => mb.MusicBandId == musicBandId)
                .FirstOrDefaultAsync();
        }
    }
}
