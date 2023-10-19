using EFCoreUtils.Business.DTO.MusicianDtos;

namespace EFCoreUtils.Business.Abstract
{
    public interface IMusicianService
    {
        Task<List<MusicianToListDto>> GetAllMusicians();
        Task<MusicianToListDto> GetMusicianById(int musicianId);
        Task<MusicianToAddDto> CreateMusician(MusicianToAddDto musician);
        Task<MusicianToUpdateDto> UpdateMusician(int musicianId, MusicianToUpdateDto musician);
        Task DeleteMusicianById(int musicianId);
        Task<List<MusicianToListDto>> GetMusicBandByMusicianId(int musicianId);
        //IQueryable
        IQueryable<MusicianToListDto> GetAllMusiciansQuery();
        IQueryable<MusicianToListDto> GetMusicBandByMusicianIdQuery(int musicianId);
    }
}