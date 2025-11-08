using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.Greedy
{
    /// <summary>
    /// Defines different sorting strategies for the greedy algorithm
    /// </summary>
    public enum GreedySortStrategy
    {
        /// <summary>
        /// Sort by maximum processing time across eligible TAs (LPT-like)
        /// </summary>
        MaxProcessingTime,

        /// <summary>
        /// Sort by minimum processing time across eligible TAs
        /// </summary>
        MinProcessingTime,

        /// <summary>
        /// Sort by range of processing times (max - min)
        /// </summary>
        ProcessingTimeRange,

        /// <summary>
        /// Sort by number of eligible TAs (ascending - most constrained first)
        /// </summary>
        LeastEligible,

        /// <summary>
        /// No sorting - process tasks in given order
        /// </summary>
        NoSorting
    }

    /// <summary>
    /// Eligibility-aware greedy heuristic for task scheduling.
    /// Time Complexity: O(n log n + Σ|E_i|) where E_i is the eligibility set for task i
    /// </summary>
    public class GreedySolver
    {
        private readonly GreedySortStrategy _sortStrategy;

        public GreedySolver(GreedySortStrategy sortStrategy = GreedySortStrategy.MaxProcessingTime)
        {
            _sortStrategy = sortStrategy;
        }

        /// <summary>
        /// Solves the scheduling problem using an eligibility-aware greedy heuristic
        /// </summary>
        public SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            var stopwatch = Stopwatch.StartNew();

            // Initialize loads for all TAs
            var loads = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                loads[ta.Name] = 0;
            }

            // Sort tasks according to strategy
            var sortedTasks = SortTasks(problem.Tasks);

            // Greedy assignment
            var assignment = new Dictionary<string, string>();
            foreach (var task in sortedTasks)
            {
                // Find the eligible TA that minimizes the resulting load
                string bestTA = FindBestTA(task, loads);
                assignment[task.Name] = bestTA;
                loads[bestTA] += task.ProcessingTimes[bestTA];
            }

            stopwatch.Stop();

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                AlgorithmName = $"Greedy ({_sortStrategy})"
            };
        }

        /// <summary>
        /// Sorts tasks according to the specified strategy
        /// </summary>
        private List<TaskInfo> SortTasks(List<TaskInfo> tasks)
        {
            return _sortStrategy switch
            {
                GreedySortStrategy.MaxProcessingTime => 
                    tasks.OrderByDescending(t => t.MaxProcessingTime).ToList(),
                
                GreedySortStrategy.MinProcessingTime => 
                    tasks.OrderByDescending(t => t.MinProcessingTime).ToList(),
                
                GreedySortStrategy.ProcessingTimeRange => 
                    tasks.OrderByDescending(t => t.ProcessingTimeRange).ToList(),
                
                GreedySortStrategy.LeastEligible => 
                    tasks.OrderBy(t => t.EligibleTAs.Count)
                         .ThenByDescending(t => t.MaxProcessingTime)
                         .ToList(),
                
                GreedySortStrategy.NoSorting => 
                    new List<TaskInfo>(tasks),
                
                _ => tasks.OrderByDescending(t => t.MaxProcessingTime).ToList()
            };
        }

        /// <summary>
        /// Finds the best TA for a task - the one that minimizes the resulting load
        /// </summary>
        private string FindBestTA(TaskInfo task, Dictionary<string, int> currentLoads)
        {
            string bestTA = task.EligibleTAs[0].Name;
            int bestResultingLoad = currentLoads[bestTA] + task.ProcessingTimes[bestTA];

            foreach (var ta in task.EligibleTAs.Skip(1))
            {
                int resultingLoad = currentLoads[ta.Name] + task.ProcessingTimes[ta.Name];
                if (resultingLoad < bestResultingLoad)
                {
                    bestTA = ta.Name;
                    bestResultingLoad = resultingLoad;
                }
            }

            return bestTA;
        }
    }

    /// <summary>
    /// Enhanced greedy solver with local improvement (optional post-processing)
    /// </summary>
    public class GreedyWithLocalImprovement
    {
        private readonly GreedySortStrategy _sortStrategy;
        private readonly int _maxIterations;

        public GreedyWithLocalImprovement(
            GreedySortStrategy sortStrategy = GreedySortStrategy.MaxProcessingTime,
            int maxIterations = 100)
        {
            _sortStrategy = sortStrategy;
            _maxIterations = maxIterations;
        }

        /// <summary>
        /// Solves using greedy then applies local improvement moves
        /// </summary>
        public SchedulingResult Solve(ProblemInstance problem)
        {
            var stopwatch = Stopwatch.StartNew();

            // Get initial greedy solution
            var greedySolver = new GreedySolver(_sortStrategy);
            var initialResult = greedySolver.Solve(problem);

            var assignment = new Dictionary<string, string>(initialResult.Assignment);
            var loads = new Dictionary<string, int>(initialResult.Loads);
            int makespan = initialResult.Makespan;

            // Try local improvements
            bool improved = true;
            int iteration = 0;

            while (improved && iteration < _maxIterations)
            {
                improved = false;
                iteration++;

                // Try moving each task to a different eligible TA
                foreach (var task in problem.Tasks)
                {
                    string currentTA = assignment[task.Name];
                    int currentTaskTime = task.ProcessingTimes[currentTA];

                    foreach (var newTA in task.EligibleTAs)
                    {
                        if (newTA.Name == currentTA) continue;

                        int newTaskTime = task.ProcessingTimes[newTA.Name];

                        // Calculate new loads if we make this move
                        int newLoadCurrent = loads[currentTA] - currentTaskTime;
                        int newLoadNew = loads[newTA.Name] + newTaskTime;
                        int newMakespan = Math.Max(
                            Math.Max(newLoadCurrent, newLoadNew),
                            loads.Where(kvp => kvp.Key != currentTA && kvp.Key != newTA.Name)
                                 .Select(kvp => kvp.Value)
                                 .DefaultIfEmpty(0)
                                 .Max()
                        );

                        // If this improves makespan, make the move
                        if (newMakespan < makespan)
                        {
                            loads[currentTA] = newLoadCurrent;
                            loads[newTA.Name] = newLoadNew;
                            assignment[task.Name] = newTA.Name;
                            makespan = newMakespan;
                            improved = true;
                            break; // Move to next task after finding improvement
                        }
                    }

                    if (improved) break; // Restart from first task after improvement
                }
            }

            stopwatch.Stop();

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                AlgorithmName = $"Greedy + Local Improvement ({_sortStrategy}, {iteration} iterations)"
            };
        }
    }

    /// <summary>
    /// Eligibility-aware LPT with constraint prioritization for uniform durations.
    /// Assumes each task has a uniform processing time across eligible TAs.
    /// If not strictly uniform in the dataset, uses the minimum processing time as proxy for p_i.
    /// </summary>
    public class EligibilityAwareLptUniform
    {
        /// <summary>
        /// Solves using: sort by descending p_i, assign to least-loaded eligible TA,
        /// tie-break by TA with minimum constraint count (eligible for fewer tasks overall).
        /// </summary>
        public SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            var stopwatch = Stopwatch.StartNew();

            // Precompute uniform p_i per task: if data is not uniform, use min processing time as proxy
            var taskUniformTimes = new Dictionary<string, int>();
            foreach (var task in problem.Tasks)
            {
                int uniformPi = task.ProcessingTimes.Count > 0 ? task.ProcessingTimes.Values.Min() : 0;
                taskUniformTimes[task.Name] = uniformPi;
            }

            // Initialize loads per TA
            var loads = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                loads[ta.Name] = 0;
            }

            // Compute TA constraint counts: number of tasks for which TA is eligible
            var taConstraintCounts = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                int count = problem.Tasks.Count(t => t.EligibleTAs.Any(e => e.Name == ta.Name));
                taConstraintCounts[ta.Name] = count;
            }

            // Sort tasks by descending p_i (uniform times)
            var sortedTasks = problem.Tasks
                .OrderByDescending(t => taskUniformTimes[t.Name])
                .ToList();

            // Assignment map
            var assignment = new Dictionary<string, string>();

            // Main loop
            foreach (var task in sortedTasks)
            {
                var eligibleTAs = task.EligibleTAs.Select(x => x.Name).ToList();
                if (eligibleTAs.Count == 0)
                {
                    throw new InvalidOperationException($"Task {task.Name} has no eligible TAs");
                }

                // Find minimum current load among eligible TAs
                int minLoad = eligibleTAs.Min(tn => loads[tn]);
                var tieBest = eligibleTAs.Where(tn => loads[tn] == minLoad).ToList();

                // Tie-break: choose TA with minimum constraint count
                string chosenTA = tieBest
                    .OrderBy(tn => taConstraintCounts[tn])
                    .First();

                int pi = taskUniformTimes[task.Name];
                assignment[task.Name] = chosenTA;
              loads[chosenTA] += task.ProcessingTimes[chosenTA];  
            }

            stopwatch.Stop();

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                AlgorithmName = "Eligibility-aware LPT (Uniform)"
            };
        }
    }

    /// <summary>
    /// Simple greedy algorithm without any sorting - processes tasks in order
    /// </summary>
    public class GreedyNoSorting
    {
        public SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            var stopwatch = Stopwatch.StartNew();

            // Initialize loads per TA
            var loads = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                loads[ta.Name] = 0;
            }

            // Assignment map
            var assignment = new Dictionary<string, string>();

            // Process tasks in given order (no sorting)
            foreach (var task in problem.Tasks)
            {
                var eligibleTAs = task.EligibleTAs.Select(x => x.Name).ToList();
                if (eligibleTAs.Count == 0)
                {
                    throw new InvalidOperationException($"Task {task.Name} has no eligible TAs");
                }

                // Assign to eligible TA with minimum current load
                string chosenTA = eligibleTAs
                    .OrderBy(tn => loads[tn])
                    .First();

                assignment[task.Name] = chosenTA;
                loads[chosenTA] += task.ProcessingTimes[chosenTA];
            }

            stopwatch.Stop();

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                AlgorithmName = "Greedy (No Sorting)"
            };
        }
    }

    /// <summary>
    /// Greedy algorithm with task sorting only (by descending processing time)
    /// </summary>
    public class GreedyTaskSortingOnly
    {
        public SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            var stopwatch = Stopwatch.StartNew();

            // Initialize loads per TA
            var loads = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                loads[ta.Name] = 0;
            }

            // Sort tasks by descending max processing time
            var sortedTasks = problem.Tasks
                .OrderByDescending(t => t.MaxProcessingTime)
                .ToList();

            // Assignment map
            var assignment = new Dictionary<string, string>();

            // Process sorted tasks
            foreach (var task in sortedTasks)
            {
                var eligibleTAs = task.EligibleTAs.Select(x => x.Name).ToList();
                if (eligibleTAs.Count == 0)
                {
                    throw new InvalidOperationException($"Task {task.Name} has no eligible TAs");
                }

                // Assign to eligible TA with minimum current load
                string chosenTA = eligibleTAs
                    .OrderBy(tn => loads[tn])
                    .First();

                assignment[task.Name] = chosenTA;
                loads[chosenTA] += task.ProcessingTimes[chosenTA];
            }

            stopwatch.Stop();

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                ExecutionTimeMs = stopwatch.ElapsedMilliseconds,
                AlgorithmName = "Greedy (Task Sorting Only)"
            };
        }
    }
}

