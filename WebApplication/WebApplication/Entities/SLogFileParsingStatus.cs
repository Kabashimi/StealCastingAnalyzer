using System;

#nullable disable

namespace da_service.Entities
{
    public partial class SLogFileParsingStatus
    {
        public int LogFileParsingStatusId { get; set; }
        public DateTime ParsingEventTime { get; set; }
        public TimeSpan ParsingEventInterval { get; set; }
        public string FilePath { get; set; }
        public string StatusDescription { get; set; }
        public int StatusType { get; set; }
    }
}
