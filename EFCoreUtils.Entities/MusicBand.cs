namespace EFCoreUtils.Entities
{
    public class MusicBand
    {
        public int MusicBandId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Musician> Musicians { get; set; }
    }
}
