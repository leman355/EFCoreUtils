using EFCoreUtils.Business.DTO.MusicBandDtos;

namespace EFCoreUtils.Business.DTO.MusicianDtos
{
    public record MusicianToListDto
    {
        public int MusicianId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MusicianRole { get; set; }
        public ShortMusicBandToListDto MusicBand { get; set; }
    }
}
