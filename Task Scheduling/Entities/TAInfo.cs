using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Scheduling.Entities
{
    public class TAInfo
    {
        public string Name { get; set; } = string.Empty;
        public int MaxCapacity { get; set; } = int.MaxValue; // Maximum workload capacity (optional constraint)
        public List<string> Skills { get; set; } = new(); // Optional: skills or specializations
        public bool IsAvailable { get; set; } = true; // Availability status
    }
}


