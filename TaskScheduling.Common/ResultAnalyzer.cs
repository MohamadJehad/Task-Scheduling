using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskScheduling.Common
{
    /// <summary>
    /// Utility class for analyzing and comparing scheduling results
    /// </summary>
    public class ResultAnalyzer
    {
        /// <summary>
        /// Compares multiple results and generates a detailed report
        /// </summary>
        public static string CompareResults(
            ProblemInstance problem,
            List<SchedulingResult> results,
            SchedulingResult? optimalResult = null)
        {
            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════════════");
            sb.AppendLine($"  PROBLEM INSTANCE: {problem.Name}");
            sb.AppendLine("═══════════════════════════════════════════════════════════════");
            sb.AppendLine($"Tasks: {problem.TaskCount}, TAs: {problem.TACount}");
            sb.AppendLine($"Description: {problem.Description}");
            sb.AppendLine();

            // Summary table
            sb.AppendLine("ALGORITHM COMPARISON");
            sb.AppendLine("─────────────────────────────────────────────────────────────");
            sb.AppendFormat("{0,-40} {1,10} {2,12}\n", 
                "Algorithm", "Makespan", "Approx Ratio");
            sb.AppendLine("─────────────────────────────────────────────────────────────");

            foreach (var result in results)
            {
                double approxRatio = 1.0;
                string ratioStr = "N/A";

                if (optimalResult != null && optimalResult.Makespan > 0)
                {
                    approxRatio = (double)result.Makespan / optimalResult.Makespan;
                    ratioStr = approxRatio.ToString("F3");
                }

                sb.AppendFormat("{0,-40} {1,10} {2,12}\n",
                    result.AlgorithmName,
                    result.Makespan,
                    ratioStr);
            }
            sb.AppendLine("─────────────────────────────────────────────────────────────");
            sb.AppendLine();

            // Detailed results for each algorithm
            foreach (var result in results)
            {
                sb.AppendLine($"DETAILED RESULT: {result.AlgorithmName}");
                sb.AppendLine("─────────────────────────────────────────────────────────────");
                sb.AppendLine($"Makespan: {result.Makespan}");
                
                
                sb.AppendLine();

                sb.AppendLine("TA Loads:");
                foreach (var kvp in result.Loads.OrderByDescending(x => x.Value))
                {
                    int load = kvp.Value;
                    string bar = new string('█', Math.Min(50, load / 2));
                    sb.AppendLine($"  {kvp.Key,-10} {load,5} {bar}");
                }
                sb.AppendLine();

                // Show task assignments grouped by TA
                sb.AppendLine("Task Assignments by TA:");
                var tasksByTA = result.Assignment
                    .GroupBy(kvp => kvp.Value)
                    .OrderBy(g => g.Key);

                foreach (var group in tasksByTA)
                {
                    var taskNames = string.Join(", ", group.Select(kvp => kvp.Key));
                    sb.AppendLine($"  {group.Key}: {taskNames}");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates a compact summary table for multiple problem instances
        /// </summary>
        public static string GenerateSummaryTable(List<ExperimentResult> experiments)
        {
            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine("                         EXPERIMENT SUMMARY TABLE");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendFormat("{0,-15} {1,6} {2,6} {3,10} {4,12} {5,12}\n",
                "Instance", "Tasks", "TAs", "Optimal", "Greedy", "Greedy/Opt");
            sb.AppendLine("───────────────────────────────────────────────────────────────────────────────");

            foreach (var exp in experiments)
            {
                string optimalStr = exp.OptimalMakespan.HasValue ? exp.OptimalMakespan.Value.ToString() : "N/A";
                string ratioStr = exp.ApproximationRatio.HasValue ? exp.ApproximationRatio.Value.ToString("F3") : "N/A";

                sb.AppendFormat("{0,-15} {1,6} {2,6} {3,10} {4,12} {5,12}\n",
                    exp.InstanceName,
                    exp.NumTasks,
                    exp.NumTAs,
                    optimalStr,
                    exp.GreedyMakespan,
                    ratioStr);
            }
            sb.AppendLine("───────────────────────────────────────────────────────────────────────────────");

            // Compute statistics
            var ratios = experiments
                .Where(e => e.ApproximationRatio.HasValue)
                .Select(e => e.ApproximationRatio!.Value)
                .ToList();

            if (ratios.Any())
            {
                sb.AppendLine();
                sb.AppendLine("APPROXIMATION RATIO STATISTICS:");
                sb.AppendLine($"  Average: {ratios.Average():F3}");
                sb.AppendLine($"  Min: {ratios.Min():F3}");
                sb.AppendLine($"  Max: {ratios.Max():F3}");
                sb.AppendLine($"  Median: {GetMedian(ratios):F3}");
            }

            return sb.ToString();
        }

        private static double GetMedian(List<double> values)
        {
            var sorted = values.OrderBy(x => x).ToList();
            int n = sorted.Count;
            if (n == 0) return 0;
            if (n % 2 == 1)
                return sorted[n / 2];
            return (sorted[n / 2 - 1] + sorted[n / 2]) / 2.0;
        }

        /// <summary>
        /// Formats a problem instance for display
        /// </summary>
        public static string FormatProblemInstance(ProblemInstance problem)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Problem: {problem.Name}");
            sb.AppendLine($"Tasks: {problem.TaskCount}, TAs: {problem.TACount}");
            sb.AppendLine($"Description: {problem.Description}");
            sb.AppendLine();
            sb.AppendLine("Task Details:");

            foreach (var task in problem.Tasks)
            {
                sb.AppendLine($"  {task.Name}:");
                sb.AppendLine($"    Eligible TAs: {string.Join(", ", task.EligibleTAs)}");
                sb.Append("    Processing times: ");
                var times = task.ProcessingTimes.Select(kvp => $"{kvp.Key}={kvp.Value}");
                sb.AppendLine(string.Join(", ", times));
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents results from a single experiment
    /// </summary>
    public class ExperimentResult
    {
        public string InstanceName { get; set; } = string.Empty;
        public int NumTasks { get; set; }
        public int NumTAs { get; set; }
        public int? OptimalMakespan { get; set; }
        public int GreedyMakespan { get; set; }
        public double? ApproximationRatio { get; set; }
    }
}

