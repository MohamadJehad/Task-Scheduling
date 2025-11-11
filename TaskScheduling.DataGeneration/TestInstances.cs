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
        /// Creates the example from the LaTeX document (Section 3)
        /// </summary>
        public static ProblemInstance Small_0(string name = "small_0", int seed = 42)
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "A1" },
                new TAInfo { Name = "A2" },
                new TAInfo { Name = "A3" }
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
                        { "A3", 10 }
                    }
                },
                new TaskInfo
                {
                    Name = "B",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "A2", 10 },
                        { "A3", 10 }
                    }
                }
            };

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Example from LaTeX document (Section 3) - 2 tasks, 3 TAs"
            };
        }

        /// <summary>
        /// Creates a small test instance (suitable for brute force)
        /// </summary>
        public static ProblemInstance Small_1(string name = "small_1", int seed = 42)
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "TA1" },
                new TAInfo { Name = "TA2" },
                new TAInfo { Name = "TA3" }
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
                        { "TA2", 15 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task2",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 20 },
                        { "TA3", 20 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task3",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 25 },
                        { "TA3", 25 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task4",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 14 },
                        { "TA2", 14 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task5",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 26 },
                        { "TA3", 26 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task6",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 17 },
                        { "TA3", 17 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task7",
                    EligibleTAs = new List<TAInfo> { tas[0], tas[1] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA1", 20 },
                        { "TA2", 20 }
                    }
                },
                new TaskInfo
                {
                    Name = "Task8",
                    EligibleTAs = new List<TAInfo> { tas[1], tas[2] },
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { "TA2", 17 },
                        { "TA3", 17 }
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
        /// Creates a small-medium test instance (suitable for brute force, ~50K-100K combinations)
        /// </summary>
        public static ProblemInstance Small_4(string name = "small_4", int seed = 42)
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "TA1" },
                new TAInfo { Name = "TA2" },
                new TAInfo { Name = "TA3" },
                new TAInfo { Name = "TA4" }
            };
            var tasks = new List<TaskInfo>();

            // 10 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 10; i++)
            {
                int ta1Index = (i % 4);
                int ta2Index = ((i + 1) % 4);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 20 + (i * 3);
                
                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Small-medium static instance: 10 tasks, 4 TAs (mix of 2-3 eligible TAs per task)"
            };
        }

        /// <summary>
        /// Creates a larger small test instance (suitable for brute force, ~500K-800K combinations)
        /// </summary>
        public static ProblemInstance Small_5(string name = "small_5", int seed = 42)
        {
            var tas = new List<TAInfo>
            {
                new TAInfo { Name = "TA1" },
                new TAInfo { Name = "TA2" },
                new TAInfo { Name = "TA3" },
                new TAInfo { Name = "TA4" }
            };
            var tasks = new List<TaskInfo>();

            // 15 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 15; i++)
            {
                int ta1Index = (i % 4);
                int ta2Index = ((i + 1) % 4);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + (i * 2);
                
                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Large-small static instance: 15 tasks, 4 TAs (mostly 2 eligible TAs per task, some with 3)"
            };
        }

        /// <summary>
        /// Creates a dataset designed to make TA constraint count sorting matter
        /// Multiple TAs will have identical processing times, forcing the constraint count tie-breaker to be used
        /// </summary>
        public static ProblemInstance Small_6(string name = "small_6", int numTasks = 15, int numTAs = 5)
        {
            var tasks = new List<TaskInfo>();
            var tas = new List<TAInfo>();
            
            for (int i = 1; i <= numTAs; i++)
            {
                tas.Add(new TAInfo { Name = $"TA{i}" });
            }

            // All tasks: exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= numTasks; i++)
            {
                // Use round-robin to pair TAs
                int ta1Index = (i - 1) % numTAs;
                int ta2Index = (i % numTAs);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + (i % 20); // Vary processing time slightly

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = $"TA sorting matters instance: {numTasks} tasks, {numTAs} TAs (designed with identical processing times to force constraint count tie-breaking)"
            };
        }

        /// <summary>
        /// Creates a worst-case instance where all tasks are eligible for all TAs
        /// This creates the maximum search space for brute force algorithms
        /// </summary>
        public static ProblemInstance Small_2(string name = "small_2", int numTasks = 10, int numTAs = 3)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            
            for (int i = 1; i <= numTAs; i++)
            {
                taNames.Add($"TA{i}");
            }

            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // All tasks: exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= numTasks; i++)
            {
                // Use round-robin to pair TAs
                int ta1Index = (i - 1) % numTAs;
                int ta2Index = (i % numTAs);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + (i * 5);

                var processingTimes = new Dictionary<string, int>
                {
                    { taNames[ta1Index], processingTime },
                    { taNames[ta2Index], processingTime }
                };

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
                Description = $"Worst-case instance: {numTasks} tasks, {numTAs} TAs (all tasks eligible for all TAs)"
            };
        }

        /// <summary>
        /// Creates a worst-case instance variant (10 tasks, 3 TAs)
        /// </summary>
        public static ProblemInstance Small_7(string name = "small_7", int numTasks = 10, int numTAs = 3)
        {
            return Small_2(name, numTasks, numTAs);
        }

        /// <summary>
        /// Creates a worst-case instance variant (15 tasks, 5 TAs)
        /// </summary>
        public static ProblemInstance Small_8(string name = "small_8", int numTasks = 15, int numTAs = 5)
        {
            return Small_2(name, numTasks, numTAs);
        }

        /// <summary>
        /// Creates a small test instance with 12 tasks and 4 TAs
        /// </summary>
        public static ProblemInstance Small_9(string name = "small_9", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 15 + (i * 2);

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Small test instance: 12 tasks, 4 TAs"
            };
        }

        /// <summary>
        /// Creates a small test instance with 9 tasks and 3 TAs using random pairs
        /// </summary>
        public static ProblemInstance Small_10(string name = "small_10", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 9; i++)
            {
                // Randomly select 2 different TAs
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 18 + random.Next(1, 25); // Processing time between 18-42

                var processingTimes = new Dictionary<string, int>
                {
                    { selectedTAs[0].Name, processingTime },
                    { selectedTAs[1].Name, processingTime }
                };

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Small test instance: 9 tasks, 3 TAs (random pairs)"
            };
        }

        /// <summary>
        /// Creates a small test instance with 11 tasks and 5 TAs
        /// </summary>
        public static ProblemInstance Small_11(string name = "small_11", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 20 + (i % 20);

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Small test instance: 11 tasks, 5 TAs"
            };
        }

        /// <summary>
        /// Creates a small test instance with 13 tasks and 4 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Small_12(string name = "small_12", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with sequential TA pairs
            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = (ta1Index + 1 + (i / 5) % 3) % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 22 + (i % 18);

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Small test instance: 13 tasks, 4 TAs (sequential pairs)"
            };
        }

        /// <summary>
        /// Creates a small test instance with 10 tasks and 6 TAs
        /// </summary>
        public static ProblemInstance Small_13(string name = "small_13", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with random TA pairs
            for (int i = 1; i <= 10; i++)
            {
                // Randomly select 2 different TAs
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 25 + random.Next(1, 21); // Processing time between 25-45

                var processingTimes = new Dictionary<string, int>
                {
                    { selectedTAs[0].Name, processingTime },
                    { selectedTAs[1].Name, processingTime }
                };

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Small test instance: 10 tasks, 6 TAs (random pairs)"
            };
        }

        /// <summary>
        /// Creates a small test instance with 14 tasks and 5 TAs with higher processing times
        /// </summary>
        public static ProblemInstance Small_14(string name = "small_14", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with random TA pairs and higher processing times
            for (int i = 1; i <= 14; i++)
            {
                // Randomly select 2 different TAs
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 30 + random.Next(1, 26); // Processing time between 30-55

                var processingTimes = new Dictionary<string, int>
                {
                    { selectedTAs[0].Name, processingTime },
                    { selectedTAs[1].Name, processingTime }
                };

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Small test instance: 14 tasks, 5 TAs (random pairs, higher processing times)"
            };
        }

        /// <summary>
        /// Creates a medium test instance
        /// </summary>
        public static ProblemInstance Medium_1(string name = "medium_1", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(name => new TAInfo { Name = name }).ToList();

            // Create 30 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 30; i++)
            {
                // Use round-robin to pair TAs
                int ta1Index = (i - 1) % 5;
                int ta2Index = (i % 5);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 20 + i;

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
        /// Creates a balanced instance with uniform task distribution across TAs
        /// This tests load balancing capabilities of algorithms
        /// </summary>
        public static ProblemInstance Medium_2(string name = "medium_2", int numTasks = 50, int numTAs = 8)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            
            for (int i = 1; i <= numTAs; i++)
            {
                taNames.Add($"TA{i}");
            }

            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();
            
            // Create tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 0; i < numTasks; i++)
            {
                // Use round-robin to pair TAs
                int ta1Index = i % numTAs;
                int ta2Index = (i + 1) % numTAs;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 35 + (i % 20);

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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

        /// <summary>
        /// Creates a highly constrained instance where each task has minimal eligible TAs
        /// This tests algorithms under high constraint scenarios
        /// </summary>
        public static ProblemInstance Medium_3(string name = "medium_3", int numTasks = 20, int numTAs = 5)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            
            for (int i = 1; i <= numTAs; i++)
            {
                taNames.Add($"TA{i}");
            }

            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Each task has exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= numTasks; i++)
            {
                // Use round-robin to pair TAs
                int ta1Index = (i - 1) % numTAs;
                int ta2Index = i % numTAs;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 40 + (i * 3);

                var processingTimes = new Dictionary<string, int>
                {
                    { taNames[ta1Index], processingTime },
                    { taNames[ta2Index], processingTime }
                };

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
        /// Creates a medium test instance with 40 tasks and 6 TAs
        /// </summary>
        public static ProblemInstance Medium_4(string name = "medium_4", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 40 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 40; i++)
            {
                // Use round-robin to pair TAs
                int ta1Index = (i - 1) % 6;
                int ta2Index = i % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 25 + (i % 25);

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Medium test instance: 40 tasks, 6 TAs"
            };
        }

        /// <summary>
        /// Creates a medium test instance with 35 tasks and 7 TAs
        /// </summary>
        public static ProblemInstance Medium_5(string name = "medium_5", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 35 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 35; i++)
            {
                // Randomly select 2 different TAs
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 30 + random.Next(1, 41); // Processing time between 30-70

                var processingTimes = new Dictionary<string, int>
                {
                    { selectedTAs[0].Name, processingTime },
                    { selectedTAs[1].Name, processingTime }
                };

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Medium test instance: 35 tasks, 7 TAs (random TA pairs)"
            };
        }

        /// <summary>
        /// Creates a medium test instance with 45 tasks and 6 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Medium_6(string name = "medium_6", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 45 tasks with sequential TA pairs
            for (int i = 1; i <= 45; i++)
            {
                // Use sequential pairs with some variation
                int ta1Index = (i - 1) % 6;
                int ta2Index = (ta1Index + 1 + (i / 10) % 5) % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 28 + (i % 30);

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Medium test instance: 45 tasks, 6 TAs (sequential pairs)"
            };
        }

        /// <summary>
        /// Creates a medium test instance with 38 tasks and 8 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Medium_7(string name = "medium_7", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 38 tasks with complementary TA pairs (first half with second half)
            for (int i = 1; i <= 38; i++)
            {
                // Pair TAs from opposite ends: first half with second half
                int ta1Index = (i - 1) % 4;
                int ta2Index = 4 + ((i - 1) % 4);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 32 + random.Next(1, 36); // Processing time between 32-67

                var processingTimes = new Dictionary<string, int>
                {
                    { tas[ta1Index].Name, processingTime },
                    { tas[ta2Index].Name, processingTime }
                };

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
                Description = "Medium test instance: 38 tasks, 8 TAs (complementary pairs)"
            };
        }

        /// <summary>
        /// Creates a medium test instance with 42 tasks and 7 TAs with higher processing times
        /// </summary>
        public static ProblemInstance Medium_8(string name = "medium_8", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 42 tasks with random TA pairs and higher processing times
            for (int i = 1; i <= 42; i++)
            {
                // Randomly select 2 different TAs
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 45 + random.Next(1, 36); // Processing time between 45-80

                var processingTimes = new Dictionary<string, int>
                {
                    { selectedTAs[0].Name, processingTime },
                    { selectedTAs[1].Name, processingTime }
                };

                tasks.Add(new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = processingTimes
                });
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Medium test instance: 42 tasks, 7 TAs (random pairs, higher processing times)"
            };
        }

        /// <summary>
        /// Creates a large test instance
        /// </summary>
        public static ProblemInstance Big_1(string name = "big_1", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8", "TA9", "TA10" };
            var tas = taNames.Select(name => new TAInfo { Name = name }).ToList();

            // Create 100 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 100; i++)
            {
                // Use round-robin to pair TAs
                int ta1Index = (i - 1) % 10;
                int ta2Index = i % 10;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 50 + (i % 30);

                var processingTimes = new Dictionary<string, int>
                {
                    { taNames[ta1Index], processingTime },
                    { taNames[ta2Index], processingTime }
                };

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

        /// <summary>
        /// Creates a large test instance where each task can be performed by exactly 2 TAs with the same processing time
        /// </summary>
        public static ProblemInstance Big_2(string name = "big_2", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8", "TA9", "TA10" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 100 tasks, each with exactly 2 eligible TAs with the same processing time
            for (int i = 1; i <= 100; i++)
            {
                // Randomly select 2 different TAs
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 30 + random.Next(1, 51); // Processing time between 30-80

                var task = new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { selectedTAs[0].Name, processingTime },
                        { selectedTAs[1].Name, processingTime }
                    }
                };
                tasks.Add(task);
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Large instance with 100 tasks, each task has exactly 2 eligible TAs with identical processing times"
            };
        }

        /// <summary>
        /// Creates a large test instance where each task can be performed by exactly 2 TAs with the same processing time
        /// Uses sequential TA pairs for more structured patterns
        /// </summary>
        public static ProblemInstance Big_3(string name = "big_3", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8", "TA9", "TA10" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 100 tasks with structured TA pairs
            for (int i = 1; i <= 100; i++)
            {
                // Use sequential pairs with some variation
                int ta1Index = (i - 1) % (tas.Count - 1);
                int ta2Index = (ta1Index + 1 + (i / 10) % (tas.Count - 1)) % tas.Count;
                
                var selectedTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 40 + (i % 40); // Processing time between 40-79

                var task = new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { selectedTAs[0].Name, processingTime },
                        { selectedTAs[1].Name, processingTime }
                    }
                };
                tasks.Add(task);
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Large instance with 100 tasks, each task has exactly 2 eligible TAs (sequential pairs) with identical processing times"
            };
        }

        /// <summary>
        /// Creates a large test instance where each task can be performed by exactly 2 TAs with the same processing time
        /// Uses complementary TA pairs (opposite ends of the list)
        /// </summary>
        public static ProblemInstance Big_4(string name = "big_4", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8", "TA9", "TA10" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 100 tasks with complementary TA pairs
            for (int i = 1; i <= 100; i++)
            {
                // Pair TAs from opposite ends: first half with second half
                int ta1Index = (i - 1) % (tas.Count / 2);
                int ta2Index = (tas.Count / 2) + ((i - 1) % (tas.Count / 2));
                
                var selectedTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 50 + random.Next(1, 31); // Processing time between 50-80

                var task = new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { selectedTAs[0].Name, processingTime },
                        { selectedTAs[1].Name, processingTime }
                    }
                };
                tasks.Add(task);
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Large instance with 100 tasks, each task has exactly 2 eligible TAs (complementary pairs) with identical processing times"
            };
        }

        /// <summary>
        /// Creates a large test instance where each task can be performed by exactly 2 TAs with the same processing time
        /// Uses random pairs with higher processing times
        /// </summary>
        public static ProblemInstance Big_5(string name = "big_5", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8", "TA9", "TA10" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 100 tasks with random TA pairs and higher processing times
            for (int i = 1; i <= 100; i++)
            {
                // Randomly select 2 different TAs
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 60 + random.Next(1, 41); // Processing time between 60-100

                var task = new TaskInfo
                {
                    Name = $"Task{i}",
                    EligibleTAs = selectedTAs,
                    ProcessingTimes = new Dictionary<string, int>
                    {
                        { selectedTAs[0].Name, processingTime },
                        { selectedTAs[1].Name, processingTime }
                    }
                };
                tasks.Add(task);
            }

            return new ProblemInstance
            {
                Name = name,
                Tasks = tasks,
                TAs = tas,
                Description = "Large instance with 100 tasks, each task has exactly 2 eligible TAs with identical processing times (higher processing times)"
            };
        }

        public static IEnumerable<ProblemInstance> GetAllInstances()
        {
            yield return Small_0();
            yield return Small_1();
            yield return Small_2();
            yield return Small_4();
            yield return Small_5();
            yield return Small_6();
            yield return Small_7();
            yield return Small_8();
            yield return Small_9();
            yield return Small_10();
            yield return Small_11();
            yield return Small_12();
            yield return Small_13();
            yield return Small_14();
            yield return Medium_1();
            yield return Medium_2();
            yield return Medium_3();
            yield return Medium_4();
            yield return Medium_5();
            yield return Medium_6();
            yield return Medium_7();
            yield return Medium_8();
            yield return Big_1();
            yield return Big_2();
            yield return Big_3();
            yield return Big_4();
            yield return Big_5();
        }
    }
}
