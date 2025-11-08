using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Scheduling.Entities
{
    public class TaskInfo
    {
        public string Name { get; set; } = string.Empty;
        public List<string> EligibleTAs { get; set; } = new();
        public Dictionary<string, int> ProcessingTimes { get; set; } = new(); // p_{i,t}
    }
}
