using System;

namespace da_service.Utils
{
    public class HeatTempDiff
    {
        public int HeatId { get; set; }
        public int GradeId { get; set; }
        public DateTime HeatStartTime { get; set; }
        public float StartTemp { get; set; }
        public float TempDiff { get; set; }
        public TimeSpan TimeDiff { get; set; }

        public HeatTempDiff(int heatId, int gradeId, DateTime heatStartTime, float startTemp, float tempDiff, TimeSpan timeDiff)
        {
            HeatId = heatId;
            GradeId = gradeId;
            HeatStartTime = heatStartTime;
            StartTemp = startTemp;
            TempDiff = tempDiff;
            TimeDiff = timeDiff;
        }

        public HeatTempDiff(int heatId)
        {
            HeatId = heatId;
            GradeId = 0;
            HeatStartTime = new DateTime();
            StartTemp = 0;
            TempDiff = 0;
            TimeDiff = new TimeSpan();
        }
    }
}