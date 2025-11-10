using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.Greedy
{
    /// <summary>
    /// Eligibility-aware greedy heuristic for task scheduling.
    /// Sorts tasks by maximum processing time (LPT-like) and assigns to least-loaded eligible TA.
    /// Time Complexity: O(n log n + Σ|E_i|) where E_i is the eligibility set for task i
    /// </summary>
    public class GreedySolver
    {
        public GreedySolver()
        {
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

            // Initialize loads for all TAs
            var loads = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                loads[ta.Name] = 0;
            }

            // Sort tasks by descending max processing time (LPT-like)
            var sortedTasks = problem.Tasks
                .OrderByDescending(t => t.MaxProcessingTime)
                .ToList();

            // Greedy assignment
            var assignment = new Dictionary<string, string>();
            foreach (var task in sortedTasks)
            {
                // Find the eligible TA that minimizes the resulting load
                string bestTA = FindBestTA(task, loads);
                assignment[task.Name] = bestTA;
                loads[bestTA] += task.ProcessingTimes[bestTA];
            }

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                AlgorithmName = "Greedy (MaxProcessingTime)"
            };
        }

        /// <summary>
        /// Finds the best TA for a task - the one that minimizes the resulting load
        /// </summary>
        private string FindBestTA(TaskInfo task, Dictionary<string, int> currentLoads)
        {
            // Use the same approach as GreedyNoSorting for consistency
            var eligibleTAs = task.EligibleTAs.Select(x => x.Name).ToList();
            return eligibleTAs
                .OrderBy(tn => currentLoads[tn] + task.ProcessingTimes[tn])
                .First();
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

                // Assign to eligible TA that minimizes resulting load (current load + task processing time)
                string chosenTA = eligibleTAs
                    .OrderBy(tn => loads[tn] + task.ProcessingTimes[tn])
                    .First();

                assignment[task.Name] = chosenTA;
                loads[chosenTA] += task.ProcessingTimes[chosenTA];
            }

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                AlgorithmName = "Greedy (No Sorting)"
            };
        }
    }

    /// <summary>
    /// Greedy algorithm: Sort tasks by descending max processing time,
    /// assign to TA with minimum load, tie-break by TA with fewer eligible tasks (ascending constraint count)
    /// </summary>
    public class GreedySortLoadsDescTAsAscBySkills
    {
        public SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
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

            // Sort tasks by descending max processing time (loads desc)
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

                // Find minimum resulting load (current load + task processing time) among eligible TAs
                int minResultingLoad = eligibleTAs.Min(tn => loads[tn] + task.ProcessingTimes[tn]);
                var tieBest = eligibleTAs.Where(tn => loads[tn] + task.ProcessingTimes[tn] == minResultingLoad).ToList();

                // Tie-break: choose TA with minimum constraint count (fewer eligible tasks = ascending by skills)
                string chosenTA = tieBest
                    .OrderBy(tn => taConstraintCounts[tn])
                    .First();

                assignment[task.Name] = chosenTA;
                loads[chosenTA] += task.ProcessingTimes[chosenTA];
            }

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                AlgorithmName = "Greedy (Sort Loads Desc, TAs Asc by Skills)"
            };
        }
    }
}

