namespace EFCoreUtils.Business.DTO.MusicianDtos
{
    public record ShortMusicianToListDto
    {
        public int MusicianId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MusicianRole { get; set; }
    }
}
