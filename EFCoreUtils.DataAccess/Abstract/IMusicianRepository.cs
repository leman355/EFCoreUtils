using EFCoreUtils.Entities;

namespace EFCoreUtils.DataAccess.Abstract
{
    public interface IMusicianRepository
    {
        Task<List<Musician>> GetAllMusicians();
        Task<Musician> GetMusicianById(int musicianId);
        Task<Musician> CreateMusician(Musician musician);
        Task<Musician> UpdateMusician(Musician musician);
        Task DeleteMusicianById(int musicianId);
        Task<List<Musician>> GetMusicBandByMusicianId(int musicianId);
        //IQueryable
        IQueryable<Musician> GetAllMusiciansQuery();
        IQueryable<Musician> GetMusicBandByMusicianIdQuery(int musicianId);
    }
}
