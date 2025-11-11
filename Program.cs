using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using TaskScheduling.Common;
using TaskScheduling.BruteForce;
using TaskScheduling.Greedy;
using TaskScheduling.DataGeneration;

namespace TaskScheduling
{
    /// <summary>
    /// Main program for Task Scheduling Project
    /// CSCE 5221: Algorithms & Complexity Analysis
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("   CSCE 5221: Task Scheduling with Eligibility Constraints");
            Console.WriteLine("   Mohamad Jehad - Fall 2025");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            // Clear and create reports directory
            string reportsDir = Path.Combine(Directory.GetCurrentDirectory(), "reports");
            if (Directory.Exists(reportsDir))
            {
                // Delete all existing report files
                var existingFiles = Directory.GetFiles(reportsDir, "*.txt");
                foreach (var file in existingFiles)
                {
                    File.Delete(file);
                }
                Console.WriteLine($"🗑️  Deleted {existingFiles.Length} existing report file(s)");
            }
            else
            {
                Directory.CreateDirectory(reportsDir);
            }
            Console.WriteLine($"📁 Reports directory ready: {reportsDir}\n");

            // Run comprehensive evaluation with all instances and algorithms
            RunAllExperimentsWithDetailedReports(reportsDir);

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Runs all instances with all algorithms and generates detailed reports
        /// </summary>
        static void RunAllExperimentsWithDetailedReports(string reportsDir)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("   COMPREHENSIVE EVALUATION: ALL INSTANCES & ALGORITHMS");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            var allResults = new List<(string instanceName, List<SchedulingResult> results, SchedulingResult? optimal)>();
            string runTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Process each instance from TestInstances
            foreach (var problem in TestInstances.GetAllInstances())
            {
                Console.WriteLine($"\n{new string('=', 70)}");
                Console.WriteLine($"Processing Instance: {problem.Name}");
                Console.WriteLine($"{new string('=', 70)}");
                Console.WriteLine($"Tasks: {problem.TaskCount}, TAs: {problem.TACount}");
                Console.WriteLine($"Description: {problem.Description}");

                var results = new List<SchedulingResult>();
                SchedulingResult? optimalResult = null;

                // Check if brute force is feasible
                long estimatedAssignments = BruteForceSolver.EstimateAssignmentCount(problem);
                Console.WriteLine($"Estimated assignments for brute force: {estimatedAssignments:N0}");

                // Run Brute Force (if feasible)
                if (estimatedAssignments <= 1_000_000 && estimatedAssignments > 0)
                {
                    try
                    {
                        Console.WriteLine("Running Brute Force (Exact)...");
                        var bfSolver = new BruteForceSolver();
                        optimalResult = bfSolver.Solve(problem);
                        results.Add(optimalResult);
                        Console.WriteLine($"  ✓ Brute Force: MaxLoad = {optimalResult.MaxLoad}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"  ✗ Brute Force failed: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("  ⊘ Brute Force skipped (too many assignments)");
                }

                // Run only the 4 specified algorithms
                Console.WriteLine("\nRunning Selected Algorithms...");

                // 2. Greedy No Sorting
                try
                {
                    Console.WriteLine("Running Greedy (No Sorting)...");
                    var noSortSolver = new GreedyNoSorting();
                    var noSortResult = noSortSolver.Solve(problem);
                    results.Add(noSortResult);
                    double? ratio = optimalResult != null && optimalResult.MaxLoad > 0 
                        ? (double)noSortResult.MaxLoad / optimalResult.MaxLoad 
                        : null;
                    string ratioStr = ratio.HasValue ? $" (Ratio: {ratio.Value:F3})" : "";
                    Console.WriteLine($"  ✓ Greedy (No Sorting): MaxLoad = {noSortResult.MaxLoad}{ratioStr}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  ✗ Greedy (No Sorting) failed: {ex.Message}");
                }

                // 3. Greedy Sort Loads Desc (MaxProcessingTime)
                try
                {
                    Console.WriteLine("Running Greedy (Sort Loads Desc)...");
                    var sortLoadsSolver = new GreedySortLoadsDesc();
                    var sortLoadsResult = sortLoadsSolver.Solve(problem);
                    results.Add(sortLoadsResult);
                    double? ratio = optimalResult != null && optimalResult.MaxLoad > 0 
                        ? (double)sortLoadsResult.MaxLoad / optimalResult.MaxLoad 
                        : null;
                    string ratioStr = ratio.HasValue ? $" (Ratio: {ratio.Value:F3})" : "";
                    Console.WriteLine($"  ✓ Greedy (Sort Loads Desc): MaxLoad = {sortLoadsResult.MaxLoad}{ratioStr}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  ✗ Greedy (Sort Loads Desc) failed: {ex.Message}");
                }

                // 4. Greedy Sort Loads Desc, TAs Asc by Skills
                try
                {
                    Console.WriteLine("Running Greedy (Sort Loads Desc, TAs Asc by Skills)...");
                    var sortLoadsTAsSolver = new GreedySortLoadsDescTAsAscBySkills();
                    var sortLoadsTAsResult = sortLoadsTAsSolver.Solve(problem);
                    results.Add(sortLoadsTAsResult);
                    double? ratio = optimalResult != null && optimalResult.MaxLoad > 0 
                        ? (double)sortLoadsTAsResult.MaxLoad / optimalResult.MaxLoad 
                        : null;
                    string ratioStr = ratio.HasValue ? $" (Ratio: {ratio.Value:F3})" : "";
                    Console.WriteLine($"  ✓ Greedy (Sort Loads Desc, TAs Asc by Skills): MaxLoad = {sortLoadsTAsResult.MaxLoad}{ratioStr}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  ✗ Greedy (Sort Loads Desc, TAs Asc by Skills) failed: {ex.Message}");
                }

                allResults.Add((problem.Name, results, optimalResult));

                // Generate and save detailed report for this instance
                string reportContent = ResultAnalyzer.CompareResults(problem, results, optimalResult);
                string reportFile = Path.Combine(reportsDir, $"Report_{problem.Name}_{runTimestamp}.txt");
                File.WriteAllText(reportFile, reportContent);
                Console.WriteLine($"\n  📄 Detailed report saved to: {reportFile}");
            }

            // Generate master summary report
            GenerateMasterSummaryReport(reportsDir, allResults);
            Console.WriteLine($"\n\n{new string('=', 70)}");
            Console.WriteLine("All experiments completed!");
            Console.WriteLine($"Reports saved in: {reportsDir}");
            Console.WriteLine($"{new string('=', 70)}");
        }

        /// <summary>
        /// Generates a master summary report comparing all algorithms across all instances
        /// </summary>
        static void GenerateMasterSummaryReport(string reportsDir, List<(string instanceName, List<SchedulingResult> results, SchedulingResult? optimal)> allResults)
        {
            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine("                    MASTER SUMMARY REPORT");
            sb.AppendLine("         All Algorithms vs All Problem Instances");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine();
            sb.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine();

            // Create algorithm name mapping for shorter display names (matching actual algorithm names)
            var algorithmAbbrev = new Dictionary<string, string>
            {
                { "Brute Force (Exact)", "Brute Force" },
                { "Greedy (No Sorting)", "No Sorting" },
                { "Greedy (Sort Loads Desc)", "Sort Loads Desc" },
                { "Greedy (Sort Loads Desc, TAs Asc by Skills)", "Sort Loads Desc + TAs Asc" }
            };

            // Get all unique algorithm names and order them correctly
            var allAlgorithms = allResults
                .SelectMany(r => r.results)
                .Select(r => r.AlgorithmName)
                .Distinct()
                .ToList();

            // Order algorithms in the desired order (fixing the actual algorithm names)
            var algorithmOrder = new Dictionary<string, int>
            {
                { "Brute Force (Exact)", 1 },
                { "Greedy (No Sorting)", 2 },
                { "Greedy (Sort Loads Desc)", 3 },
                { "Greedy (Sort Loads Desc, TAs Asc by Skills)", 4 }
            };

            var orderedAlgorithms = allAlgorithms
                .OrderBy(a => algorithmOrder.ContainsKey(a) ? algorithmOrder[a] : 999)
                .ToList();

            // ============================================================================
            // SECTION 1: MAX LOAD COMPARISON
            // ============================================================================
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine("SECTION 1: MAX LOAD COMPARISON");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine();

            // Table formatting constants
            const int instanceColWidth = 25;
            const int algoColWidth = 20;
            const int maxLoadColWidth = 12;

            // Build header row
            sb.AppendFormat("{0,-" + instanceColWidth + "}", "Instance");
            foreach (var algo in orderedAlgorithms)
            {
                string shortName = algorithmAbbrev.ContainsKey(algo) ? algorithmAbbrev[algo] : algo;
                // Truncate if too long
                if (shortName.Length > algoColWidth - 1)
                    shortName = shortName.Substring(0, algoColWidth - 1);
                sb.AppendFormat("{0," + maxLoadColWidth + "}", shortName);
            }
            sb.AppendLine();

            // Separator line
            int totalWidth = instanceColWidth + orderedAlgorithms.Count * maxLoadColWidth;
            sb.AppendLine(new string('─', totalWidth));

            // Data rows
            foreach (var (instanceName, results, optimal) in allResults)
            {
                // Truncate instance name if needed
                string displayName = instanceName.Length > instanceColWidth - 1 
                    ? instanceName.Substring(0, instanceColWidth - 1) 
                    : instanceName;
                sb.AppendFormat("{0,-" + instanceColWidth + "}", displayName);

                foreach (var algo in orderedAlgorithms)
                {
                    var result = results.FirstOrDefault(r => r.AlgorithmName == algo);
                    if (result != null)
                    {
                        sb.AppendFormat("{0," + maxLoadColWidth + "}", result.MaxLoad);
                    }
                    else
                    {
                        sb.AppendFormat("{0," + maxLoadColWidth + "}", "-");
                    }
                }
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.AppendLine();

            // ============================================================================
            // SECTION 2: APPROXIMATION RATIOS (where optimal available)
            // ============================================================================
            var instancesWithOptimal = allResults.Where(r => r.optimal != null).ToList();
            if (instancesWithOptimal.Any())
            {
                sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
                sb.AppendLine("SECTION 2: APPROXIMATION RATIOS (vs Optimal Solution)");
                sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
                sb.AppendLine();

                var heuristicAlgorithms = orderedAlgorithms.Where(a => a != "Brute Force (Exact)").ToList();

                // Build header row
                sb.AppendFormat("{0,-" + instanceColWidth + "}", "Instance");
                foreach (var algo in heuristicAlgorithms)
                {
                    string shortName = algorithmAbbrev.ContainsKey(algo) ? algorithmAbbrev[algo] : algo;
                    if (shortName.Length > algoColWidth - 1)
                        shortName = shortName.Substring(0, algoColWidth - 1);
                    sb.AppendFormat("{0," + maxLoadColWidth + "}", shortName);
                }
                sb.AppendLine();

                // Separator line
                int heuristicWidth = instanceColWidth + heuristicAlgorithms.Count * maxLoadColWidth;
                sb.AppendLine(new string('─', heuristicWidth));

                // Data rows
                foreach (var (instanceName, results, optimal) in instancesWithOptimal)
                {
                    string displayName = instanceName.Length > instanceColWidth - 1 
                        ? instanceName.Substring(0, instanceColWidth - 1) 
                        : instanceName;
                    sb.AppendFormat("{0,-" + instanceColWidth + "}", displayName);

                    foreach (var algo in heuristicAlgorithms)
                    {
                        var result = results.FirstOrDefault(r => r.AlgorithmName == algo);
                        if (result != null && optimal != null && optimal.MaxLoad > 0)
                        {
                            double ratio = (double)result.MaxLoad / optimal.MaxLoad;
                            sb.AppendFormat("{0," + maxLoadColWidth + ":F3}", ratio);
                        }
                        else
                        {
                            sb.AppendFormat("{0," + maxLoadColWidth + "}", "-");
                        }
                    }
                    sb.AppendLine();
                }

                sb.AppendLine();
                sb.AppendLine("Note: Ratio = Heuristic MaxLoad / Optimal MaxLoad (lower is better, 1.000 = optimal)");
                sb.AppendLine();
            }

            string summaryFile = Path.Combine(reportsDir, $"MasterSummary_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
            File.WriteAllText(summaryFile, sb.ToString());
            Console.WriteLine($"\n📊 Master summary report saved to: {Path.GetFileName(summaryFile)}");
            
            // Display the master summary report in console for easy viewing in Replit
            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("MASTER SUMMARY REPORT (Displayed Below)");
            Console.WriteLine(new string('=', 70) + "\n");
            Console.WriteLine(sb.ToString());
            
            // List all report files for easy access
            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine("ALL REPORT FILES:");
            Console.WriteLine(new string('=', 70));
            if (Directory.Exists(reportsDir))
            {
                var reportFiles = Directory.GetFiles(reportsDir, "*.txt")
                    .OrderBy(f => File.GetCreationTime(f))
                    .ToList();
                
                if (reportFiles.Any())
                {
                    foreach (var file in reportFiles)
                    {
                        var fileInfo = new FileInfo(file);
                        Console.WriteLine($"  📄 {Path.GetFileName(file)} ({fileInfo.Length:N0} bytes)");
                    }
                    Console.WriteLine($"\n  📁 Reports directory: {reportsDir}");
                    Console.WriteLine($"  💡 In Replit: Click the 'Files' icon in the left sidebar to view/download these files");
                }
                else
                {
                    Console.WriteLine("  No report files found.");
                }
            }
            Console.WriteLine(new string('=', 70));
        }
    }
}

