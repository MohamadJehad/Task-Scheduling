using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.DataGeneration
{
    /// <summary>
    /// Provides standard test instances of varying sizes for algorithm evaluation
    /// </summary>
    public static class TestInstances
    {
        /// <summary>
        /// Creates a small test instance (suitable for brute force)
        /// </summary>
        public static ProblemInstance Small(string name = "Small", int seed = 42)
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "TA1", IsAvailable = true },
                new TAInfo { Name = "TA2", IsAvailable = true },
                new TAInfo { Name = "TA3", IsAvailable = true }
            };

            var tasks = new List<TaskInfo>
            {
                new TaskInfo
                {
                    Name = "Task1",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 15 },
                        { "TA2", 20 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task2",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 25 },
                        { "TA3", 18 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task3",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 30 },
                        { "TA3", 22 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task4",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 12 },
                        { "TA2", 16 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task5",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 28 },
                        { "TA3", 24 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task6",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 19 },
                        { "TA3", 15 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task7",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 22 },
                        { "TA2", 18 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task8",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 14 },
                        { "TA3", 20 }
                    }
                }
            };

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Small test instance: 8 tasks, 3 TAs"
            };
        }

        /// <summary>
        /// Creates a small test instance variant (balanced eligibility)
        /// </summary>
        public static ProblemInstance SmallVariant1(string name = "Small-V1", int seed = 42)
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "TA1", IsAvailable = true },
                new TAInfo { Name = "TA2", IsAvailable = true },
                new TAInfo { Name = "TA3", IsAvailable = true }
            };

            var tasks = new List<TaskInfo>
            {
                new TaskInfo
                {
                    Name = "Task1",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 10 },
                        { "TA2", 15 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task2",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 12 },
                        { "TA3", 10 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task3",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 18 },
                        { "TA3", 14 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task4",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 16 },
                        { "TA2", 13 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task5",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 11 },
                        { "TA3", 9 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task6",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 20 },
                        { "TA3", 17 }
                    }
                }
            };

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Small variant 1: 6 tasks, 3 TAs (balanced)"
            };
        }

        /// <summary>
        /// Creates a small test instance variant (constrained)
        /// </summary>
        public static ProblemInstance SmallVariant2(string name = "Small-V2", int seed = 42)
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "TA1", IsAvailable = true },
                new TAInfo { Name = "TA2", IsAvailable = true },
                new TAInfo { Name = "TA3", IsAvailable = true }
            };

            var tasks = new List<TaskInfo>
            {
                new TaskInfo
                {
                    Name = "Task1",
                    EligibleTAs = new List<TAInfo> { tas[0] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 25 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task2",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 20 },
                        { "TA2", 15 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task3",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 12 },
                        { "TA3", 18 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task4",
                    EligibleTAs = new List<TAInfo> { tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA3", 22 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task5",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 14 },
                        { "TA2", 16 },
                        { "TA3", 13 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task6",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 19 },
                        { "TA3", 21 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task7",
                    EligibleTAs = new List<TAInfo> { tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 17 }
                    }
                }
            };

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Small variant 2: 7 tasks, 3 TAs (highly constrained)"
            };
        }

        /// <summary>
        /// Creates a medium test instance
        /// </summary>
        public static ProblemInstance Medium(string name = "Medium", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(name => new TAInfo { Name = name, IsAvailable = true }).ToList();

            // Create 30 predefined tasks with varying eligibility patterns
            for (int i = 1; i <= 30; i++)
            {
                var eligibleTAs = new List<TAInfo>();
                var processingTimes = new Dictionary<string, int>();

                // Distribute tasks across TAs in a balanced way
                switch (i % 5)
                {
                    case 0:
                        eligibleTAs = new List<TAInfo> { tas[0], tas[1], tas[2] };
                        processingTimes = new Dictionary<string, int> { { "TA1", 20 + i }, { "TA2", 25 + i }, { "TA3", 18 + i } };
                        break;
                    case 1:
                        eligibleTAs = new List<TAInfo> { tas[1], tas[2], tas[3] };
                        processingTimes = new Dictionary<string, int> { { "TA2", 30 + i }, { "TA3", 22 + i }, { "TA4", 28 + i } };
                        break;
                    case 2:
                        eligibleTAs = new List<TAInfo> { tas[2], tas[3], tas[4] };
                        processingTimes = new Dictionary<string, int> { { "TA3", 15 + i }, { "TA4", 20 + i }, { "TA5", 25 + i } };
                        break;
                    case 3:
                        eligibleTAs = new List<TAInfo> { tas[0], tas[3], tas[4] };
                        processingTimes = new Dictionary<string, int> { { "TA1", 35 + i }, { "TA4", 30 + i }, { "TA5", 28 + i } };
                        break;
                    case 4:
                        eligibleTAs = new List<TAInfo> { tas[0], tas[1] };
                        processingTimes = new Dictionary<string, int> { { "TA1", 40 + i }, { "TA2", 38 + i } };
                        break;
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
                Description = "Medium test instance: 30 tasks, 5 TAs"
            };
        }

        /// <summary>
        /// Creates a large test instance
        /// </summary>
        public static ProblemInstance Large(string name = "Large", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8", "TA9", "TA10" };
            var tas = taNames.Select(name => new TAInfo { Name = name, IsAvailable = true }).ToList();

            // Create 100 predefined tasks with varying eligibility patterns
            for (int i = 1; i <= 100; i++)
            {
                var eligibleTAs = new List<TAInfo>();
                var processingTimes = new Dictionary<string, int>();

                // Create different patterns of eligibility
                int pattern = i % 10;
                int baseTime = 50 + (i % 30);

                switch (pattern)
                {
                    case 0:
                        eligibleTAs = new List<TAInfo> { tas[0], tas[1], tas[2], tas[3] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA1", baseTime + 10 }, { "TA2", baseTime + 15 }, 
                            { "TA3", baseTime + 5 }, { "TA4", baseTime + 20 } 
                        };
                        break;
                    case 1:
                        eligibleTAs = new List<TAInfo> { tas[1], tas[2], tas[4] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA2", baseTime + 12 }, { "TA3", baseTime + 8 }, 
                            { "TA5", baseTime + 18 } 
                        };
                        break;
                    case 2:
                        eligibleTAs = new List<TAInfo> { tas[3], tas[5], tas[6], tas[7] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA4", baseTime + 25 }, { "TA6", baseTime + 15 }, 
                            { "TA7", baseTime + 10 }, { "TA8", baseTime + 20 } 
                        };
                        break;
                    case 3:
                        eligibleTAs = new List<TAInfo> { tas[0], tas[4], tas[8] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA1", baseTime + 30 }, { "TA5", baseTime + 22 }, 
                            { "TA9", baseTime + 18 } 
                        };
                        break;
                    case 4:
                        eligibleTAs = new List<TAInfo> { tas[2], tas[6], tas[9] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA3", baseTime + 14 }, { "TA7", baseTime + 16 }, 
                            { "TA10", baseTime + 12 } 
                        };
                        break;
                    case 5:
                        eligibleTAs = new List<TAInfo> { tas[1], tas[3], tas[5], tas[7], tas[9] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA2", baseTime + 35 }, { "TA4", baseTime + 28 }, 
                            { "TA6", baseTime + 30 }, { "TA8", baseTime + 25 }, 
                            { "TA10", baseTime + 32 } 
                        };
                        break;
                    case 6:
                        eligibleTAs = new List<TAInfo> { tas[0], tas[2], tas[4], tas[6], tas[8] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA1", baseTime + 20 }, { "TA3", baseTime + 18 }, 
                            { "TA5", baseTime + 22 }, { "TA7", baseTime + 15 }, 
                            { "TA9", baseTime + 25 } 
                        };
                        break;
                    case 7:
                        eligibleTAs = new List<TAInfo> { tas[4], tas[5], tas[6] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA5", baseTime + 40 }, { "TA6", baseTime + 38 }, 
                            { "TA7", baseTime + 35 } 
                        };
                        break;
                    case 8:
                        eligibleTAs = new List<TAInfo> { tas[7], tas[8], tas[9] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA8", baseTime + 28 }, { "TA9", baseTime + 32 }, 
                            { "TA10", baseTime + 30 } 
                        };
                        break;
                    case 9:
                        eligibleTAs = new List<TAInfo> { tas[0], tas[3], tas[6], tas[9] };
                        processingTimes = new Dictionary<string, int> { 
                            { "TA1", baseTime + 45 }, { "TA4", baseTime + 40 }, 
                            { "TA7", baseTime + 42 }, { "TA10", baseTime + 38 } 
                        };
                        break;
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
                Description = "Large test instance: 100 tasks, 10 TAs"
            };
        }
    }
}
