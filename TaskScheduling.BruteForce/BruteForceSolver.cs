using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.BruteForce
{
    /// <summary>
    /// Exact algorithm that enumerates all feasible assignments to find the optimal solution.
    /// Only suitable for small instances due to exponential complexity.
    /// Time Complexity: O(n * ∏|E_i|) where E_i is the eligibility set for task i
    /// </summary>
    public class BruteForceSolver
    {
        private int _bestMakespan;
        private Dictionary<TaskInfo, TAInfo> _bestAssignment; // Task -> TA
        private List<TaskInfo> _tasks;
        private List<TAInfo> _allTAs;

        public BruteForceSolver()
        {
            _bestMakespan = int.MaxValue;
            _bestAssignment = new Dictionary<TaskInfo, TAInfo>();
            _tasks = new List<TaskInfo>();
            _allTAs = new List<TAInfo>();
        }

        /// <summary>
        /// Solves the scheduling problem using brute force enumeration
        /// </summary>
        public SchedulingResult Solve(ProblemInstance problem)
        {
            if (!problem.IsValid())
            {
                throw new ArgumentException("Invalid problem instance");
            }

            // Estimate number of assignments to check
            long estimatedAssignments = 1;
            foreach (var task in problem.Tasks)
            {
                estimatedAssignments *= task.EligibleTAs.Count;
                if (estimatedAssignments > 10_000_000) // Safety check
                {
                    Console.WriteLine($"Warning: Estimated {estimatedAssignments:N0} assignments to check. This may take a very long time.");
                    break;
                }
            }

            _tasks = problem.Tasks;
            _allTAs = problem.TAs;
            _bestMakespan = int.MaxValue;
            _bestAssignment = new Dictionary<TaskInfo, TAInfo>();

            var currentAssignment = new Dictionary<TaskInfo, TAInfo>();
            RecursiveEnumerate(0, currentAssignment);

            // Convert TaskInfo->TAInfo assignment to string->string for compatibility
            var stringAssignment = new Dictionary<string, string>();
            foreach (var kvp in _bestAssignment)
            {
                stringAssignment[kvp.Key.Name] = kvp.Value.Name;
            }

            var loads = SchedulingMetrics.ComputeLoads(stringAssignment, _tasks, _allTAs);

            return new SchedulingResult
            {
                Assignment = stringAssignment,
                Loads = loads,
                Makespan = _bestMakespan,
                AlgorithmName = "Brute Force (Exact)"
            };
        }

        /// <summary>
        /// Recursively enumerates all possible assignments
        /// </summary>
        private void RecursiveEnumerate(int taskIndex, Dictionary<TaskInfo, TAInfo> currentAssignment)
        {
            // Base case: all tasks assigned
            if (taskIndex >= _tasks.Count)
            {
                EvaluateAssignment(currentAssignment);
                return;
            }

            // Recursive case: try each eligible TA for current task
            var currentTask = _tasks[taskIndex];
            foreach (var ta in currentTask.EligibleTAs)
            {
                currentAssignment[currentTask] = ta;
                RecursiveEnumerate(taskIndex + 1, currentAssignment);
                currentAssignment.Remove(currentTask);
            }
        }

        /// <summary>
        /// Evaluates a complete assignment and updates best if better
        /// </summary>
        private void EvaluateAssignment(Dictionary<TaskInfo, TAInfo> assignment)
        {
            // Convert TaskInfo->TAInfo assignment to string->string for evaluation
            var stringAssignment = new Dictionary<string, string>();
            foreach (var kvp in assignment)
            {
                stringAssignment[kvp.Key.Name] = kvp.Value.Name;
            }

            var loads = SchedulingMetrics.ComputeLoads(stringAssignment, _tasks, _allTAs);
            int makespan = SchedulingMetrics.ComputeMakespan(loads);

            if (makespan < _bestMakespan)
            {
                _bestMakespan = makespan;
                _bestAssignment = new Dictionary<TaskInfo, TAInfo>(assignment);
            }
        }

        /// <summary>
        /// Estimates the number of assignments that will be checked
        /// </summary>
        public static long EstimateAssignmentCount(ProblemInstance problem)
        {
            long count = 1;
            foreach (var task in problem.Tasks)
            {
                count *= task.EligibleTAs.Count;
                if (count > long.MaxValue / task.EligibleTAs.Count) // Overflow check
                {
                    return long.MaxValue;
                }
            }
            return count;
        }
    }
}

