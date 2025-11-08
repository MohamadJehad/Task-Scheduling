using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskScheduling.Common
{
    /// <summary>
    /// Represents a task with eligibility constraints and TA-dependent processing times
    /// </summary>
    public class TaskInfo
    {
        public string Name { get; set; } = string.Empty;
        public List<TAInfo> EligibleTAs { get; set; } = new();
        public Dictionary<string, int> ProcessingTimes { get; set; } = new(); // p_{i,t}

        /// <summary>
        /// Returns the maximum processing time across all eligible TAs
        /// </summary>
        public int MaxProcessingTime => ProcessingTimes.Count > 0 ? ProcessingTimes.Values.Max() : 0;

        /// <summary>
        /// Returns the minimum processing time across all eligible TAs
        /// </summary>
        public int MinProcessingTime => ProcessingTimes.Count > 0 ? ProcessingTimes.Values.Min() : 0;

        /// <summary>
        /// Returns the range of processing times (max - min)
        /// </summary>
        public int ProcessingTimeRange => MaxProcessingTime - MinProcessingTime;
    }

    /// <summary>
    /// Represents the result of a scheduling algorithm
    /// </summary>
    public class SchedulingResult
    {
        public Dictionary<string, string> Assignment { get; set; } = new(); // Task -> TA
        public Dictionary<string, int> Loads { get; set; } = new(); // TA -> Total Load
        public int Makespan { get; set; }
        public long ExecutionTimeMs { get; set; }
        public string AlgorithmName { get; set; } = string.Empty;

        public override string ToString()
        {
            var result = $"Algorithm: {AlgorithmName}\n";
            result += $"Makespan: {Makespan}\n";
            result += $"Execution Time: {ExecutionTimeMs} ms\n";
            result += "Task Assignments:\n";
            foreach (var kvp in Assignment.OrderBy(x => x.Key))
            {
                result += $"  {kvp.Key} → {kvp.Value}\n";
            }
            result += "TA Loads:\n";
            foreach (var kvp in Loads.OrderBy(x => x.Key))
            {
                result += $"  {kvp.Key}: {kvp.Value}\n";
            }
            return result;
        }
    }

    /// <summary>
    /// Represents a TA (Teaching Assistant) with properties and constraints
    /// </summary>
    public class TAInfo
    {
        public string Name { get; set; } = string.Empty;
        public int MaxCapacity { get; set; } = int.MaxValue; // Maximum workload capacity (optional constraint)
        public List<string> Skills { get; set; } = new(); // Optional: skills or specializations
        public bool IsAvailable { get; set; } = true; // Availability status
    }

    /// <summary>
    /// Represents a complete problem instance
    /// </summary>
    public class ProblemInstance
    {
        public string Name { get; set; } = string.Empty;
        public List<TaskInfo> Tasks { get; set; } = new();
        public List<TAInfo> TAs { get; set; } = new();
        public string Description { get; set; } = string.Empty;

        public int TaskCount => Tasks.Count;
        public int TACount => TAs.Count;

        /// <summary>
        /// Validates that the problem instance is well-formed
        /// </summary>
        public bool IsValid()
        {
            if (Tasks == null || TAs == null || Tasks.Count == 0 || TAs.Count == 0)
                return false;

            foreach (var task in Tasks)
            {
                if (task.EligibleTAs.Count == 0)
                    return false;

                // Check that all eligible TAs exist in the TA list
                if (!task.EligibleTAs.All(ta => TAs.Contains(ta)))
                    return false;

                // Check that processing times are defined for all eligible TAs
                if (!task.EligibleTAs.All(ta => task.ProcessingTimes.ContainsKey(ta.Name)))
                    return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Utility class for computing scheduling metrics
    /// </summary>
    public static class SchedulingMetrics
    {
        /// <summary>
        /// Computes the loads for each TA given an assignment
        /// </summary>
        public static Dictionary<string, int> ComputeLoads(
            Dictionary<string, string> assignment,
            List<TaskInfo> tasks,
            List<TAInfo> allTAs)
        {
            var loads = new Dictionary<string, int>();
            foreach (var ta in allTAs)
                loads[ta.Name] = 0;

            foreach (var kvp in assignment)
            {
                var taskName = kvp.Key;
                var assignedTA = kvp.Value;
                var task = tasks.First(t => t.Name == taskName);

                if (task.ProcessingTimes.ContainsKey(assignedTA))
                {
                    loads[assignedTA] += task.ProcessingTimes[assignedTA];
                }
            }

            return loads;
        }

        /// <summary>
        /// Computes the makespan (maximum load) from loads dictionary
        /// </summary>
        public static int ComputeMakespan(Dictionary<string, int> loads)
        {
            return loads.Count > 0 ? loads.Values.Max() : 0;
        }

        /// <summary>
        /// Computes the average load across all TAs
        /// </summary>
        public static double ComputeAverageLoad(Dictionary<string, int> loads)
        {
            return loads.Count > 0 ? loads.Values.Average() : 0;
        }

        /// <summary>
        /// Computes the load imbalance (makespan / average load)
        /// </summary>
        public static double ComputeLoadImbalance(Dictionary<string, int> loads)
        {
            double avg = ComputeAverageLoad(loads);
            if (avg == 0) return 0;
            return ComputeMakespan(loads) / avg;
        }

        /// <summary>
        /// Validates that an assignment is feasible
        /// </summary>
        public static bool IsAssignmentFeasible(
            Dictionary<string, string> assignment,
            List<TaskInfo> tasks)
        {
            foreach (var task in tasks)
            {
                if (!assignment.ContainsKey(task.Name))
                    return false;

                var assignedTA = assignment[task.Name];
                if (!task.EligibleTAs.Any(ta => ta.Name == assignedTA))
                    return false;
            }
            return true;
        }
    }
}

