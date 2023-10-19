using EFCoreUtils.Business.DTO.MusicBandDtos;

namespace EFCoreUtils.Business.Abstract
{
    public interface IMusicBandService
    {
        Task<List<MusicBandToListDto>> GetAllMusicBands();
        Task<MusicBandToListDto> GetMusicBandById(int musicBandId);
        Task<MusicBandToAddDto> CreateMusicBand(MusicBandToAddDto musicBand);
        Task<MusicBandToUpdateDto> UpdateMusicBand(MusicBandToUpdateDto musicBand);
        Task DeleteMusicBandById(int musicBandId);
        Task<MusicBandToListDto> GetMusiciansByMusicBandId(int musicBandId);
    }
}