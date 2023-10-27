namespace Jashter.Shared.Dto
{
    public class PartOfSpeechResponseDto
    {
        public long ID { get; set; }
        public string Name { get; set; } = null!;
        public string InJapanese { get; set; } = null!;
    }
}