using System.Security.Principal;

namespace Jashter.Shared.Dto.Response
{
    public class QuestionResponseDto
    {
        public long CorrectWordId { get; set; }
        public long CorrectMeaningOfWordId { get; set; }
        public long LevelId { get; set; }
        public long PartOfSpeechId { get; set; }
        public IEnumerable<QuestionChoice> Choices { get; set; } = Enumerable.Empty<QuestionChoice>();
        public class QuestionChoice
        {
            public long WordId { get; set; }
            public long MeaningOfWordId { get; set; }
            public string Meaning { get; set; } = null!;
        }
    }
}
