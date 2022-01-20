using System;

namespace da_service.Utils
{
    public class HeatTempDiff
    {
        public int HeatId { get; set; }
        public int HeatNumber { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public DateTime HeatStartTime { get; set; }
        public float StartTemp { get; set; }
        public float TempDiff { get; set; }
        public TimeSpan TimeDiff { get; set; }
        public double TimeDiffSeconds { get; set; }
        public double HeatWeight { get; set; }
        public int LadleNumber { get; set; }
        public int HeatsInLadle { get; set; }

        public HeatTempDiff(int heatId, int heatNumber, int gradeId, string gradeName, DateTime heatStartTime, float startTemp, float tempDiff, TimeSpan timeDiff, double timeDiffSeconds, double heatWeight, int ladleNumber, int heatsInLadle)
        {
            HeatId = heatId;
            HeatNumber = heatNumber;
            GradeId = gradeId;
            GradeName = gradeName;
            HeatStartTime = heatStartTime;
            StartTemp = startTemp;
            TempDiff = tempDiff;
            TimeDiff = timeDiff;
            TimeDiffSeconds = timeDiffSeconds;
            HeatWeight = heatWeight;
            LadleNumber = ladleNumber;
            HeatsInLadle = heatsInLadle;
        }

        public HeatTempDiff(int heatId)
        {
            HeatId = heatId;
            GradeId = 0;
            GradeName = "";
            HeatStartTime = new DateTime();
            StartTemp = 0;
            TempDiff = 0;
            TimeDiff = new TimeSpan();
            TimeDiffSeconds = 0;
            LadleNumber = 0;
            HeatsInLadle = 0;
        }
    }
}