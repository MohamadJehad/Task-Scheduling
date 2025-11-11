using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.DataGeneration
{
    /// <summary>
    /// Provides special problem instances with specific characteristics for algorithm analysis
    /// </summary>
    public static class SpecialInstances
    {
        /// <summary>
        /// Creates a worst-case instance where all tasks are eligible for all TAs
        /// This creates the maximum search space for brute force algorithms
        /// </summary>
        public static ProblemInstance WorstCase(string name = "WorstCase", int numTasks = 10, int numTAs = 3)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            
            for (int i = 1; i <= numTAs; i++)
            {
                taNames.Add($"TA{i}");
            }

            var tas = taNames.Select(name => new TAInfo { Name = name }).ToList();

            // All tasks are eligible for all TAs
            for (int i = 1; i <= numTasks; i++)
            {
                var processingTimes = new Dictionary<string, int>();
                int baseTime = 30 + (i * 5);
                
                foreach (var ta in taNames)
                {
                    processingTimes[ta] = baseTime + (i % 3) * 10;
                }

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = new List<TAInfo>(tas),
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = $"Worst-case instance: {numTasks} tasks, {numTAs} TAs (all tasks eligible for all TAs)"
            };
        }

        /// <summary>
        /// Creates a highly constrained instance where each task has minimal eligible TAs
        /// This tests algorithms under high constraint scenarios
        /// </summary>
        public static ProblemInstance Constrained(string name = "Constrained", int numTasks = 20, int numTAs = 5)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            
            for (int i = 1; i <= numTAs; i++)
            {
                taNames.Add($"TA{i}");
            }

            var tas = taNames.Select(name => new TAInfo { Name = name }).ToList();

            // Each task has 1-2 eligible TAs
            for (int i = 1; i <= numTasks; i++)
            {
                var eligibleTAs = new List<TAInfo>();
                var processingTimes = new Dictionary<string, int>();
                
                // Select 1 or 2 TAs in a round-robin fashion
                string ta1 = taNames[i % numTAs];
                eligibleTAs.Add(tas[i % numTAs]);
                processingTimes[ta1] = 40 + (i * 3);
                
                if (i % 2 == 0 && numTAs > 1)
                {
                    string ta2 = taNames[(i + 1) % numTAs];
                    eligibleTAs.Add(tas[(i + 1) % numTAs]);
                    processingTimes[ta2] = 45 + (i * 2);
                }

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = eligibleTAs,
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = $"Constrained instance: {numTasks} tasks, {numTAs} TAs (1-2 eligible TAs per task)"
            };
        }

        /// <summary>
        /// Creates a balanced instance with uniform task distribution across TAs
        /// This tests load balancing capabilities of algorithms
        /// </summary>
        public static ProblemInstance Balanced(string name = "Balanced", int numTasks = 50, int numTAs = 8)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            
            for (int i = 1; i <= numTAs; i++)
            {
                taNames.Add($"TA{i}");
            }

            var tas = taNames.Select(name => new TAInfo { Name = name }).ToList();
            
            // Create tasks where each TA is eligible for approximately the same number of tasks
            for (int i = 0; i < numTasks; i++)
            {
                // Make each task eligible for 2-3 TAs in a round-robin fashion
                var eligibleTAs = new List<TAInfo>
                {
                    tas[i % numTAs],
                    tas[(i + 1) % numTAs]
                };

                if (i % 3 == 0 && numTAs > 2)
                {
                    eligibleTAs.Add(tas[(i + 2) % numTAs]);
                }

                int baseDuration = 35 + (i % 20);
                var processingTimes = new Dictionary<string, int>();
                
                int offset = 0;
                foreach (var ta in eligibleTAs)
                {
                    processingTimes[ta.Name] = baseDuration + offset;
                    offset += 5;
                }

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i + 1}",
                    EligibleTAs = eligibleTAs,
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = $"Balanced instance: {numTasks} tasks, {numTAs} TAs (uniform distribution)"
            };
        }
    }
}
