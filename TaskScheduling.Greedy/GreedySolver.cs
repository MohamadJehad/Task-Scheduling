using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.Greedy
{
    /// <summary>
    /// Greedy algorithm with NO sorting - processes tasks in their given order
    /// Assigns each task to the eligible TA that minimizes resulting load
    /// </summary>
    public class GreedyNoSorting
    {
        public SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            // Initialize loads for all TAs
            var loads = InitializeLoads(problem.TAs);
            var assignment = new Dictionary<string, string>();

            // Process tasks in given order (no sorting)
            foreach (var task in problem.Tasks)
            {
                string chosenTA = SelectBestTA(task, loads);
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

        /// <summary>
        /// Selects the TA that minimizes resulting load (current load + task processing time)
        /// </summary>
        protected virtual string SelectBestTA(TaskInfo task, Dictionary<string, int> loads)
        {
            var eligibleTAs = task.EligibleTAs.Select(x => x.Name).ToList();
            if (eligibleTAs.Count == 0)
            {
                throw new InvalidOperationException($"Task {task.Name} has no eligible TAs");
            }

            return eligibleTAs
                .OrderBy(tn => loads[tn] + task.ProcessingTimes[tn])
                .First();
        }

        /// <summary>
        /// Initializes load dictionary for all TAs
        /// </summary>
        protected Dictionary<string, int> InitializeLoads(List<TAInfo> tas)
        {
            var loads = new Dictionary<string, int>();
            foreach (var ta in tas)
            {
                loads[ta.Name] = 0;
            }
            return loads;
        }
    }

    /// <summary>
    /// Greedy algorithm that sorts tasks by descending max processing time (LPT-like)
    /// Assigns each task to the eligible TA that minimizes resulting load
    /// </summary>
    public class GreedySortLoadsDesc : GreedyNoSorting
    {
        public new SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            // Initialize loads for all TAs
            var loads = InitializeLoads(problem.TAs);
            var assignment = new Dictionary<string, string>();

            // Sort tasks by descending max processing time (LPT-like)
            var sortedTasks = problem.Tasks
                .OrderByDescending(t => t.MaxProcessingTime)
                .ToList();

            // Process sorted tasks
            foreach (var task in sortedTasks)
            {
                string chosenTA = SelectBestTA(task, loads);
                assignment[task.Name] = chosenTA;
                loads[chosenTA] += task.ProcessingTimes[chosenTA];
            }

            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                AlgorithmName = "Greedy (Sort Loads Desc)"
            };
        }
    }

    /// <summary>
    /// Greedy algorithm that sorts tasks by descending max processing time,
    /// and when selecting TAs, prefers those with fewer eligible tasks (ascending by number of tasks they can solve)
    /// TAs are sorted by skills (constraint counts) before applying the algorithm
    /// </summary>
    public class GreedySortLoadsDescTAsAscBySkills : GreedySortLoadsDesc
    {
        private Dictionary<string, int>? taConstraintCounts = null;

#pragma warning disable CS0108 // Member hides inherited member; new keyword required
        public new SchedulingResult Solve(ProblemInstance problem)
#pragma warning restore CS0108
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            // Compute TA constraint counts: number of tasks for which each TA is eligible
            taConstraintCounts = ComputeTAConstraintCounts(problem);

            // Sort TAs by skills (ascending by constraint count) before applying the algorithm
            var sortedTAs = problem.TAs
                .OrderBy(ta => taConstraintCounts[ta.Name])
                .ToList();

            // Initialize loads for all TAs (using sorted order)
            var loads = InitializeLoads(sortedTAs);

            // Sort tasks by descending max processing time
            var sortedTasks = problem.Tasks
                .OrderByDescending(t => t.MaxProcessingTime)
                .ToList();

            var assignment = new Dictionary<string, string>();

            // Process sorted tasks
            foreach (var task in sortedTasks)
            {
                string chosenTA = SelectBestTA(task, loads);
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

        /// <summary>
        /// Selects the TA using constraint count as primary criterion, then load minimization
        /// Note: We don't re-sort all TAs here - we only select from eligible TAs based on criteria
        /// </summary>
        protected override string SelectBestTA(TaskInfo task, Dictionary<string, int> loads)
        {
            var eligibleTAs = task.EligibleTAs.Select(x => x.Name).ToList();
            if (eligibleTAs.Count == 0)
            {
                throw new InvalidOperationException($"Task {task.Name} has no eligible TAs");
            }

            // Select based on load (primary) and constraint count (secondary)
            // TAs were already sorted at the beginning - here we just use the criteria for selection
            return eligibleTAs
                .OrderBy(tn => loads[tn] + task.ProcessingTimes[tn])  // Primary: descending by resulting load
                .ThenBy(tn => taConstraintCounts![tn])  // Secondary: ascending by constraint count
                .First();
        }

        /// <summary>
        /// Computes the number of tasks for which each TA is eligible
        /// </summary>
        private Dictionary<string, int> ComputeTAConstraintCounts(ProblemInstance problem)
        {
            var taConstraintCounts = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                int count = problem.Tasks.Count(t => t.EligibleTAs.Any(e => e.Name == ta.Name));
                taConstraintCounts[ta.Name] = count;
            }
            return taConstraintCounts;
        }
    }
}
