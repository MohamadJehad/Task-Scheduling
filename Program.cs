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

            // Create reports directory
            string reportsDir = Path.Combine(Directory.GetCurrentDirectory(), "reports");
            if (!Directory.Exists(reportsDir))
            {
                Directory.CreateDirectory(reportsDir);
            }

            // Run comprehensive evaluation with all instances and algorithms
            RunAllExperimentsWithDetailedReports(reportsDir);

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Runs the example from the LaTeX document
        /// </summary>
        static void RunLaTeXExample()
        {
            Console.WriteLine("EXPERIMENT 1: LaTeX Document Example");
            Console.WriteLine("─────────────────────────────────────────────────────────────");

            var problem = DatasetGenerator.CreateLaTeXExample();
            Console.WriteLine(ResultAnalyzer.FormatProblemInstance(problem));
            Console.WriteLine();

            var results = new List<SchedulingResult>();

            // Brute force
            var bfSolver = new BruteForceSolver();
            var bfResult = bfSolver.Solve(problem);
            results.Add(bfResult);

            // Greedy
            var greedySolver = new GreedySortLoadsDesc();
            results.Add(greedySolver.Solve(problem));

            Console.WriteLine(ResultAnalyzer.CompareResults(problem, results, bfResult));
        }

        /// <summary>
        /// Runs experiments on small instances suitable for brute force
        /// </summary>
        static void RunSmallInstanceExperiments()
        {
            Console.WriteLine("EXPERIMENT 2: Small Instances (Brute Force vs Greedy)");
            Console.WriteLine("─────────────────────────────────────────────────────────────");

            var experiments = new List<ExperimentResult>();

            for (int i = 0; i < 3; i++)
            {
                var problem = DatasetGenerator.CreateSmallInstance($"Small-{i + 1}", seed: 100 + i);

                Console.WriteLine($"\nProcessing {problem.Name}: {problem.TaskCount} tasks, {problem.TACount} TAs");

                // Check if brute force is feasible
                long estimatedAssignments = BruteForceSolver.EstimateAssignmentCount(problem);
                Console.WriteLine($"Estimated assignments to check: {estimatedAssignments:N0}");

                SchedulingResult? optimalResult = null;
                if (estimatedAssignments <= 100000)
                {
                    var bfSolver = new BruteForceSolver();
                    optimalResult = bfSolver.Solve(problem);
                    Console.WriteLine($"Brute Force: MaxLoad = {optimalResult.MaxLoad}");
                }
                else
                {
                    Console.WriteLine("Brute force skipped (too many assignments)");
                }

                var greedySolver = new GreedySortLoadsDesc();
                var greedyResult = greedySolver.Solve(problem);
                Console.WriteLine($"Greedy: MaxLoad = {greedyResult.MaxLoad}");

                double? ratio = null;
                if (optimalResult != null && optimalResult.MaxLoad > 0)
                {
                    ratio = (double)greedyResult.MaxLoad / optimalResult.MaxLoad;
                    Console.WriteLine($"Approximation Ratio: {ratio:F3}");
                }

                experiments.Add(new ExperimentResult
                {
                    InstanceName = problem.Name,
                    NumTasks = problem.TaskCount,
                    NumTAs = problem.TACount,
                    OptimalMaxLoad = optimalResult?.MaxLoad,
                    GreedyMaxLoad = greedyResult.MaxLoad,
                    ApproximationRatio = ratio
                });
            }

            Console.WriteLine();
            Console.WriteLine(ResultAnalyzer.GenerateSummaryTable(experiments));
        }

        /// <summary>
        /// Runs experiments on medium instances
        /// </summary>
        static void RunMediumInstanceExperiments()
        {
            Console.WriteLine("EXPERIMENT 3: Medium Instances");
            Console.WriteLine("─────────────────────────────────────────────────────────────");

            var problem = DatasetGenerator.CreateMediumInstance();

            Console.WriteLine($"Instance: {problem.Name}");
            Console.WriteLine($"Tasks: {problem.TaskCount}, TAs: {problem.TACount}");
            Console.WriteLine();

            var results = new List<SchedulingResult>();

            // Greedy
            var greedySolver = new GreedySortLoadsDesc();
            var greedyResult = greedySolver.Solve(problem);
            results.Add(greedyResult);
            Console.WriteLine($"{"Greedy",-25}: MaxLoad = {greedyResult.MaxLoad,5}");

            Console.WriteLine();
            Console.WriteLine("Best result: " + results.OrderBy(r => r.MaxLoad).First().AlgorithmName);
        }

        /// <summary>
        /// Runs experiments on large instances
        /// </summary>
        static void RunLargeInstanceExperiments()
        {
            Console.WriteLine("EXPERIMENT 4: Large Instance");
            Console.WriteLine("─────────────────────────────────────────────────────────────");

            var problem = DatasetGenerator.CreateLargeInstance();

            Console.WriteLine($"Instance: {problem.Name}");
            Console.WriteLine($"Tasks: {problem.TaskCount}, TAs: {problem.TACount}");
            Console.WriteLine();

            // Test scalability
            var solver = new GreedySortLoadsDesc();
            var result = solver.Solve(problem);

            Console.WriteLine($"Greedy (MaxProcessingTime): MaxLoad = {result.MaxLoad}");
        }

        /// <summary>
        /// Comprehensive evaluation across different instance types
        /// </summary>
        static void RunComprehensiveEvaluation()
        {
            Console.WriteLine("EXPERIMENT 5: Comprehensive Evaluation");
            Console.WriteLine("─────────────────────────────────────────────────────────────");

            var experiments = new List<ExperimentResult>();

            // Test various instance types
            var instanceGenerators = new List<(string name, Func<ProblemInstance> generator)>
            {
                ("Balanced-20", () => DatasetGenerator.CreateBalancedInstance("Balanced", 20, 5)),
                ("Constrained-20", () => DatasetGenerator.CreateConstrainedInstance("Constrained", 20, 5)),
                ("WorstCase-10", () => DatasetGenerator.CreateWorstCaseInstance("WorstCase", 10, 3)),
                ("LaTeX-Example", () => DatasetGenerator.CreateLaTeXExample())
            };

            foreach (var (name, genFunc) in instanceGenerators)
            {
                var problem = genFunc();
                Console.WriteLine($"\nEvaluating {problem.Name}...");

                SchedulingResult? optimalResult = null;
                long estimatedAssignments = BruteForceSolver.EstimateAssignmentCount(problem);

                if (estimatedAssignments <= 50000)
                {
                    try
                    {
                        var bfSolver = new BruteForceSolver();
                        optimalResult = bfSolver.Solve(problem);
                        Console.WriteLine($"  Optimal: {optimalResult.MaxLoad}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"  Optimal: Failed ({ex.Message})");
                    }
                }

                var greedySolver = new GreedySortLoadsDesc();
                var greedyResult = greedySolver.Solve(problem);
                Console.WriteLine($"  Greedy:  {greedyResult.MaxLoad}");

                double? ratio = null;
                if (optimalResult != null && optimalResult.MaxLoad > 0)
                {
                    ratio = (double)greedyResult.MaxLoad / optimalResult.MaxLoad;
                    Console.WriteLine($"  Ratio:   {ratio:F3}");
                }

                experiments.Add(new ExperimentResult
                {
                    InstanceName = problem.Name,
                    NumTasks = problem.TaskCount,
                    NumTAs = problem.TACount,
                    OptimalMaxLoad = optimalResult?.MaxLoad,
                    GreedyMaxLoad = greedyResult.MaxLoad,
                    ApproximationRatio = ratio
                });
            }

            Console.WriteLine();
            Console.WriteLine(ResultAnalyzer.GenerateSummaryTable(experiments));
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

            // Define all problem instances
            var instances = new List<(string name, Func<ProblemInstance> generator)>
            {
                ("LaTeX-Example", () => DatasetGenerator.CreateLaTeXExample()),
                ("Small", () => DatasetGenerator.CreateSmallInstance()),
                ("SmallMedium", () => DatasetGenerator.CreateSmallMediumInstance()),
                ("MediumSmall", () => DatasetGenerator.CreateMediumSmallInstance()),
                ("LargeSmall", () => DatasetGenerator.CreateLargeSmallInstance()),
                ("Medium", () => DatasetGenerator.CreateMediumInstance()),
                ("Large", () => DatasetGenerator.CreateLargeInstance()),
                ("Balanced-20-5", () => DatasetGenerator.CreateBalancedInstance("Balanced-20-5", 20, 5)),
                ("Balanced-50-8", () => DatasetGenerator.CreateBalancedInstance("Balanced-50-8", 50, 8)),
                ("Constrained-20-5", () => DatasetGenerator.CreateConstrainedInstance("Constrained-20-5", 20, 5)),
                ("WorstCase-10-3", () => DatasetGenerator.CreateWorstCaseInstance("WorstCase-10-3", 10, 3)),
                ("WorstCase-15-5", () => DatasetGenerator.CreateWorstCaseInstance("WorstCase-15-5", 15, 5))
            };

            var allResults = new List<(string instanceName, List<SchedulingResult> results, SchedulingResult? optimal)>();
            string runTimestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Process each instance
            foreach (var (instanceName, generator) in instances)
            {
                Console.WriteLine($"\n{new string('=', 70)}");
                Console.WriteLine($"Processing Instance: {instanceName}");
                Console.WriteLine($"{new string('=', 70)}");

                var problem = generator();
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

                allResults.Add((instanceName, results, optimalResult));

                // Generate and save detailed report for this instance
                string reportContent = ResultAnalyzer.CompareResults(problem, results, optimalResult);
                string reportFile = Path.Combine(reportsDir, $"Report_{instanceName}_{runTimestamp}.txt");
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
            // SECTION 1: MAKESPAN COMPARISON
            // ============================================================================
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine("SECTION 1: MAKESPAN COMPARISON");
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

            // ============================================================================
            // SECTION 3: BEST ALGORITHM PER INSTANCE
            // ============================================================================
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine("SECTION 3: BEST ALGORITHM PER INSTANCE");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine();

            foreach (var (instanceName, results, optimal) in allResults)
            {
                if (results.Any())
                {
                    var best = results.OrderBy(r => r.MaxLoad).First();
                    string optimalNote = optimal != null && best.MaxLoad == optimal.MaxLoad ? " [OPTIMAL]" : "";
                    string algoDisplayName = algorithmAbbrev.ContainsKey(best.AlgorithmName) 
                        ? algorithmAbbrev[best.AlgorithmName] 
                        : best.AlgorithmName;
                    sb.AppendLine($"  {instanceName,-25} → {algoDisplayName,-35} (MaxLoad: {best.MaxLoad,5}){optimalNote}");
                }
            }

            sb.AppendLine();
            sb.AppendLine();

            // ============================================================================
            // SECTION 4: STATISTICS SUMMARY
            // ============================================================================
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine("SECTION 4: STATISTICS SUMMARY");
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");
            sb.AppendLine();

            // Count wins per algorithm
            var winCounts = new Dictionary<string, int>();
            foreach (var (instanceName, results, optimal) in allResults)
            {
                if (results.Any())
                {
                    var best = results.OrderBy(r => r.MaxLoad).First();
                    if (!winCounts.ContainsKey(best.AlgorithmName))
                        winCounts[best.AlgorithmName] = 0;
                    winCounts[best.AlgorithmName]++;
                }
            }

            sb.AppendLine("Number of Best Results per Algorithm:");
            foreach (var kvp in winCounts.OrderByDescending(x => x.Value))
            {
                string algoDisplayName = algorithmAbbrev.ContainsKey(kvp.Key) 
                    ? algorithmAbbrev[kvp.Key] 
                    : kvp.Key;
                sb.AppendLine($"  {algoDisplayName,-45} : {kvp.Value,2} wins");
            }

            sb.AppendLine();
            sb.AppendLine("═══════════════════════════════════════════════════════════════════════════════");

            string summaryFile = Path.Combine(reportsDir, $"MasterSummary_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
            File.WriteAllText(summaryFile, sb.ToString());
            Console.WriteLine($"\n📊 Master summary report saved to: {Path.GetFileName(summaryFile)}");
        }
    }
}

