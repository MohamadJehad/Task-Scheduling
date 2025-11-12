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

        // ========== UNIFORM DISTRIBUTION INSTANCES (25 instances) ==========

        /// <summary>
        /// Creates a small instance with uniform distribution: 8 tasks, 3 TAs (20-60)
        /// </summary>
        public static ProblemInstance Small_112(string name = "small_112", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = i % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 20 + (i * 5); // Uniform: 25, 30, 35, 40, 45, 50, 55, 60

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
                Description = "Small instance: 8 tasks, 3 TAs, uniform distribution (20-60)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 9 tasks, 4 TAs (30-70)
        /// </summary>
        public static ProblemInstance Small_113(string name = "small_113", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + ((i - 1) * 5); // Uniform: 30, 35, 40, 45, 50, 55, 60, 65, 70

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
                Description = "Small instance: 9 tasks, 4 TAs, uniform distribution (30-70)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 10 tasks, 5 TAs (40-85)
        /// </summary>
        public static ProblemInstance Small_114(string name = "small_114", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 40 + ((i - 1) * 5); // Uniform: 40, 45, 50, 55, 60, 65, 70, 75, 80, 85

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
                Description = "Small instance: 10 tasks, 5 TAs, uniform distribution (40-85)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 11 tasks, 3 TAs (15-65)
        /// </summary>
        public static ProblemInstance Small_115(string name = "small_115", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = i % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 15 + ((i - 1) * 5); // Uniform: 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65

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
                Description = "Small instance: 11 tasks, 3 TAs, uniform distribution (15-65)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 12 tasks, 6 TAs (50-105)
        /// </summary>
        public static ProblemInstance Small_116(string name = "small_116", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 6;
                int ta2Index = i % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 50 + ((i - 1) * 5); // Uniform: 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105

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
                Description = "Small instance: 12 tasks, 6 TAs, uniform distribution (50-105)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 13 tasks, 4 TAs (25-85)
        /// </summary>
        public static ProblemInstance Small_117(string name = "small_117", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 25 + ((i - 1) * 5); // Uniform: 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85

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
                Description = "Small instance: 13 tasks, 4 TAs, uniform distribution (25-85)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 14 tasks, 5 TAs (35-100)
        /// </summary>
        public static ProblemInstance Small_118(string name = "small_118", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 35 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 14 tasks, 5 TAs, uniform distribution (35-100)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 15 tasks, 3 TAs (20-90)
        /// </summary>
        public static ProblemInstance Small_119(string name = "small_119", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = i % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 20 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 15 tasks, 3 TAs, uniform distribution (20-90)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 8 tasks, 7 TAs (45-80)
        /// </summary>
        public static ProblemInstance Small_120(string name = "small_120", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                int ta1Index = (i - 1) % 7;
                int ta2Index = i % 7;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 45 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 8 tasks, 7 TAs, uniform distribution (45-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 9 tasks, 8 TAs (30-70)
        /// </summary>
        public static ProblemInstance Small_121(string name = "small_121", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                int ta1Index = (i - 1) % 8;
                int ta2Index = i % 8;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 9 tasks, 8 TAs, uniform distribution (30-70)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 10 tasks, 6 TAs (40-85)
        /// </summary>
        public static ProblemInstance Small_122(string name = "small_122", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                int ta1Index = (i - 1) % 6;
                int ta2Index = i % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 40 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 10 tasks, 6 TAs, uniform distribution (40-85)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 11 tasks, 4 TAs (50-100)
        /// </summary>
        public static ProblemInstance Small_123(string name = "small_123", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 50 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 11 tasks, 4 TAs, uniform distribution (50-100)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 12 tasks, 5 TAs (25-80)
        /// </summary>
        public static ProblemInstance Small_124(string name = "small_124", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 25 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 12 tasks, 5 TAs, uniform distribution (25-80)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 13 tasks, 6 TAs (35-95)
        /// </summary>
        public static ProblemInstance Small_125(string name = "small_125", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 6;
                int ta2Index = i % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 35 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 13 tasks, 6 TAs, uniform distribution (35-95)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 14 tasks, 3 TAs (30-100)
        /// </summary>
        public static ProblemInstance Small_126(string name = "small_126", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = i % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 30 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 14 tasks, 3 TAs, uniform distribution (30-100)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 15 tasks, 7 TAs (40-110)
        /// </summary>
        public static ProblemInstance Small_127(string name = "small_127", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                int ta1Index = (i - 1) % 7;
                int ta2Index = i % 7;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 40 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 15 tasks, 7 TAs, uniform distribution (40-110)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 8 tasks, 4 TAs (55-90)
        /// </summary>
        public static ProblemInstance Small_128(string name = "small_128", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 55 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 8 tasks, 4 TAs, uniform distribution (55-90)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 9 tasks, 5 TAs (60-100)
        /// </summary>
        public static ProblemInstance Small_129(string name = "small_129", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 60 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 9 tasks, 5 TAs, uniform distribution (60-100)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 10 tasks, 3 TAs (45-90)
        /// </summary>
        public static ProblemInstance Small_130(string name = "small_130", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = i % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 45 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 10 tasks, 3 TAs, uniform distribution (45-90)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 11 tasks, 8 TAs (35-85)
        /// </summary>
        public static ProblemInstance Small_131(string name = "small_131", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                int ta1Index = (i - 1) % 8;
                int ta2Index = i % 8;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 35 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 11 tasks, 8 TAs, uniform distribution (35-85)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 12 tasks, 4 TAs (70-125)
        /// </summary>
        public static ProblemInstance Small_132(string name = "small_132", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 70 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 12 tasks, 4 TAs, uniform distribution (70-125)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 13 tasks, 5 TAs (80-140)
        /// </summary>
        public static ProblemInstance Small_133(string name = "small_133", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                int ta1Index = (i - 1) % 5;
                int ta2Index = i % 5;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 80 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 13 tasks, 5 TAs, uniform distribution (80-140)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 14 tasks, 6 TAs (90-160)
        /// </summary>
        public static ProblemInstance Small_134(string name = "small_134", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                int ta1Index = (i - 1) % 6;
                int ta2Index = i % 6;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 90 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 14 tasks, 6 TAs, uniform distribution (90-160)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 15 tasks, 3 TAs (100-170)
        /// </summary>
        public static ProblemInstance Small_135(string name = "small_135", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                int ta1Index = (i - 1) % 3;
                int ta2Index = i % 3;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 100 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 15 tasks, 3 TAs, uniform distribution (100-170)"
            };
        }

        /// <summary>
        /// Creates a small instance with uniform distribution: 16 tasks, 4 TAs (110-185)
        /// </summary>
        public static ProblemInstance Small_136(string name = "small_136", int seed = 42)
        {
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 16; i++)
            {
                int ta1Index = (i - 1) % 4;
                int ta2Index = i % 4;
                var eligibleTAs = new List<TAInfo> { tas[ta1Index], tas[ta2Index] };
                int processingTime = 110 + ((i - 1) * 5); // Uniform distribution

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
                Description = "Small instance: 16 tasks, 4 TAs, uniform distribution (110-185)"
            };
        }

        // ========== BIMODAL DISTRIBUTION INSTANCES (50 instances) ==========

        /// <summary>
        /// Creates a small instance with bimodal distribution: 8 tasks, 3 TAs (5-15 and 150-200)
        /// </summary>
        public static ProblemInstance Small_137(string name = "small_137", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (5 + random.Next(0, 11)) : // 75% chance: 5-15
                    (150 + random.Next(0, 51)); // 25% chance: 150-200

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
                Description = "Small instance: 8 tasks, 3 TAs, bimodal distribution (5-15 and 150-200)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 9 tasks, 4 TAs (10-20 and 180-220)
        /// </summary>
        public static ProblemInstance Small_138(string name = "small_138", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (10 + random.Next(0, 11)) : // 70% chance: 10-20
                    (180 + random.Next(0, 41)); // 30% chance: 180-220

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
                Description = "Small instance: 9 tasks, 4 TAs, bimodal distribution (10-20 and 180-220)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 10 tasks, 5 TAs (8-18 and 200-250)
        /// </summary>
        public static ProblemInstance Small_139(string name = "small_139", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (8 + random.Next(0, 11)) : // 80% chance: 8-18
                    (200 + random.Next(0, 51)); // 20% chance: 200-250

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
                Description = "Small instance: 10 tasks, 5 TAs, bimodal distribution (8-18 and 200-250)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 11 tasks, 3 TAs (12-22 and 160-190)
        /// </summary>
        public static ProblemInstance Small_140(string name = "small_140", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (12 + random.Next(0, 11)) : // 75% chance: 12-22
                    (160 + random.Next(0, 31)); // 25% chance: 160-190

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
                Description = "Small instance: 11 tasks, 3 TAs, bimodal distribution (12-22 and 160-190)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 12 tasks, 6 TAs (15-25 and 170-200)
        /// </summary>
        public static ProblemInstance Small_141(string name = "small_141", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (15 + random.Next(0, 11)) : // 70% chance: 15-25
                    (170 + random.Next(0, 31)); // 30% chance: 170-200

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
                Description = "Small instance: 12 tasks, 6 TAs, bimodal distribution (15-25 and 170-200)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 13 tasks, 4 TAs (6-16 and 190-240)
        /// </summary>
        public static ProblemInstance Small_142(string name = "small_142", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (6 + random.Next(0, 11)) : // 80% chance: 6-16
                    (190 + random.Next(0, 51)); // 20% chance: 190-240

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
                Description = "Small instance: 13 tasks, 4 TAs, bimodal distribution (6-16 and 190-240)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 14 tasks, 5 TAs (9-19 and 210-260)
        /// </summary>
        public static ProblemInstance Small_143(string name = "small_143", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (9 + random.Next(0, 11)) : // 75% chance: 9-19
                    (210 + random.Next(0, 51)); // 25% chance: 210-260

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
                Description = "Small instance: 14 tasks, 5 TAs, bimodal distribution (9-19 and 210-260)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 15 tasks, 3 TAs (7-17 and 140-170)
        /// </summary>
        public static ProblemInstance Small_144(string name = "small_144", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (7 + random.Next(0, 11)) : // 80% chance: 7-17
                    (140 + random.Next(0, 31)); // 20% chance: 140-170

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
                Description = "Small instance: 15 tasks, 3 TAs, bimodal distribution (7-17 and 140-170)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 8 tasks, 7 TAs (11-21 and 220-270)
        /// </summary>
        public static ProblemInstance Small_145(string name = "small_145", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (11 + random.Next(0, 11)) : // 70% chance: 11-21
                    (220 + random.Next(0, 51)); // 30% chance: 220-270

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
                Description = "Small instance: 8 tasks, 7 TAs, bimodal distribution (11-21 and 220-270)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 9 tasks, 8 TAs (13-23 and 230-280)
        /// </summary>
        public static ProblemInstance Small_146(string name = "small_146", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (13 + random.Next(0, 11)) : // 75% chance: 13-23
                    (230 + random.Next(0, 51)); // 25% chance: 230-280

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
                Description = "Small instance: 9 tasks, 8 TAs, bimodal distribution (13-23 and 230-280)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 10 tasks, 6 TAs (4-14 and 250-300)
        /// </summary>
        public static ProblemInstance Small_147(string name = "small_147", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (4 + random.Next(0, 11)) : // 80% chance: 4-14
                    (250 + random.Next(0, 51)); // 20% chance: 250-300

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
                Description = "Small instance: 10 tasks, 6 TAs, bimodal distribution (4-14 and 250-300)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 11 tasks, 4 TAs (14-24 and 240-290)
        /// </summary>
        public static ProblemInstance Small_148(string name = "small_148", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (14 + random.Next(0, 11)) : // 70% chance: 14-24
                    (240 + random.Next(0, 51)); // 30% chance: 240-290

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
                Description = "Small instance: 11 tasks, 4 TAs, bimodal distribution (14-24 and 240-290)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 12 tasks, 5 TAs (16-26 and 260-310)
        /// </summary>
        public static ProblemInstance Small_149(string name = "small_149", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (16 + random.Next(0, 11)) : // 75% chance: 16-26
                    (260 + random.Next(0, 51)); // 25% chance: 260-310

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
                Description = "Small instance: 12 tasks, 5 TAs, bimodal distribution (16-26 and 260-310)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 13 tasks, 3 TAs (18-28 and 270-320)
        /// </summary>
        public static ProblemInstance Small_150(string name = "small_150", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (18 + random.Next(0, 11)) : // 80% chance: 18-28
                    (270 + random.Next(0, 51)); // 20% chance: 270-320

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
                Description = "Small instance: 13 tasks, 3 TAs, bimodal distribution (18-28 and 270-320)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 14 tasks, 6 TAs (20-30 and 280-330)
        /// </summary>
        public static ProblemInstance Small_151(string name = "small_151", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (20 + random.Next(0, 11)) : // 70% chance: 20-30
                    (280 + random.Next(0, 51)); // 30% chance: 280-330

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
                Description = "Small instance: 14 tasks, 6 TAs, bimodal distribution (20-30 and 280-330)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 15 tasks, 4 TAs (22-32 and 290-340)
        /// </summary>
        public static ProblemInstance Small_152(string name = "small_152", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (22 + random.Next(0, 11)) : // 75% chance: 22-32
                    (290 + random.Next(0, 51)); // 25% chance: 290-340

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
                Description = "Small instance: 15 tasks, 4 TAs, bimodal distribution (22-32 and 290-340)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 8 tasks, 5 TAs (3-13 and 300-350)
        /// </summary>
        public static ProblemInstance Small_153(string name = "small_153", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (3 + random.Next(0, 11)) : // 80% chance: 3-13
                    (300 + random.Next(0, 51)); // 20% chance: 300-350

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
                Description = "Small instance: 8 tasks, 5 TAs, bimodal distribution (3-13 and 300-350)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 9 tasks, 3 TAs (24-34 and 310-360)
        /// </summary>
        public static ProblemInstance Small_154(string name = "small_154", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (24 + random.Next(0, 11)) : // 70% chance: 24-34
                    (310 + random.Next(0, 51)); // 30% chance: 310-360

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
                Description = "Small instance: 9 tasks, 3 TAs, bimodal distribution (24-34 and 310-360)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 10 tasks, 7 TAs (26-36 and 320-370)
        /// </summary>
        public static ProblemInstance Small_155(string name = "small_155", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (26 + random.Next(0, 11)) : // 75% chance: 26-36
                    (320 + random.Next(0, 51)); // 25% chance: 320-370

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
                Description = "Small instance: 10 tasks, 7 TAs, bimodal distribution (26-36 and 320-370)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 11 tasks, 6 TAs (28-38 and 330-380)
        /// </summary>
        public static ProblemInstance Small_156(string name = "small_156", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (28 + random.Next(0, 11)) : // 80% chance: 28-38
                    (330 + random.Next(0, 51)); // 20% chance: 330-380

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
                Description = "Small instance: 11 tasks, 6 TAs, bimodal distribution (28-38 and 330-380)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 12 tasks, 4 TAs (30-40 and 340-390)
        /// </summary>
        public static ProblemInstance Small_157(string name = "small_157", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (30 + random.Next(0, 11)) : // 70% chance: 30-40
                    (340 + random.Next(0, 51)); // 30% chance: 340-390

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
                Description = "Small instance: 12 tasks, 4 TAs, bimodal distribution (30-40 and 340-390)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 13 tasks, 5 TAs (32-42 and 350-400)
        /// </summary>
        public static ProblemInstance Small_158(string name = "small_158", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (32 + random.Next(0, 11)) : // 75% chance: 32-42
                    (350 + random.Next(0, 51)); // 25% chance: 350-400

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
                Description = "Small instance: 13 tasks, 5 TAs, bimodal distribution (32-42 and 350-400)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 14 tasks, 3 TAs (34-44 and 360-410)
        /// </summary>
        public static ProblemInstance Small_159(string name = "small_159", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (34 + random.Next(0, 11)) : // 80% chance: 34-44
                    (360 + random.Next(0, 51)); // 20% chance: 360-410

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
                Description = "Small instance: 14 tasks, 3 TAs, bimodal distribution (34-44 and 360-410)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 15 tasks, 6 TAs (36-46 and 370-420)
        /// </summary>
        public static ProblemInstance Small_160(string name = "small_160", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (36 + random.Next(0, 11)) : // 70% chance: 36-46
                    (370 + random.Next(0, 51)); // 30% chance: 370-420

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
                Description = "Small instance: 15 tasks, 6 TAs, bimodal distribution (36-46 and 370-420)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 8 tasks, 4 TAs (38-48 and 380-430)
        /// </summary>
        public static ProblemInstance Small_161(string name = "small_161", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (38 + random.Next(0, 11)) : // 75% chance: 38-48
                    (380 + random.Next(0, 51)); // 25% chance: 380-430

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
                Description = "Small instance: 8 tasks, 4 TAs, bimodal distribution (38-48 and 380-430)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 9 tasks, 5 TAs (40-50 and 390-440)
        /// </summary>
        public static ProblemInstance Small_162(string name = "small_162", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (40 + random.Next(0, 11)) : // 80% chance: 40-50
                    (390 + random.Next(0, 51)); // 20% chance: 390-440

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
                Description = "Small instance: 9 tasks, 5 TAs, bimodal distribution (40-50 and 390-440)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 10 tasks, 3 TAs (42-52 and 400-450)
        /// </summary>
        public static ProblemInstance Small_163(string name = "small_163", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (42 + random.Next(0, 11)) : // 70% chance: 42-52
                    (400 + random.Next(0, 51)); // 30% chance: 400-450

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
                Description = "Small instance: 10 tasks, 3 TAs, bimodal distribution (42-52 and 400-450)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 11 tasks, 7 TAs (44-54 and 410-460)
        /// </summary>
        public static ProblemInstance Small_164(string name = "small_164", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (44 + random.Next(0, 11)) : // 75% chance: 44-54
                    (410 + random.Next(0, 51)); // 25% chance: 410-460

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
                Description = "Small instance: 11 tasks, 7 TAs, bimodal distribution (44-54 and 410-460)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 12 tasks, 8 TAs (46-56 and 420-470)
        /// </summary>
        public static ProblemInstance Small_165(string name = "small_165", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (46 + random.Next(0, 11)) : // 80% chance: 46-56
                    (420 + random.Next(0, 51)); // 20% chance: 420-470

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
                Description = "Small instance: 12 tasks, 8 TAs, bimodal distribution (46-56 and 420-470)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 13 tasks, 4 TAs (48-58 and 430-480)
        /// </summary>
        public static ProblemInstance Small_166(string name = "small_166", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (48 + random.Next(0, 11)) : // 70% chance: 48-58
                    (430 + random.Next(0, 51)); // 30% chance: 430-480

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
                Description = "Small instance: 13 tasks, 4 TAs, bimodal distribution (48-58 and 430-480)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 14 tasks, 5 TAs (50-60 and 440-490)
        /// </summary>
        public static ProblemInstance Small_167(string name = "small_167", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (50 + random.Next(0, 11)) : // 75% chance: 50-60
                    (440 + random.Next(0, 51)); // 25% chance: 440-490

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
                Description = "Small instance: 14 tasks, 5 TAs, bimodal distribution (50-60 and 440-490)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 15 tasks, 3 TAs (52-62 and 450-500)
        /// </summary>
        public static ProblemInstance Small_168(string name = "small_168", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (52 + random.Next(0, 11)) : // 80% chance: 52-62
                    (450 + random.Next(0, 51)); // 20% chance: 450-500

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
                Description = "Small instance: 15 tasks, 3 TAs, bimodal distribution (52-62 and 450-500)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 8 tasks, 6 TAs (54-64 and 460-510)
        /// </summary>
        public static ProblemInstance Small_169(string name = "small_169", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (54 + random.Next(0, 11)) : // 70% chance: 54-64
                    (460 + random.Next(0, 51)); // 30% chance: 460-510

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
                Description = "Small instance: 8 tasks, 6 TAs, bimodal distribution (54-64 and 460-510)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 9 tasks, 7 TAs (56-66 and 470-520)
        /// </summary>
        public static ProblemInstance Small_170(string name = "small_170", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (56 + random.Next(0, 11)) : // 75% chance: 56-66
                    (470 + random.Next(0, 51)); // 25% chance: 470-520

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
                Description = "Small instance: 9 tasks, 7 TAs, bimodal distribution (56-66 and 470-520)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 10 tasks, 4 TAs (58-68 and 480-530)
        /// </summary>
        public static ProblemInstance Small_171(string name = "small_171", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (58 + random.Next(0, 11)) : // 80% chance: 58-68
                    (480 + random.Next(0, 51)); // 20% chance: 480-530

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
                Description = "Small instance: 10 tasks, 4 TAs, bimodal distribution (58-68 and 480-530)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 11 tasks, 5 TAs (60-70 and 490-540)
        /// </summary>
        public static ProblemInstance Small_172(string name = "small_172", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (60 + random.Next(0, 11)) : // 70% chance: 60-70
                    (490 + random.Next(0, 51)); // 30% chance: 490-540

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
                Description = "Small instance: 11 tasks, 5 TAs, bimodal distribution (60-70 and 490-540)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 12 tasks, 3 TAs (62-72 and 500-550)
        /// </summary>
        public static ProblemInstance Small_173(string name = "small_173", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (62 + random.Next(0, 11)) : // 75% chance: 62-72
                    (500 + random.Next(0, 51)); // 25% chance: 500-550

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
                Description = "Small instance: 12 tasks, 3 TAs, bimodal distribution (62-72 and 500-550)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 13 tasks, 6 TAs (64-74 and 510-560)
        /// </summary>
        public static ProblemInstance Small_174(string name = "small_174", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (64 + random.Next(0, 11)) : // 80% chance: 64-74
                    (510 + random.Next(0, 51)); // 20% chance: 510-560

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
                Description = "Small instance: 13 tasks, 6 TAs, bimodal distribution (64-74 and 510-560)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 14 tasks, 4 TAs (66-76 and 520-570)
        /// </summary>
        public static ProblemInstance Small_175(string name = "small_175", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (66 + random.Next(0, 11)) : // 70% chance: 66-76
                    (520 + random.Next(0, 51)); // 30% chance: 520-570

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
                Description = "Small instance: 14 tasks, 4 TAs, bimodal distribution (66-76 and 520-570)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 15 tasks, 5 TAs (68-78 and 530-580)
        /// </summary>
        public static ProblemInstance Small_176(string name = "small_176", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (68 + random.Next(0, 11)) : // 75% chance: 68-78
                    (530 + random.Next(0, 51)); // 25% chance: 530-580

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
                Description = "Small instance: 15 tasks, 5 TAs, bimodal distribution (68-78 and 530-580)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 8 tasks, 7 TAs (70-80 and 540-590)
        /// </summary>
        public static ProblemInstance Small_177(string name = "small_177", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (70 + random.Next(0, 11)) : // 80% chance: 70-80
                    (540 + random.Next(0, 51)); // 20% chance: 540-590

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
                Description = "Small instance: 8 tasks, 7 TAs, bimodal distribution (70-80 and 540-590)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 9 tasks, 8 TAs (72-82 and 550-600)
        /// </summary>
        public static ProblemInstance Small_178(string name = "small_178", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (72 + random.Next(0, 11)) : // 70% chance: 72-82
                    (550 + random.Next(0, 51)); // 30% chance: 550-600

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
                Description = "Small instance: 9 tasks, 8 TAs, bimodal distribution (72-82 and 550-600)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 10 tasks, 6 TAs (74-84 and 560-610)
        /// </summary>
        public static ProblemInstance Small_179(string name = "small_179", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (74 + random.Next(0, 11)) : // 75% chance: 74-84
                    (560 + random.Next(0, 51)); // 25% chance: 560-610

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
                Description = "Small instance: 10 tasks, 6 TAs, bimodal distribution (74-84 and 560-610)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 11 tasks, 4 TAs (76-86 and 570-620)
        /// </summary>
        public static ProblemInstance Small_180(string name = "small_180", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (76 + random.Next(0, 11)) : // 80% chance: 76-86
                    (570 + random.Next(0, 51)); // 20% chance: 570-620

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
                Description = "Small instance: 11 tasks, 4 TAs, bimodal distribution (76-86 and 570-620)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 12 tasks, 5 TAs (78-88 and 580-630)
        /// </summary>
        public static ProblemInstance Small_181(string name = "small_181", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (78 + random.Next(0, 11)) : // 70% chance: 78-88
                    (580 + random.Next(0, 51)); // 30% chance: 580-630

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
                Description = "Small instance: 12 tasks, 5 TAs, bimodal distribution (78-88 and 580-630)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 13 tasks, 3 TAs (80-90 and 590-640)
        /// </summary>
        public static ProblemInstance Small_182(string name = "small_182", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (80 + random.Next(0, 11)) : // 75% chance: 80-90
                    (590 + random.Next(0, 51)); // 25% chance: 590-640

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
                Description = "Small instance: 13 tasks, 3 TAs, bimodal distribution (80-90 and 590-640)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 14 tasks, 6 TAs (82-92 and 600-650)
        /// </summary>
        public static ProblemInstance Small_183(string name = "small_183", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (82 + random.Next(0, 11)) : // 80% chance: 82-92
                    (600 + random.Next(0, 51)); // 20% chance: 600-650

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
                Description = "Small instance: 14 tasks, 6 TAs, bimodal distribution (82-92 and 600-650)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 15 tasks, 4 TAs (84-94 and 610-660)
        /// </summary>
        public static ProblemInstance Small_184(string name = "small_184", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 70 ? 
                    (84 + random.Next(0, 11)) : // 70% chance: 84-94
                    (610 + random.Next(0, 51)); // 30% chance: 610-660

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
                Description = "Small instance: 15 tasks, 4 TAs, bimodal distribution (84-94 and 610-660)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 8 tasks, 5 TAs (86-96 and 620-670)
        /// </summary>
        public static ProblemInstance Small_185(string name = "small_185", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 75 ? 
                    (86 + random.Next(0, 11)) : // 75% chance: 86-96
                    (620 + random.Next(0, 51)); // 25% chance: 620-670

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
                Description = "Small instance: 8 tasks, 5 TAs, bimodal distribution (86-96 and 620-670)"
            };
        }

        /// <summary>
        /// Creates a small instance with bimodal distribution: 9 tasks, 6 TAs (88-98 and 630-680)
        /// </summary>
        public static ProblemInstance Small_186(string name = "small_186", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int processingTime = random.Next(0, 100) < 80 ? 
                    (88 + random.Next(0, 11)) : // 80% chance: 88-98
                    (630 + random.Next(0, 51)); // 20% chance: 630-680

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
                Description = "Small instance: 9 tasks, 6 TAs, bimodal distribution (88-98 and 630-680)"
            };
        }

        // ========== MIXED RANGES INSTANCES (26 instances) ==========

        /// <summary>
        /// Creates a small instance with mixed ranges: 8 tasks, 3 TAs (mixed: 5-15, 30-50, 80-120)
        /// </summary>
        public static ProblemInstance Small_187(string name = "small_187", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (5 + random.Next(0, 11)) : // 5-15
                                     range == 1 ? (30 + random.Next(0, 21)) : // 30-50
                                     (80 + random.Next(0, 41)); // 80-120

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
                Description = "Small instance: 8 tasks, 3 TAs, mixed ranges (5-15, 30-50, 80-120)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 9 tasks, 4 TAs (mixed: 10-25, 40-65, 100-150)
        /// </summary>
        public static ProblemInstance Small_188(string name = "small_188", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (10 + random.Next(0, 16)) : // 10-25
                                     range == 1 ? (40 + random.Next(0, 26)) : // 40-65
                                     (100 + random.Next(0, 51)); // 100-150

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
                Description = "Small instance: 9 tasks, 4 TAs, mixed ranges (10-25, 40-65, 100-150)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 10 tasks, 5 TAs (mixed: 15-30, 50-75, 120-180)
        /// </summary>
        public static ProblemInstance Small_189(string name = "small_189", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (15 + random.Next(0, 16)) : // 15-30
                                     range == 1 ? (50 + random.Next(0, 26)) : // 50-75
                                     (120 + random.Next(0, 61)); // 120-180

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
                Description = "Small instance: 10 tasks, 5 TAs, mixed ranges (15-30, 50-75, 120-180)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 11 tasks, 3 TAs (mixed: 8-20, 35-55, 90-130)
        /// </summary>
        public static ProblemInstance Small_190(string name = "small_190", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (8 + random.Next(0, 13)) : // 8-20
                                     range == 1 ? (35 + random.Next(0, 21)) : // 35-55
                                     (90 + random.Next(0, 41)); // 90-130

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
                Description = "Small instance: 11 tasks, 3 TAs, mixed ranges (8-20, 35-55, 90-130)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 12 tasks, 6 TAs (mixed: 12-28, 45-70, 110-160)
        /// </summary>
        public static ProblemInstance Small_191(string name = "small_191", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (12 + random.Next(0, 17)) : // 12-28
                                     range == 1 ? (45 + random.Next(0, 26)) : // 45-70
                                     (110 + random.Next(0, 51)); // 110-160

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
                Description = "Small instance: 12 tasks, 6 TAs, mixed ranges (12-28, 45-70, 110-160)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 13 tasks, 4 TAs (mixed: 6-18, 38-58, 95-140)
        /// </summary>
        public static ProblemInstance Small_192(string name = "small_192", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (6 + random.Next(0, 13)) : // 6-18
                                     range == 1 ? (38 + random.Next(0, 21)) : // 38-58
                                     (95 + random.Next(0, 46)); // 95-140

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
                Description = "Small instance: 13 tasks, 4 TAs, mixed ranges (6-18, 38-58, 95-140)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 14 tasks, 5 TAs (mixed: 20-35, 55-80, 130-190)
        /// </summary>
        public static ProblemInstance Small_193(string name = "small_193", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (20 + random.Next(0, 16)) : // 20-35
                                     range == 1 ? (55 + random.Next(0, 26)) : // 55-80
                                     (130 + random.Next(0, 61)); // 130-190

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
                Description = "Small instance: 14 tasks, 5 TAs, mixed ranges (20-35, 55-80, 130-190)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 15 tasks, 3 TAs (mixed: 3-12, 25-45, 70-110)
        /// </summary>
        public static ProblemInstance Small_194(string name = "small_194", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (3 + random.Next(0, 10)) : // 3-12
                                     range == 1 ? (25 + random.Next(0, 21)) : // 25-45
                                     (70 + random.Next(0, 41)); // 70-110

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
                Description = "Small instance: 15 tasks, 3 TAs, mixed ranges (3-12, 25-45, 70-110)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 8 tasks, 7 TAs (mixed: 18-32, 48-68, 105-155)
        /// </summary>
        public static ProblemInstance Small_195(string name = "small_195", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (18 + random.Next(0, 15)) : // 18-32
                                     range == 1 ? (48 + random.Next(0, 21)) : // 48-68
                                     (105 + random.Next(0, 51)); // 105-155

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
                Description = "Small instance: 8 tasks, 7 TAs, mixed ranges (18-32, 48-68, 105-155)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 9 tasks, 8 TAs (mixed: 22-38, 60-85, 140-200)
        /// </summary>
        public static ProblemInstance Small_196(string name = "small_196", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (22 + random.Next(0, 17)) : // 22-38
                                     range == 1 ? (60 + random.Next(0, 26)) : // 60-85
                                     (140 + random.Next(0, 61)); // 140-200

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
                Description = "Small instance: 9 tasks, 8 TAs, mixed ranges (22-38, 60-85, 140-200)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 10 tasks, 6 TAs (mixed: 7-22, 42-62, 115-170)
        /// </summary>
        public static ProblemInstance Small_197(string name = "small_197", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (7 + random.Next(0, 16)) : // 7-22
                                     range == 1 ? (42 + random.Next(0, 21)) : // 42-62
                                     (115 + random.Next(0, 56)); // 115-170

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
                Description = "Small instance: 10 tasks, 6 TAs, mixed ranges (7-22, 42-62, 115-170)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 11 tasks, 4 TAs (mixed: 14-26, 52-72, 125-180)
        /// </summary>
        public static ProblemInstance Small_198(string name = "small_198", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (14 + random.Next(0, 13)) : // 14-26
                                     range == 1 ? (52 + random.Next(0, 21)) : // 52-72
                                     (125 + random.Next(0, 56)); // 125-180

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
                Description = "Small instance: 11 tasks, 4 TAs, mixed ranges (14-26, 52-72, 125-180)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 12 tasks, 5 TAs (mixed: 9-24, 58-78, 135-195)
        /// </summary>
        public static ProblemInstance Small_199(string name = "small_199", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (9 + random.Next(0, 16)) : // 9-24
                                     range == 1 ? (58 + random.Next(0, 21)) : // 58-78
                                     (135 + random.Next(0, 61)); // 135-195

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
                Description = "Small instance: 12 tasks, 5 TAs, mixed ranges (9-24, 58-78, 135-195)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 13 tasks, 6 TAs (mixed: 11-27, 65-90, 150-210)
        /// </summary>
        public static ProblemInstance Small_200(string name = "small_200", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (11 + random.Next(0, 17)) : // 11-27
                                     range == 1 ? (65 + random.Next(0, 26)) : // 65-90
                                     (150 + random.Next(0, 61)); // 150-210

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
                Description = "Small instance: 13 tasks, 6 TAs, mixed ranges (11-27, 65-90, 150-210)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 14 tasks, 3 TAs (mixed: 4-16, 32-52, 85-125)
        /// </summary>
        public static ProblemInstance Small_201(string name = "small_201", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (4 + random.Next(0, 13)) : // 4-16
                                     range == 1 ? (32 + random.Next(0, 21)) : // 32-52
                                     (85 + random.Next(0, 41)); // 85-125

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
                Description = "Small instance: 14 tasks, 3 TAs, mixed ranges (4-16, 32-52, 85-125)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 15 tasks, 7 TAs (mixed: 16-31, 70-95, 160-220)
        /// </summary>
        public static ProblemInstance Small_202(string name = "small_202", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (16 + random.Next(0, 16)) : // 16-31
                                     range == 1 ? (70 + random.Next(0, 26)) : // 70-95
                                     (160 + random.Next(0, 61)); // 160-220

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
                Description = "Small instance: 15 tasks, 7 TAs, mixed ranges (16-31, 70-95, 160-220)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 8 tasks, 4 TAs (mixed: 13-29, 75-100, 145-205)
        /// </summary>
        public static ProblemInstance Small_203(string name = "small_203", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (13 + random.Next(0, 17)) : // 13-29
                                     range == 1 ? (75 + random.Next(0, 26)) : // 75-100
                                     (145 + random.Next(0, 61)); // 145-205

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
                Description = "Small instance: 8 tasks, 4 TAs, mixed ranges (13-29, 75-100, 145-205)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 9 tasks, 5 TAs (mixed: 19-34, 62-87, 155-215)
        /// </summary>
        public static ProblemInstance Small_204(string name = "small_204", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (19 + random.Next(0, 16)) : // 19-34
                                     range == 1 ? (62 + random.Next(0, 26)) : // 62-87
                                     (155 + random.Next(0, 61)); // 155-215

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
                Description = "Small instance: 9 tasks, 5 TAs, mixed ranges (19-34, 62-87, 155-215)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 10 tasks, 3 TAs (mixed: 2-14, 28-48, 75-115)
        /// </summary>
        public static ProblemInstance Small_205(string name = "small_205", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 10; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (2 + random.Next(0, 13)) : // 2-14
                                     range == 1 ? (28 + random.Next(0, 21)) : // 28-48
                                     (75 + random.Next(0, 41)); // 75-115

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
                Description = "Small instance: 10 tasks, 3 TAs, mixed ranges (2-14, 28-48, 75-115)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 11 tasks, 8 TAs (mixed: 24-40, 68-93, 165-225)
        /// </summary>
        public static ProblemInstance Small_206(string name = "small_206", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6", "TA7", "TA8" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 11; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (24 + random.Next(0, 17)) : // 24-40
                                     range == 1 ? (68 + random.Next(0, 26)) : // 68-93
                                     (165 + random.Next(0, 61)); // 165-225

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
                Description = "Small instance: 11 tasks, 8 TAs, mixed ranges (24-40, 68-93, 165-225)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 12 tasks, 4 TAs (mixed: 17-33, 72-97, 170-230)
        /// </summary>
        public static ProblemInstance Small_207(string name = "small_207", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (17 + random.Next(0, 17)) : // 17-33
                                     range == 1 ? (72 + random.Next(0, 26)) : // 72-97
                                     (170 + random.Next(0, 61)); // 170-230

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
                Description = "Small instance: 12 tasks, 4 TAs, mixed ranges (17-33, 72-97, 170-230)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 13 tasks, 5 TAs (mixed: 21-37, 78-103, 175-235)
        /// </summary>
        public static ProblemInstance Small_208(string name = "small_208", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 13; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (21 + random.Next(0, 17)) : // 21-37
                                     range == 1 ? (78 + random.Next(0, 26)) : // 78-103
                                     (175 + random.Next(0, 61)); // 175-235

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
                Description = "Small instance: 13 tasks, 5 TAs, mixed ranges (21-37, 78-103, 175-235)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 14 tasks, 6 TAs (mixed: 26-42, 82-107, 180-240)
        /// </summary>
        public static ProblemInstance Small_209(string name = "small_209", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5", "TA6" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 14; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (26 + random.Next(0, 17)) : // 26-42
                                     range == 1 ? (82 + random.Next(0, 26)) : // 82-107
                                     (180 + random.Next(0, 61)); // 180-240

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
                Description = "Small instance: 14 tasks, 6 TAs, mixed ranges (26-42, 82-107, 180-240)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 15 tasks, 3 TAs (mixed: 1-10, 20-40, 65-105)
        /// </summary>
        public static ProblemInstance Small_210(string name = "small_210", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 15; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (1 + random.Next(0, 10)) : // 1-10
                                     range == 1 ? (20 + random.Next(0, 21)) : // 20-40
                                     (65 + random.Next(0, 41)); // 65-105

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
                Description = "Small instance: 15 tasks, 3 TAs, mixed ranges (1-10, 20-40, 65-105)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 8 tasks, 4 TAs (mixed: 27-43, 88-113, 185-245)
        /// </summary>
        public static ProblemInstance Small_211(string name = "small_211", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 8; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (27 + random.Next(0, 17)) : // 27-43
                                     range == 1 ? (88 + random.Next(0, 26)) : // 88-113
                                     (185 + random.Next(0, 61)); // 185-245

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
                Description = "Small instance: 8 tasks, 4 TAs, mixed ranges (27-43, 88-113, 185-245)"
            };
        }

        /// <summary>
        /// Creates a small instance with mixed ranges: 9 tasks, 5 TAs (mixed: 29-45, 92-117, 190-250)
        /// </summary>
        public static ProblemInstance Small_212(string name = "small_212", int seed = 42)
        {
            var random = new Random(seed);
            var tasks = new List<TaskInfo>();
            var taNames = new List<string> { "TA1", "TA2", "TA3", "TA4", "TA5" };
            var tas = taNames.Select(n => new TAInfo { Name = n }).ToList();

            for (int i = 1; i <= 9; i++)
            {
                var selectedTAs = tas.OrderBy(x => random.Next()).Take(2).ToList();
                int range = i % 3;
                int processingTime = range == 0 ? (29 + random.Next(0, 17)) : // 29-45
                                     range == 1 ? (92 + random.Next(0, 26)) : // 92-117
                                     (190 + random.Next(0, 61)); // 190-250

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
                Description = "Small instance: 9 tasks, 5 TAs, mixed ranges (29-45, 92-117, 190-250)"
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

        /// <summary>
        /// Generates instances based on Uniform distribution
        /// Cycles through uniform distribution functions (Small_112 to Small_136) with different seeds
        /// </summary>
        public static IEnumerable<ProblemInstance> GenerateUniformDistributionInstances(int count = 425, int startSeed = 2000)
        {
            var uniformFunctions = new Func<int, int, ProblemInstance>[]
            {
                (nameSuffix, seed) => Small_112($"uniform_112_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_113($"uniform_113_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_114($"uniform_114_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_115($"uniform_115_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_116($"uniform_116_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_117($"uniform_117_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_118($"uniform_118_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_119($"uniform_119_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_120($"uniform_120_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_121($"uniform_121_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_122($"uniform_122_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_123($"uniform_123_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_124($"uniform_124_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_125($"uniform_125_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_126($"uniform_126_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_127($"uniform_127_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_128($"uniform_128_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_129($"uniform_129_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_130($"uniform_130_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_131($"uniform_131_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_132($"uniform_132_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_133($"uniform_133_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_134($"uniform_134_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_135($"uniform_135_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_136($"uniform_136_v{nameSuffix}", seed)
            };

            for (int i = 1; i <= count; i++)
            {
                int functionIndex = (i - 1) % uniformFunctions.Length;
                int seed = startSeed + i;
                yield return uniformFunctions[functionIndex](i, seed);
            }
        }

        /// <summary>
        /// Generates instances based on Bimodal distribution
        /// Cycles through bimodal distribution functions (Small_137 to Small_186) with different seeds
        /// </summary>
        public static IEnumerable<ProblemInstance> GenerateBimodalDistributionInstances(int count = 425, int startSeed = 3000)
        {
            var bimodalFunctions = new Func<int, int, ProblemInstance>[]
            {
                (nameSuffix, seed) => Small_137($"bimodal_137_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_138($"bimodal_138_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_139($"bimodal_139_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_140($"bimodal_140_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_141($"bimodal_141_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_142($"bimodal_142_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_143($"bimodal_143_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_144($"bimodal_144_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_145($"bimodal_145_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_146($"bimodal_146_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_147($"bimodal_147_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_148($"bimodal_148_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_149($"bimodal_149_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_150($"bimodal_150_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_151($"bimodal_151_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_152($"bimodal_152_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_153($"bimodal_153_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_154($"bimodal_154_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_155($"bimodal_155_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_156($"bimodal_156_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_157($"bimodal_157_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_158($"bimodal_158_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_159($"bimodal_159_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_160($"bimodal_160_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_161($"bimodal_161_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_162($"bimodal_162_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_163($"bimodal_163_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_164($"bimodal_164_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_165($"bimodal_165_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_166($"bimodal_166_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_167($"bimodal_167_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_168($"bimodal_168_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_169($"bimodal_169_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_170($"bimodal_170_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_171($"bimodal_171_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_172($"bimodal_172_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_173($"bimodal_173_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_174($"bimodal_174_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_175($"bimodal_175_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_176($"bimodal_176_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_177($"bimodal_177_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_178($"bimodal_178_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_179($"bimodal_179_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_180($"bimodal_180_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_181($"bimodal_181_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_182($"bimodal_182_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_183($"bimodal_183_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_184($"bimodal_184_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_185($"bimodal_185_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_186($"bimodal_186_v{nameSuffix}", seed)
            };

            for (int i = 1; i <= count; i++)
            {
                int functionIndex = (i - 1) % bimodalFunctions.Length;
                int seed = startSeed + i;
                yield return bimodalFunctions[functionIndex](i, seed);
            }
        }

        /// <summary>
        /// Generates instances based on Mixed ranges distribution
        /// Cycles through mixed ranges functions (Small_187 to Small_212) with different seeds
        /// </summary>
        public static IEnumerable<ProblemInstance> GenerateMixedRangesInstances(int count = 425, int startSeed = 4000)
        {
            var mixedRangesFunctions = new Func<int, int, ProblemInstance>[]
            {
                (nameSuffix, seed) => Small_187($"mixed_187_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_188($"mixed_188_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_189($"mixed_189_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_190($"mixed_190_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_191($"mixed_191_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_192($"mixed_192_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_193($"mixed_193_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_194($"mixed_194_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_195($"mixed_195_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_196($"mixed_196_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_197($"mixed_197_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_198($"mixed_198_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_199($"mixed_199_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_200($"mixed_200_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_201($"mixed_201_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_202($"mixed_202_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_203($"mixed_203_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_204($"mixed_204_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_205($"mixed_205_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_206($"mixed_206_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_207($"mixed_207_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_208($"mixed_208_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_209($"mixed_209_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_210($"mixed_210_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_211($"mixed_211_v{nameSuffix}", seed),
                (nameSuffix, seed) => Small_212($"mixed_212_v{nameSuffix}", seed)
            };

            for (int i = 1; i <= count; i++)
            {
                int functionIndex = (i - 1) % mixedRangesFunctions.Length;
                int seed = startSeed + i;
                yield return mixedRangesFunctions[functionIndex](i, seed);
            }
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
            // Uniform distribution instances (25 instances)
            yield return Small_112();
            yield return Small_113();
            yield return Small_114();
            yield return Small_115();
            yield return Small_116();
            yield return Small_117();
            yield return Small_118();
            yield return Small_119();
            yield return Small_120();
            yield return Small_121();
            yield return Small_122();
            yield return Small_123();
            yield return Small_124();
            yield return Small_125();
            yield return Small_126();
            yield return Small_127();
            yield return Small_128();
            yield return Small_129();
            yield return Small_130();
            yield return Small_131();
            yield return Small_132();
            yield return Small_133();
            yield return Small_134();
            yield return Small_135();
            yield return Small_136();
            // Bimodal distribution instances (50 instances)
            yield return Small_137();
            yield return Small_138();
            yield return Small_139();
            yield return Small_140();
            yield return Small_141();
            yield return Small_142();
            yield return Small_143();
            yield return Small_144();
            yield return Small_145();
            yield return Small_146();
            yield return Small_147();
            yield return Small_148();
            yield return Small_149();
            yield return Small_150();
            yield return Small_151();
            yield return Small_152();
            yield return Small_153();
            yield return Small_154();
            yield return Small_155();
            yield return Small_156();
            yield return Small_157();
            yield return Small_158();
            yield return Small_159();
            yield return Small_160();
            yield return Small_161();
            yield return Small_162();
            yield return Small_163();
            yield return Small_164();
            yield return Small_165();
            yield return Small_166();
            yield return Small_167();
            yield return Small_168();
            yield return Small_169();
            yield return Small_170();
            yield return Small_171();
            yield return Small_172();
            yield return Small_173();
            yield return Small_174();
            yield return Small_175();
            yield return Small_176();
            yield return Small_177();
            yield return Small_178();
            yield return Small_179();
            yield return Small_180();
            yield return Small_181();
            yield return Small_182();
            yield return Small_183();
            yield return Small_184();
            yield return Small_185();
            yield return Small_186();
            // Mixed ranges instances (26 instances)
            yield return Small_187();
            yield return Small_188();
            yield return Small_189();
            yield return Small_190();
            yield return Small_191();
            yield return Small_192();
            yield return Small_193();
            yield return Small_194();
            yield return Small_195();
            yield return Small_196();
            yield return Small_197();
            yield return Small_198();
            yield return Small_199();
            yield return Small_200();
            yield return Small_201();
            yield return Small_202();
            yield return Small_203();
            yield return Small_204();
            yield return Small_205();
            yield return Small_206();
            yield return Small_207();
            yield return Small_208();
            yield return Small_209();
            yield return Small_210();
            yield return Small_211();
            yield return Small_212();
            
            // Generate 425 instances for each distribution type using the new methods (total ~1500 instances)
            foreach (var instance in GenerateUniformDistributionInstances())
            {
                yield return instance;
            }
            
            foreach (var instance in GenerateBimodalDistributionInstances())
            {
                yield return instance;
            }
            
            foreach (var instance in GenerateMixedRangesInstances())
            {
                yield return instance;
            }
            
            yield return Big_1();
            yield return Big_2();
            yield return Big_3();
            yield return Big_4();
            yield return Big_5();
        }
    }
}
