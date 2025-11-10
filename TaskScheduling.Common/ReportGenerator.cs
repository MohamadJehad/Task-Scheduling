using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TaskScheduling.Common
{
    /// <summary>
    /// Generates comprehensive reports for scheduling results
    /// </summary>
    public static class ReportGenerator
    {
        /// <summary>
        /// Generates a complete report file with all results
        /// </summary>
        public static string GenerateReport(ProblemInstance problem, List<SchedulingResult> results, string? outputPath = null)
        {
            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = $"SchedulingReport_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            }

            var sb = new StringBuilder();

            // Header
            sb.AppendLine("═══════════════════════════════════════════════════════════════");
            sb.AppendLine("   CSCE 5221: Task Scheduling with Eligibility Constraints");
            sb.AppendLine("   Mohamad Jehad - Fall 2025");
            sb.AppendLine($"   Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine("═══════════════════════════════════════════════════════════════");
            sb.AppendLine();

            // Problem Instance
            sb.AppendLine("PROBLEM INSTANCE");
            sb.AppendLine("─────────────────────────────────────────────────────────────");
            sb.AppendLine($"Name: {problem.Name}");
            sb.AppendLine($"Description: {problem.Description}");
            sb.AppendLine($"Number of Tasks: {problem.TaskCount}");
            sb.AppendLine($"Number of TAs: {problem.TACount}");
            sb.AppendLine();

            // Task Details Table
            sb.AppendLine("TASK DETAILS");
            sb.AppendLine("─────────────────────────────────────────────────────────────");
            var taskTable = CreateTextTable(
                new[] { "Task", "Eligible TAs", "Processing Times" },
                problem.Tasks.Select(t => new[]
                {
                    t.Name,
                    string.Join(", ", t.EligibleTAs.Select(ta => ta.Name)),
                    string.Join(", ", t.ProcessingTimes.Select(kvp => $"{kvp.Key}:{kvp.Value}"))
                }).ToList()
            );
            sb.AppendLine(taskTable);
            sb.AppendLine();

            // Algorithm Results
            for (int i = 0; i < results.Count; i++)
            {
                var result = results[i];
                sb.AppendLine($"═══════════════════════════════════════════════════════════════");
                sb.AppendLine($"STEP {i + 1}: {result.AlgorithmName}");
                sb.AppendLine($"═══════════════════════════════════════════════════════════════");
                sb.AppendLine();

                // Algorithm Info
                sb.AppendLine("Algorithm Information:");
                sb.AppendLine($"  Algorithm: {result.AlgorithmName}");
                sb.AppendLine($"  Makespan: {result.Makespan}");
                sb.AppendLine();

                // Assignments Table
                sb.AppendLine("TASK ASSIGNMENTS:");
                var assignmentTable = CreateTextTable(
                    new[] { "Task", "Assigned TA", "Processing Time" },
                    result.Assignment.OrderBy(x => x.Key).Select(kvp =>
                    {
                        var task = problem.Tasks.First(t => t.Name == kvp.Key);
                        var time = task.ProcessingTimes.ContainsKey(kvp.Value) 
                            ? task.ProcessingTimes[kvp.Value].ToString() 
                            : "N/A";
                        return new[] { kvp.Key, kvp.Value, time };
                    }).ToList()
                );
                sb.AppendLine(assignmentTable);
                sb.AppendLine();

                // TA Loads Table
                sb.AppendLine("TA LOADS:");
                var loadTable = CreateTextTable(
                    new[] { "TA", "Total Load", "Tasks Assigned" },
                    result.Loads.OrderBy(x => x.Key).Select(kvp =>
                    {
                        int taskCount = result.Assignment.Count(a => a.Value == kvp.Key);
                        return new[] { kvp.Key, kvp.Value.ToString(), taskCount.ToString() };
                    }).ToList()
                );
                sb.AppendLine(loadTable);
                sb.AppendLine();
            }

            // Summary Comparison Table
            sb.AppendLine("═══════════════════════════════════════════════════════════════");
            sb.AppendLine("SUMMARY COMPARISON");
            sb.AppendLine("═══════════════════════════════════════════════════════════════");
            sb.AppendLine();

            var summaryTable = CreateTextTable(
                new[] { "Algorithm", "Makespan", "Status" },
                results.OrderBy(r => r.Makespan).Select((r, idx) =>
                {
                    string status = idx == 0 ? "★ BEST" : "";
                    return new[] { r.AlgorithmName, r.Makespan.ToString(), status };
                }).ToList()
            );
            sb.AppendLine(summaryTable);
            sb.AppendLine();

            var best = results.OrderBy(r => r.Makespan).First();
            sb.AppendLine($"✓ Best Algorithm: {best.AlgorithmName} with Makespan = {best.Makespan}");
            sb.AppendLine();

            // Statistics
            sb.AppendLine("STATISTICS");
            sb.AppendLine("─────────────────────────────────────────────────────────────");
            sb.AppendLine($"Average Makespan: {results.Average(r => r.Makespan):F2}");
            sb.AppendLine($"Best Makespan: {results.Min(r => r.Makespan)}");
            sb.AppendLine($"Worst Makespan: {results.Max(r => r.Makespan)}");
            sb.AppendLine();

            // Write to file
            File.WriteAllText(outputPath, sb.ToString());
            return outputPath;
        }

        /// <summary>
        /// Creates a simple text table without box-drawing characters
        /// </summary>
        public static string CreateTextTable(string[] headers, List<string[]> rows)
        {
            if (headers == null || headers.Length == 0)
                return string.Empty;

            // Calculate column widths
            int[] columnWidths = new int[headers.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                columnWidths[i] = headers[i].Length;
                foreach (var row in rows)
                {
                    if (i < row.Length && row[i] != null)
                    {
                        columnWidths[i] = Math.Max(columnWidths[i], row[i].Length);
                    }
                }
                columnWidths[i] += 2; // Add padding
            }

            var sb = new StringBuilder();

            // Header row
            sb.Append("│");
            for (int i = 0; i < headers.Length; i++)
            {
                string header = headers[i].PadRight(columnWidths[i]);
                sb.Append($" {header}│");
            }
            sb.AppendLine();

            // Header separator
            sb.AppendLine("├" + string.Join("┼", columnWidths.Select(w => new string('─', w))) + "┤");

            // Data rows
            foreach (var row in rows)
            {
                sb.Append("│");
                for (int i = 0; i < headers.Length; i++)
                {
                    string cell = (i < row.Length && row[i] != null) ? row[i] : "";
                    cell = cell.PadRight(columnWidths[i]);
                    sb.Append($" {cell}│");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates a summary table for console display
        /// </summary>
        public static void PrintSummaryTable(List<SchedulingResult> results)
        {
            var summaryRows = new List<string[]>();
            
            foreach (var result in results.OrderBy(r => r.Makespan))
            {
                summaryRows.Add(new[] 
                { 
                    result.AlgorithmName, 
                    result.Makespan.ToString()
                });
            }

            var table = CreateTextTable(new[] { "Algorithm", "Makespan" }, summaryRows);
            Console.WriteLine(table);

            var best = results.OrderBy(r => r.Makespan).First();
            Console.WriteLine($"\n✓ Best Algorithm: {best.AlgorithmName} with Makespan = {best.Makespan}");
        }
    }
}

