namespace EFCoreUtils.Business.DTO.MusicianDtos
{
    public record MusicianToAddDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string MusicianRole { get; set; }
        public int MusicBandId { get; set; }
    }
}
