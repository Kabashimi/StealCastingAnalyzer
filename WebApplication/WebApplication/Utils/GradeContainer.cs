using System;
using System.Collections.Generic;

namespace da_service.Utils
{
    public class GradeContainer
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public List<HeatTempDiff> Heats { get; set; }

        public GradeContainer(int id, string name)
        {
            GradeId = id;
            GradeName = name;
            Heats = new List<HeatTempDiff>();
        }
    }
}