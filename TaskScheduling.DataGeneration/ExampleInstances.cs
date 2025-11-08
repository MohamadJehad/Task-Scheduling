using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.DataGeneration
{
    /// <summary>
    /// Provides academic and example problem instances from papers and documentation
    /// </summary>
    public static class ExampleInstances
    {
        /// <summary>
        /// Creates the example from the LaTeX document (Section 3)
        /// </summary>
        public static ProblemInstance LaTeXExample()
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "A1", IsAvailable = true },
                new TAInfo { Name = "A2", IsAvailable = true },
                new TAInfo { Name = "A3", IsAvailable = true }
            };

            var tasks = new List<TaskInfo>
            {
                new TaskInfo
                {
                    Name = "A",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "A1", 10 },
                        { "A3", 7 }
                    }
                },
                new TaskInfo
                {
                    Name = "B",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "A2", 8 },
                        { "A3", 12 }
                    }
                }
            };

            return new ProblemInstance
            {
                Name = "LaTeX Example",
                Tasks = tasks,
                TAs = tas,
                Description = "Example from LaTeX document (Section 3) - 2 tasks, 3 TAs"
            };
        }
    }
}
