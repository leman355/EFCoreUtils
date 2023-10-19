namespace EFCoreUtils.Entities
{
    public class Musician
    {
        public int MusicianId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MusicianRole { get; set; }
        public bool IsDeleted { get; set; }
        public int MusicBandId { get; set; }
        public MusicBand MusicBand { get; set; }
    }
}
