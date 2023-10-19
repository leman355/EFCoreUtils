using EFCoreUtils.Entities;


namespace EFCoreUtils.DataAccess.Abstract
{
    public interface IMusicBandRepository
    {
        Task<List<MusicBand>> GetAllMusicBands();
        Task<MusicBand> GetMusicBandById(int musicBandId);
        Task<MusicBand> CreateMusicBand(MusicBand musicBand);
        Task<MusicBand> UpdateMusicBand(MusicBand musicBand);
        Task DeleteMusicBandById(int musicBandId);
        Task<MusicBand> GetMusiciansByMusicBandId(int musicBandId);
    }
}
