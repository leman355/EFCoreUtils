using EFCoreUtils.Business.DTO.MusicianDtos;

namespace EFCoreUtils.Business.DTO.MusicBandDtos
{
    public record MusicBandToListDto
    {
        public int MusicBandId { get; set; }
        public string Name { get; set; }
        public List<ShortMusicianToListDto> Musicians {  get; set; }
    }
}
