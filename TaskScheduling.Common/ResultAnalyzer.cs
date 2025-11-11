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
                "Algorithm", "MaxLoad", "Approx Ratio");
            sb.AppendLine("─────────────────────────────────────────────────────────────");

            foreach (var result in results)
            {
                double approxRatio = 1.0;
                string ratioStr = "N/A";

                if (optimalResult != null && optimalResult.MaxLoad > 0)
                {
                    approxRatio = (double)result.MaxLoad / optimalResult.MaxLoad;
                    ratioStr = approxRatio.ToString("F3");
                }

                sb.AppendFormat("{0,-40} {1,10} {2,12}\n",
                    result.AlgorithmName,
                    result.MaxLoad,
                    ratioStr);
            }
            sb.AppendLine("─────────────────────────────────────────────────────────────");
            sb.AppendLine();

            // Detailed results for each algorithm
            foreach (var result in results)
            {
                sb.AppendLine($"DETAILED RESULT: {result.AlgorithmName}");
                sb.AppendLine("─────────────────────────────────────────────────────────────");
                sb.AppendLine($"MaxLoad: {result.MaxLoad}");
                
                
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
    }
}

