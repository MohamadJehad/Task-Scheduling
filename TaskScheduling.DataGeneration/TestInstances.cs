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

        /// <summary>
        /// Creates a small instance with very low processing times (1-5) and few TAs
        /// </summary>
        public static ProblemInstance Small_15(string name = "small_15", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with very low processing times (1-5)
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 1 + random.Next(0, 5); // Processing time between 1-5

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
                Description = "Small instance: 12 tasks, 3 TAs, very low processing times (1-5)"
            };
        }

        /// <summary>
        /// Creates a small instance with very high processing times (100-200) and few TAs
        /// </summary>
        public static ProblemInstance Small_16(string name = "small_16", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with very high processing times (100-200)
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 100 + random.Next(0, 101); // Processing time between 100-200

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
                Description = "Small instance: 10 tasks, 4 TAs, very high processing times (100-200)"
            };
        }

        /// <summary>
        /// Creates a small instance with wide load range (5-150) and moderate TAs
        /// </summary>
        public static ProblemInstance Small_18(string name = "small_18", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with wide range of processing times (5-150)
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                // Wide range: mix of small, medium, and large processing times
                int processingTime = random.Next(0, 100) < 30 ? 
                    (5 + random.Next(0, 20)) : // 30% chance: 5-25
                    (random.Next(0, 100) < 50 ? 
                        (30 + random.Next(0, 50)) : // 35% chance: 30-80
                        (80 + random.Next(0, 71))); // 35% chance: 80-150

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
                Description = "Small instance: 12 tasks, 6 TAs, wide processing time range (5-150)"
            };
        }

        /// <summary>
        /// Creates a small instance with many TAs (8) and moderate tasks
        /// </summary>
        public static ProblemInstance Small_19(string name = "small_19", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 8; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with moderate processing times (20-80)
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 20 + random.Next(0, 61); // Processing time between 20-80

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
                Description = "Small instance: 10 tasks, 8 TAs, moderate processing times (20-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with very low processing times (1-10) and many TAs
        /// </summary>
        public static ProblemInstance Small_20(string name = "small_20", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 7; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with very low processing times (1-10)
            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 1 + random.Next(0, 10); // Processing time between 1-10

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
                Description = "Small instance: 11 tasks, 7 TAs, very low processing times (1-10)"
            };
        }

        /// <summary>
        /// Creates a small instance with very high processing times (150-300) and many TAs
        /// </summary>
        public static ProblemInstance Small_21(string name = "small_21", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 6; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with very high processing times (150-300)
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 150 + random.Next(0, 151); // Processing time between 150-300

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
                Description = "Small instance: 9 tasks, 6 TAs, very high processing times (150-300)"
            };
        }

        /// <summary>
        /// Creates a small instance with extreme load range (1-200) and moderate TAs
        /// </summary>
        public static ProblemInstance Small_22(string name = "small_22", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with extreme range of processing times (1-200)
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                // Extreme range: uniform distribution from 1 to 200
                int processingTime = 1 + random.Next(0, 200);

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
                Description = "Small instance: 10 tasks, 5 TAs, extreme processing time range (1-200)"
            };
        }

        /// <summary>
        /// Creates a small instance with moderate TAs (7) and bimodal load distribution
        /// </summary>
        public static ProblemInstance Small_23(string name = "small_23", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 7; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with bimodal distribution: many small (5-15) and few very large (180-200)
            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                // 80% small tasks, 20% very large tasks
                int processingTime = random.Next(0, 100) < 80 ? 
                    (5 + random.Next(0, 11)) : // 80% chance: 5-15
                    (180 + random.Next(0, 21)); // 20% chance: 180-200

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
                Description = "Small instance: 13 tasks, 7 TAs, bimodal processing time distribution (5-15 and 180-200)"
            };
        }

        /// <summary>
        /// Creates a small instance with many TAs (9) and moderate-high processing times
        /// </summary>
        public static ProblemInstance Small_24(string name = "small_24", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 9; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with moderate-high processing times (50-120)
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 50 + random.Next(0, 71); // Processing time between 50-120

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
                Description = "Small instance: 12 tasks, 9 TAs, moderate-high processing times (50-120)"
            };
        }

        /// <summary>
        /// Creates a small instance with 7 tasks and 3 TAs with low processing times
        /// </summary>
        public static ProblemInstance Small_25(string name = "small_25", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 7 tasks with low processing times (8-25)
            for (int i = 1; i <= 7; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 8 + random.Next(0, 18); // Processing time between 8-25

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
                Description = "Small instance: 7 tasks, 3 TAs, low processing times (8-25)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 4 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_26(string name = "small_26", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with round-robin TA pairs
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 22 + (i % 28); // Processing time between 22-49

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
                Description = "Small instance: 11 tasks, 4 TAs, round-robin pairs (22-49)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 5 TAs with high processing times
        /// </summary>
        public static ProblemInstance Small_27(string name = "small_27", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with high processing times (80-140)
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 80 + random.Next(0, 61); // Processing time between 80-140

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
                Description = "Small instance: 9 tasks, 5 TAs, high processing times (80-140)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 3 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Small_28(string name = "small_28", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with sequential TA pairs
            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = (ta1Index + 1) % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 18 + (i % 22); // Processing time between 18-39

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
                Description = "Small instance: 13 tasks, 3 TAs, sequential pairs (18-39)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 6 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_29(string name = "small_29", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with random TA pairs
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 28 + random.Next(0, 33); // Processing time between 28-60

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
                Description = "Small instance: 8 tasks, 6 TAs, random pairs (28-60)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 4 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Small_30(string name = "small_30", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with complementary TA pairs (first half with second half)
            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 2;
                int ta2Index = 2 + ((i - 1) % 2);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 25 + (i % 30); // Processing time between 25-54

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
                Description = "Small instance: 12 tasks, 4 TAs, complementary pairs (25-54)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 7 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_31(string name = "small_31", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with wide range of processing times (15-90)
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 15 + random.Next(0, 76); // Processing time between 15-90

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
                Description = "Small instance: 10 tasks, 7 TAs, wide processing time range (15-90)"
            };
        }

        /// <summary>
        /// Creates a small instance with 14 tasks and 5 TAs with uniform distribution
        /// </summary>
        public static ProblemInstance Small_32(string name = "small_32", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with uniform distribution
            for (int i = 1; i <= 14; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 35 + (i % 25); // Processing time between 35-59

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
                Description = "Small instance: 14 tasks, 5 TAs, uniform distribution (35-59)"
            };
        }

        /// <summary>
        /// Creates a small instance with 6 tasks and 4 TAs with very low processing times
        /// </summary>
        public static ProblemInstance Small_33(string name = "small_33", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 6 tasks with very low processing times (3-12)
            for (int i = 1; i <= 6; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 3 + random.Next(0, 10); // Processing time between 3-12

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
                Description = "Small instance: 6 tasks, 4 TAs, very low processing times (3-12)"
            };
        }

        /// <summary>
        /// Creates a small instance with 16 tasks and 4 TAs with moderate-high processing times
        /// </summary>
        public static ProblemInstance Small_34(string name = "small_34", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 16 tasks with moderate-high processing times (55-95)
            for (int i = 1; i <= 16; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 55 + random.Next(0, 41); // Processing time between 55-95

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
                Description = "Small instance: 16 tasks, 4 TAs, moderate-high processing times (55-95)"
            };
        }

        /// <summary>
        /// Creates a small instance with 5 tasks and 3 TAs with minimal processing times
        /// </summary>
        public static ProblemInstance Small_35(string name = "small_35", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 5 tasks with minimal processing times (2-8)
            for (int i = 1; i <= 5; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 2 + random.Next(0, 7); // Processing time between 2-8

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
                Description = "Small instance: 5 tasks, 3 TAs, minimal processing times (2-8)"
            };
        }

        /// <summary>
        /// Creates a small instance with 17 tasks and 5 TAs using structured pairs
        /// </summary>
        public static ProblemInstance Small_36(string name = "small_36", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 17 tasks with structured TA pairs
            for (int i = 1; i <= 17; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = (i + 1) % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 40 + (i % 35); // Processing time between 40-74

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
                Description = "Small instance: 17 tasks, 5 TAs, structured pairs (40-74)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 8 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_37(string name = "small_37", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with random TA pairs
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 32 + random.Next(0, 29); // Processing time between 32-60

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
                Description = "Small instance: 9 tasks, 8 TAs, random pairs (32-60)"
            };
        }

        /// <summary>
        /// Creates a small instance with 15 tasks and 3 TAs with medium processing times
        /// </summary>
        public static ProblemInstance Small_38(string name = "small_38", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 15 tasks with medium processing times (35-65)
            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 35 + random.Next(0, 31); // Processing time between 35-65

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
                Description = "Small instance: 15 tasks, 3 TAs, medium processing times (35-65)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 6 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_39(string name = "small_39", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with round-robin TA pairs
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 6;
                int ta2Index = i % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 20 + (i % 40); // Processing time between 20-59

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
                Description = "Small instance: 11 tasks, 6 TAs, round-robin pairs (20-59)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 4 TAs with very high processing times
        /// </summary>
        public static ProblemInstance Small_40(string name = "small_40", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with very high processing times (120-180)
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 120 + random.Next(0, 61); // Processing time between 120-180

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
                Description = "Small instance: 8 tasks, 4 TAs, very high processing times (120-180)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 5 TAs with complementary pairs
        /// </summary>
        public static ProblemInstance Small_41(string name = "small_41", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with complementary TA pairs
            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 2;
                int ta2Index = 3 + ((i - 1) % 2);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + (i % 32); // Processing time between 30-61

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
                Description = "Small instance: 12 tasks, 5 TAs, complementary pairs (30-61)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 3 TAs with narrow processing time range
        /// </summary>
        public static ProblemInstance Small_42(string name = "small_42", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with narrow range of processing times (45-55)
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 45 + random.Next(0, 11); // Processing time between 45-55

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
                Description = "Small instance: 10 tasks, 3 TAs, narrow processing time range (45-55)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 7 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_43(string name = "small_43", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with wide range of processing times (10-110)
            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 10 + random.Next(0, 101); // Processing time between 10-110

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
                Description = "Small instance: 13 tasks, 7 TAs, wide processing time range (10-110)"
            };
        }

        /// <summary>
        /// Creates a small instance with 7 tasks and 9 TAs with moderate processing times
        /// </summary>
        public static ProblemInstance Small_44(string name = "small_44", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 9; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 7 tasks with moderate processing times (38-72)
            for (int i = 1; i <= 7; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 38 + random.Next(0, 35); // Processing time between 38-72

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
                Description = "Small instance: 7 tasks, 9 TAs, moderate processing times (38-72)"
            };
        }

        /// <summary>
        /// Creates a small instance with 14 tasks and 4 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Small_45(string name = "small_45", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with sequential TA pairs
            for (int i = 1; i <= 14; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = (ta1Index + 1) % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 27 + (i % 38); // Processing time between 27-64

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
                Description = "Small instance: 14 tasks, 4 TAs, sequential pairs (27-64)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 4 TAs with low-medium processing times
        /// </summary>
        public static ProblemInstance Small_46(string name = "small_46", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with low-medium processing times (12-35)
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 12 + random.Next(0, 24); // Processing time between 12-35

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
                Description = "Small instance: 9 tasks, 4 TAs, low-medium processing times (12-35)"
            };
        }

        /// <summary>
        /// Creates a small instance with 15 tasks and 6 TAs with uniform distribution
        /// </summary>
        public static ProblemInstance Small_47(string name = "small_47", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 15 tasks with uniform distribution
            for (int i = 1; i <= 15; i++)
            {
                int ta1Index = (i - 1) % 6;
                int ta2Index = i % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 42 + (i % 28); // Processing time between 42-69

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
                Description = "Small instance: 15 tasks, 6 TAs, uniform distribution (42-69)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 3 TAs with high processing times
        /// </summary>
        public static ProblemInstance Small_48(string name = "small_48", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with high processing times (90-130)
            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 90 + random.Next(0, 41); // Processing time between 90-130

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
                Description = "Small instance: 11 tasks, 3 TAs, high processing times (90-130)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 8 TAs using random pairs
        /// </summary>
        public static ProblemInstance Small_49(string name = "small_49", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with random TA pairs
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 25 + random.Next(0, 46); // Processing time between 25-70

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
                Description = "Small instance: 12 tasks, 8 TAs, random pairs (25-70)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 5 TAs with extreme processing time range
        /// </summary>
        public static ProblemInstance Small_50(string name = "small_50", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with extreme range of processing times (5-150)
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 5 + random.Next(0, 146); // Processing time between 5-150

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
                Description = "Small instance: 8 tasks, 5 TAs, extreme processing time range (5-150)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 4 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_51(string name = "small_51", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with round-robin TA pairs
            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 33 + (i % 27); // Processing time between 33-59

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
                Description = "Small instance: 13 tasks, 4 TAs, round-robin pairs (33-59)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 7 TAs with medium-high processing times
        /// </summary>
        public static ProblemInstance Small_52(string name = "small_52", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with medium-high processing times (60-100)
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 60 + random.Next(0, 41); // Processing time between 60-100

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
                Description = "Small instance: 10 tasks, 7 TAs, medium-high processing times (60-100)"
            };
        }

        /// <summary>
        /// Creates a small instance with 14 tasks and 3 TAs with bimodal distribution
        /// </summary>
        public static ProblemInstance Small_53(string name = "small_53", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with bimodal distribution: many small (10-20) and few large (100-120)
            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                // 75% small tasks, 25% large tasks
                int processingTime = random.Next(0, 100) < 75 ? 
                    (10 + random.Next(0, 11)) : // 75% chance: 10-20
                    (100 + random.Next(0, 21)); // 25% chance: 100-120

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
                Description = "Small instance: 14 tasks, 3 TAs, bimodal processing time distribution (10-20 and 100-120)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 6 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Small_54(string name = "small_54", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with complementary TA pairs (first half with second half)
            for (int i = 1; i <= 9; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = 3 + ((i - 1) % 3);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 28 + (i % 34); // Processing time between 28-61

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
                Description = "Small instance: 9 tasks, 6 TAs, complementary pairs (28-61)"
            };
        }

        /// <summary>
        /// Creates a small instance with 6 tasks and 5 TAs with very low processing times
        /// </summary>
        public static ProblemInstance Small_55(string name = "small_55", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 6 tasks with very low processing times (4-15)
            for (int i = 1; i <= 6; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 4 + random.Next(0, 12); // Processing time between 4-15

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
                Description = "Small instance: 6 tasks, 5 TAs, very low processing times (4-15)"
            };
        }

        /// <summary>
        /// Creates a small instance with 18 tasks and 4 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_56(string name = "small_56", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 18 tasks with round-robin TA pairs
            for (int i = 1; i <= 18; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 38 + (i % 42); // Processing time between 38-79

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
                Description = "Small instance: 18 tasks, 4 TAs, round-robin pairs (38-79)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 8 TAs with random pairs and medium processing times
        /// </summary>
        public static ProblemInstance Small_57(string name = "small_57", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with random TA pairs and medium processing times
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 43 + random.Next(0, 38); // Processing time between 43-80

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
                Description = "Small instance: 10 tasks, 8 TAs, random pairs, medium processing times (43-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 3 TAs with sequential pairs and high processing times
        /// </summary>
        public static ProblemInstance Small_58(string name = "small_58", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with sequential TA pairs and high processing times
            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = (ta1Index + 1) % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 95 + (i % 36); // Processing time between 95-130

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
                Description = "Small instance: 12 tasks, 3 TAs, sequential pairs, high processing times (95-130)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 7 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_59(string name = "small_59", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with wide range of processing times (20-130)
            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 20 + random.Next(0, 111); // Processing time between 20-130

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
                Description = "Small instance: 11 tasks, 7 TAs, wide processing time range (20-130)"
            };
        }

        /// <summary>
        /// Creates a small instance with 7 tasks and 4 TAs with minimal processing times
        /// </summary>
        public static ProblemInstance Small_60(string name = "small_60", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 7 tasks with minimal processing times (1-10)
            for (int i = 1; i <= 7; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 1 + random.Next(0, 10); // Processing time between 1-10

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
                Description = "Small instance: 7 tasks, 4 TAs, minimal processing times (1-10)"
            };
        }

        /// <summary>
        /// Creates a small instance with 19 tasks and 5 TAs using structured pairs
        /// </summary>
        public static ProblemInstance Small_61(string name = "small_61", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 19 tasks with structured TA pairs
            for (int i = 1; i <= 19; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = (i + 2) % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 36 + (i % 44); // Processing time between 36-79

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
                Description = "Small instance: 19 tasks, 5 TAs, structured pairs (36-79)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 9 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_62(string name = "small_62", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 9; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with random TA pairs
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 30 + random.Next(0, 51); // Processing time between 30-80

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
                Description = "Small instance: 8 tasks, 9 TAs, random pairs (30-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 3 TAs with medium-low processing times
        /// </summary>
        public static ProblemInstance Small_63(string name = "small_63", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with medium-low processing times (25-50)
            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 25 + random.Next(0, 26); // Processing time between 25-50

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
                Description = "Small instance: 13 tasks, 3 TAs, medium-low processing times (25-50)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 6 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Small_64(string name = "small_64", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with complementary TA pairs
            for (int i = 1; i <= 10; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = 3 + ((i - 1) % 3);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 32 + (i % 38); // Processing time between 32-69

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
                Description = "Small instance: 10 tasks, 6 TAs, complementary pairs (32-69)"
            };
        }

        /// <summary>
        /// Creates a small instance with 14 tasks and 4 TAs with narrow processing time range
        /// </summary>
        public static ProblemInstance Small_65(string name = "small_65", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with narrow range of processing times (50-65)
            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 50 + random.Next(0, 16); // Processing time between 50-65

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
                Description = "Small instance: 14 tasks, 4 TAs, narrow processing time range (50-65)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 7 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_66(string name = "small_66", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with wide range of processing times (15-125)
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 15 + random.Next(0, 111); // Processing time between 15-125

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
                Description = "Small instance: 9 tasks, 7 TAs, wide processing time range (15-125)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 5 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Small_67(string name = "small_67", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with sequential TA pairs
            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = (ta1Index + 1) % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 41 + (i % 39); // Processing time between 41-79

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
                Description = "Small instance: 12 tasks, 5 TAs, sequential pairs (41-79)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 4 TAs with uniform distribution
        /// </summary>
        public static ProblemInstance Small_68(string name = "small_68", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with uniform distribution
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 28 + (i % 33); // Processing time between 28-60

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
                Description = "Small instance: 11 tasks, 4 TAs, uniform distribution (28-60)"
            };
        }

        /// <summary>
        /// Creates a small instance with 15 tasks and 3 TAs with extreme high processing times
        /// </summary>
        public static ProblemInstance Small_69(string name = "small_69", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 15 tasks with extreme high processing times (140-200)
            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 140 + random.Next(0, 61); // Processing time between 140-200

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
                Description = "Small instance: 15 tasks, 3 TAs, extreme high processing times (140-200)"
            };
        }

        /// <summary>
        /// Creates a small instance with 6 tasks and 3 TAs with very low processing times
        /// </summary>
        public static ProblemInstance Small_70(string name = "small_70", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 6 tasks with very low processing times (3-12)
            for (int i = 1; i <= 6; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 3 + random.Next(0, 10); // Processing time between 3-12

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
                Description = "Small instance: 6 tasks, 3 TAs, very low processing times (3-12)"
            };
        }

        /// <summary>
        /// Creates a small instance with 20 tasks and 4 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_71(string name = "small_71", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 20 tasks with round-robin TA pairs
            for (int i = 1; i <= 20; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 40 + (i % 45); // Processing time between 40-84

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
                Description = "Small instance: 20 tasks, 4 TAs, round-robin pairs (40-84)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 8 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_72(string name = "small_72", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with random TA pairs
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 35 + random.Next(0, 46); // Processing time between 35-80

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
                Description = "Small instance: 8 tasks, 8 TAs, random pairs (35-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with 14 tasks and 3 TAs with low-medium processing times
        /// </summary>
        public static ProblemInstance Small_73(string name = "small_73", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with low-medium processing times (18-45)
            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 18 + random.Next(0, 28); // Processing time between 18-45

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
                Description = "Small instance: 14 tasks, 3 TAs, low-medium processing times (18-45)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 7 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Small_74(string name = "small_74", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with complementary TA pairs
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = 4 + ((i - 1) % 3);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 37 + (i % 43); // Processing time between 37-79

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
                Description = "Small instance: 11 tasks, 7 TAs, complementary pairs (37-79)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 5 TAs with narrow processing time range
        /// </summary>
        public static ProblemInstance Small_75(string name = "small_75", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with narrow range of processing times (55-70)
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 55 + random.Next(0, 16); // Processing time between 55-70

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
                Description = "Small instance: 9 tasks, 5 TAs, narrow processing time range (55-70)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 6 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_76(string name = "small_76", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with wide range of processing times (12-135)
            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 12 + random.Next(0, 124); // Processing time between 12-135

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
                Description = "Small instance: 13 tasks, 6 TAs, wide processing time range (12-135)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 4 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Small_77(string name = "small_77", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with sequential TA pairs
            for (int i = 1; i <= 10; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = (ta1Index + 1) % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 31 + (i % 40); // Processing time between 31-70

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
                Description = "Small instance: 10 tasks, 4 TAs, sequential pairs (31-70)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 5 TAs with uniform distribution
        /// </summary>
        public static ProblemInstance Small_78(string name = "small_78", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with uniform distribution
            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 33 + (i % 37); // Processing time between 33-69

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
                Description = "Small instance: 12 tasks, 5 TAs, uniform distribution (33-69)"
            };
        }

        /// <summary>
        /// Creates a small instance with 7 tasks and 6 TAs with high processing times
        /// </summary>
        public static ProblemInstance Small_79(string name = "small_79", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 7 tasks with high processing times (85-135)
            for (int i = 1; i <= 7; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 85 + random.Next(0, 51); // Processing time between 85-135

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
                Description = "Small instance: 7 tasks, 6 TAs, high processing times (85-135)"
            };
        }

        /// <summary>
        /// Creates a small instance with 15 tasks and 4 TAs with medium processing times
        /// </summary>
        public static ProblemInstance Small_80(string name = "small_80", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 15 tasks with medium processing times (42-78)
            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 42 + random.Next(0, 37); // Processing time between 42-78

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
                Description = "Small instance: 15 tasks, 4 TAs, medium processing times (42-78)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 3 TAs with very high processing times
        /// </summary>
        public static ProblemInstance Small_81(string name = "small_81", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with very high processing times (110-160)
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 110 + random.Next(0, 51); // Processing time between 110-160

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
                Description = "Small instance: 8 tasks, 3 TAs, very high processing times (110-160)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 8 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_82(string name = "small_82", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with round-robin TA pairs
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 8;
                int ta2Index = i % 8;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 26 + (i % 49); // Processing time between 26-74

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
                Description = "Small instance: 11 tasks, 8 TAs, round-robin pairs (26-74)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 4 TAs with bimodal distribution
        /// </summary>
        public static ProblemInstance Small_83(string name = "small_83", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with bimodal distribution: many small (8-18) and few very large (150-170)
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                // 70% small tasks, 30% very large tasks
                int processingTime = random.Next(0, 100) < 70 ? 
                    (8 + random.Next(0, 11)) : // 70% chance: 8-18
                    (150 + random.Next(0, 21)); // 30% chance: 150-170

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
                Description = "Small instance: 9 tasks, 4 TAs, bimodal processing time distribution (8-18 and 150-170)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 5 TAs using structured pairs
        /// </summary>
        public static ProblemInstance Small_84(string name = "small_84", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with structured TA pairs
            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = (i + 3) % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 39 + (i % 41); // Processing time between 39-79

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
                Description = "Small instance: 13 tasks, 5 TAs, structured pairs (39-79)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 3 TAs with extreme low processing times
        /// </summary>
        public static ProblemInstance Small_85(string name = "small_85", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with extreme low processing times (1-8)
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 1 + random.Next(0, 8); // Processing time between 1-8

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
                Description = "Small instance: 10 tasks, 3 TAs, extreme low processing times (1-8)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 7 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_86(string name = "small_86", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with random TA pairs
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 29 + random.Next(0, 52); // Processing time between 29-80

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
                Description = "Small instance: 12 tasks, 7 TAs, random pairs (29-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with 14 tasks and 4 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Small_87(string name = "small_87", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with sequential TA pairs
            for (int i = 1; i <= 14; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = (ta1Index + 1) % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 34 + (i % 41); // Processing time between 34-74

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
                Description = "Small instance: 14 tasks, 4 TAs, sequential pairs (34-74)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 6 TAs with medium-high processing times
        /// </summary>
        public static ProblemInstance Small_88(string name = "small_88", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with medium-high processing times (65-105)
            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 65 + random.Next(0, 41); // Processing time between 65-105

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
                Description = "Small instance: 11 tasks, 6 TAs, medium-high processing times (65-105)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 5 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Small_89(string name = "small_89", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with complementary TA pairs
            for (int i = 1; i <= 9; i++)
            {
                int ta1Index = (i - 1) % 2;
                int ta2Index = 3 + ((i - 1) % 2);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 36 + (i % 39); // Processing time between 36-74

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
                Description = "Small instance: 9 tasks, 5 TAs, complementary pairs (36-74)"
            };
        }

        /// <summary>
        /// Creates a small instance with 16 tasks and 3 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_90(string name = "small_90", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 16 tasks with wide range of processing times (22-142)
            for (int i = 1; i <= 16; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 22 + random.Next(0, 121); // Processing time between 22-142

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
                Description = "Small instance: 16 tasks, 3 TAs, wide processing time range (22-142)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 7 TAs with uniform distribution
        /// </summary>
        public static ProblemInstance Small_91(string name = "small_91", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with uniform distribution
            for (int i = 1; i <= 8; i++)
            {
                int ta1Index = (i - 1) % 7;
                int ta2Index = i % 7;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + (i % 41); // Processing time between 30-70

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
                Description = "Small instance: 8 tasks, 7 TAs, uniform distribution (30-70)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 4 TAs with low processing times
        /// </summary>
        public static ProblemInstance Small_92(string name = "small_92", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with low processing times (6-22)
            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 6 + random.Next(0, 17); // Processing time between 6-22

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
                Description = "Small instance: 13 tasks, 4 TAs, low processing times (6-22)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 9 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_93(string name = "small_93", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 9; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with random TA pairs
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 40 + random.Next(0, 51); // Processing time between 40-90

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
                Description = "Small instance: 10 tasks, 9 TAs, random pairs (40-90)"
            };
        }

        /// <summary>
        /// Creates a small instance with 15 tasks and 5 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_94(string name = "small_94", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 15 tasks with round-robin TA pairs
            for (int i = 1; i <= 15; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 44 + (i % 46); // Processing time between 44-89

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
                Description = "Small instance: 15 tasks, 5 TAs, round-robin pairs (44-89)"
            };
        }

        /// <summary>
        /// Creates a small instance with 7 tasks and 5 TAs with minimal processing times
        /// </summary>
        public static ProblemInstance Small_95(string name = "small_95", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 7 tasks with minimal processing times (2-9)
            for (int i = 1; i <= 7; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 2 + random.Next(0, 8); // Processing time between 2-9

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
                Description = "Small instance: 7 tasks, 5 TAs, minimal processing times (2-9)"
            };
        }

        /// <summary>
        /// Creates a small instance with 17 tasks and 4 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_96(string name = "small_96", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 17 tasks with round-robin TA pairs
            for (int i = 1; i <= 17; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 46 + (i % 38); // Processing time between 46-83

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
                Description = "Small instance: 17 tasks, 4 TAs, round-robin pairs (46-83)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 6 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_97(string name = "small_97", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with random TA pairs
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 38 + random.Next(0, 43); // Processing time between 38-80

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
                Description = "Small instance: 9 tasks, 6 TAs, random pairs (38-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 3 TAs with medium processing times
        /// </summary>
        public static ProblemInstance Small_98(string name = "small_98", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with medium processing times (48-82)
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 48 + random.Next(0, 35); // Processing time between 48-82

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
                Description = "Small instance: 12 tasks, 3 TAs, medium processing times (48-82)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 8 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Small_99(string name = "small_99", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with complementary TA pairs
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = 4 + ((i - 1) % 4);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 32 + (i % 48); // Processing time between 32-79

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
                Description = "Small instance: 11 tasks, 8 TAs, complementary pairs (32-79)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 4 TAs with narrow processing time range
        /// </summary>
        public static ProblemInstance Small_100(string name = "small_100", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with narrow range of processing times (60-75)
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 60 + random.Next(0, 16); // Processing time between 60-75

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
                Description = "Small instance: 8 tasks, 4 TAs, narrow processing time range (60-75)"
            };
        }

        /// <summary>
        /// Creates a small instance with 14 tasks and 6 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_101(string name = "small_101", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 14 tasks with wide range of processing times (18-148)
            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 18 + random.Next(0, 131); // Processing time between 18-148

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
                Description = "Small instance: 14 tasks, 6 TAs, wide processing time range (18-148)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 5 TAs using sequential pairs
        /// </summary>
        public static ProblemInstance Small_102(string name = "small_102", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with sequential TA pairs
            for (int i = 1; i <= 10; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = (ta1Index + 1) % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 47 + (i % 33); // Processing time between 47-79

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
                Description = "Small instance: 10 tasks, 5 TAs, sequential pairs (47-79)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 4 TAs with uniform distribution
        /// </summary>
        public static ProblemInstance Small_103(string name = "small_103", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with uniform distribution
            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 35 + (i % 36); // Processing time between 35-70

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
                Description = "Small instance: 13 tasks, 4 TAs, uniform distribution (35-70)"
            };
        }

        /// <summary>
        /// Creates a small instance with 9 tasks and 7 TAs with high processing times
        /// </summary>
        public static ProblemInstance Small_104(string name = "small_104", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 9 tasks with high processing times (100-155)
            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 100 + random.Next(0, 56); // Processing time between 100-155

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
                Description = "Small instance: 9 tasks, 7 TAs, high processing times (100-155)"
            };
        }

        /// <summary>
        /// Creates a small instance with 8 tasks and 3 TAs with very low processing times
        /// </summary>
        public static ProblemInstance Small_105(string name = "small_105", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 8 tasks with very low processing times (4-14)
            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 4 + random.Next(0, 11); // Processing time between 4-14

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
                Description = "Small instance: 8 tasks, 3 TAs, very low processing times (4-14)"
            };
        }

        /// <summary>
        /// Creates a small instance with 18 tasks and 5 TAs using round-robin pairs
        /// </summary>
        public static ProblemInstance Small_106(string name = "small_106", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 18 tasks with round-robin TA pairs
            for (int i = 1; i <= 18; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 50 + (i % 40); // Processing time between 50-89

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
                Description = "Small instance: 18 tasks, 5 TAs, round-robin pairs (50-89)"
            };
        }

        /// <summary>
        /// Creates a small instance with 10 tasks and 7 TAs with random pairs
        /// </summary>
        public static ProblemInstance Small_107(string name = "small_107", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 10 tasks with random TA pairs
            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 41 + random.Next(0, 50); // Processing time between 41-90

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
                Description = "Small instance: 10 tasks, 7 TAs, random pairs (41-90)"
            };
        }

        /// <summary>
        /// Creates a small instance with 13 tasks and 3 TAs with medium-high processing times
        /// </summary>
        public static ProblemInstance Small_108(string name = "small_108", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 13 tasks with medium-high processing times (70-115)
            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 70 + random.Next(0, 46); // Processing time between 70-115

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
                Description = "Small instance: 13 tasks, 3 TAs, medium-high processing times (70-115)"
            };
        }

        /// <summary>
        /// Creates a small instance with 11 tasks and 6 TAs using complementary pairs
        /// </summary>
        public static ProblemInstance Small_109(string name = "small_109", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 11 tasks with complementary TA pairs
            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = 3 + ((i - 1) % 3);
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 39 + (i % 42); // Processing time between 39-80

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
                Description = "Small instance: 11 tasks, 6 TAs, complementary pairs (39-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with 12 tasks and 4 TAs with wide processing time range
        /// </summary>
        public static ProblemInstance Small_110(string name = "small_110", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with wide range of processing times (25-150)
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 25 + random.Next(0, 126); // Processing time between 25-150

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
                Description = "Small instance: 12 tasks, 4 TAs, wide processing time range (25-150)"
            };
        }

        /// <summary>
        /// Creates a small instance with very wide processing time range (10-1100)
        /// </summary>
        public static ProblemInstance Small_111(string name = "small_111", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 12 tasks with very wide range of processing times (10-1100)
            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 10 + random.Next(0, 1091); // Processing time between 10-1100

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
                Description = "Small instance: 12 tasks, 5 TAs, very wide processing time range (10-1100)"
            };
        }

        /// <summary>
        /// Creates a small instance with few TAs (3) and wide load range (10-100)
        /// </summary>
        public static ProblemInstance Small_17(string name = "small_17", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 15 tasks with wide range of processing times (10-100)
            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 10 + random.Next(0, 91); // Processing time between 10-100

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
                Description = "Small instance: 15 tasks, 3 TAs, wide processing time range (10-100)"
            };
        }

        /// <summary>
        /// Creates a large instance with many TAs (20) and moderate-high processing times
        /// </summary>
        public static ProblemInstance Big_8(string name = "big_8", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 20; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 150 tasks with moderate-high processing times (50-120)
            for (int i = 1; i <= 150; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = 50 + random.Next(0, 71); // Processing time between 50-120

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
                Description = "Large instance: 150 tasks, 20 TAs, moderate-high processing times (50-120)"
            };
        }

        /// <summary>
        /// Creates a medium instance with moderate TAs (8) and bimodal load distribution
        /// </summary>
        public static ProblemInstance Medium_12(string name = "medium_12", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string>();
            for (int i = 1; i <= 8; i++)
            {
                taNames.Add($"TA{i}");
            }
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            // Create 50 tasks with bimodal distribution: many small (5-15) and few very large (180-200)
            for (int i = 1; i <= 50; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                // 80% small tasks, 20% very large tasks
                int processingTime = random.Next(0, 100) < 80 ? 
                    (5 + random.Next(0, 11)) : // 80% chance: 5-15
                    (180 + random.Next(0, 21)); // 20% chance: 180-200

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
                Description = "Medium instance: 50 tasks, 8 TAs, bimodal processing time distribution (5-15 and 180-200)"
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
            yield return Small_15();
            yield return Small_16();
            yield return Small_17();
            yield return Medium_1();
            yield return Medium_2();
            yield return Medium_3();
            yield return Medium_4();
            yield return Medium_5();
            yield return Medium_6();
            yield return Medium_7();
            yield return Medium_8();
            yield return Small_18();
            yield return Small_19();
            yield return Small_20();
            yield return Small_21();
            yield return Small_22();
            yield return Small_23();
            yield return Small_24();
            yield return Small_25();
            yield return Small_26();
            yield return Small_27();
            yield return Small_28();
            yield return Small_29();
            yield return Small_30();
            yield return Small_31();
            yield return Small_32();
            yield return Small_33();
            yield return Small_34();
            yield return Small_35();
            yield return Small_36();
            yield return Small_37();
            yield return Small_38();
            yield return Small_39();
            yield return Small_40();
            yield return Small_41();
            yield return Small_42();
            yield return Small_43();
            yield return Small_44();
            yield return Small_45();
            yield return Small_46();
            yield return Small_47();
            yield return Small_48();
            yield return Small_49();
            yield return Small_50();
            yield return Small_51();
            yield return Small_52();
            yield return Small_53();
            yield return Small_54();
            yield return Small_55();
            yield return Small_56();
            yield return Small_57();
            yield return Small_58();
            yield return Small_59();
            yield return Small_60();
            yield return Small_61();
            yield return Small_62();
            yield return Small_63();
            yield return Small_64();
            yield return Small_65();
            yield return Small_66();
            yield return Small_67();
            yield return Small_68();
            yield return Small_69();
            yield return Small_70();
            yield return Small_71();
            yield return Small_72();
            yield return Small_73();
            yield return Small_74();
            yield return Small_75();
            yield return Small_76();
            yield return Small_77();
            yield return Small_78();
            yield return Small_79();
            yield return Small_80();
            yield return Small_81();
            yield return Small_82();
            yield return Small_83();
            yield return Small_84();
            yield return Small_85();
            yield return Small_86();
            yield return Small_87();
            yield return Small_88();
            yield return Small_89();
            yield return Small_90();
            yield return Small_91();
            yield return Small_92();
            yield return Small_93();
            yield return Small_94();
            yield return Small_95();
            yield return Small_96();
            yield return Small_97();
            yield return Small_98();
            yield return Small_99();
            yield return Small_100();
            yield return Small_101();
            yield return Small_102();
            yield return Small_103();
            yield return Small_104();
            yield return Small_105();
            yield return Small_106();
            yield return Small_107();
            yield return Small_108();
            yield return Small_109();
            yield return Small_110();
            yield return Small_111();
            yield return Big_1();
            yield return Big_2();
            yield return Big_3();
            yield return Big_4();
            yield return Big_5();
        }
    }
}
