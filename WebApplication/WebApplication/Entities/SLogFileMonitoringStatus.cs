using System;

#nullable disable

namespace da_service.Entities
{
    public partial class SLogFileMonitoringStatus
    {
        public int LogFileMonitoringStatusId { get; set; }
        public DateTime MonitoringEventTime { get; set; }
        public TimeSpan MonitoringEventInterval { get; set; }
        public int FilesFound { get; set; }
        public int FilesAddedWithSuccess { get; set; }
        public int FilesAddedWithWarning { get; set; }
        public int FilesAddedWithError { get; set; }
        public string StatusDescription { get; set; }
    }
}
