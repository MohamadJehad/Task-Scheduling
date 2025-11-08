using System;
using System.Collections.Generic;
using System.Linq;
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

            // Run different experiments
            // RunLaTeXExample();
            // Console.WriteLine("\n" + new string('═', 70) + "\n");

            // RunSmallInstanceExperiments();
            // Console.WriteLine("\n" + new string('═', 70) + "\n");

            // RunMediumInstanceExperiments();
            // Console.WriteLine("\n" + new string('═', 70) + "\n");

            RunLargeInstanceExperiments();
            Console.WriteLine("\n" + new string('═', 70) + "\n");

            // RunComprehensiveEvaluation();

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

            // Greedy with different strategies
            var greedySolver1 = new GreedySolver(GreedySortStrategy.MaxProcessingTime);
            results.Add(greedySolver1.Solve(problem));

            var greedySolver2 = new GreedySolver(GreedySortStrategy.MinProcessingTime);
            results.Add(greedySolver2.Solve(problem));

            // Greedy with local improvement
            var improvedSolver = new GreedyWithLocalImprovement(GreedySortStrategy.MaxProcessingTime);
            results.Add(improvedSolver.Solve(problem));

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
                    Console.WriteLine($"Brute Force: Makespan = {optimalResult.Makespan}, Time = {optimalResult.ExecutionTimeMs} ms");
                }
                else
                {
                    Console.WriteLine("Brute force skipped (too many assignments)");
                }

                var greedySolver = new GreedySolver(GreedySortStrategy.MaxProcessingTime);
                var greedyResult = greedySolver.Solve(problem);
                Console.WriteLine($"Greedy: Makespan = {greedyResult.Makespan}, Time = {greedyResult.ExecutionTimeMs} ms");

                double? ratio = null;
                if (optimalResult != null && optimalResult.Makespan > 0)
                {
                    ratio = (double)greedyResult.Makespan / optimalResult.Makespan;
                    Console.WriteLine($"Approximation Ratio: {ratio:F3}");
                }

                experiments.Add(new ExperimentResult
                {
                    InstanceName = problem.Name,
                    NumTasks = problem.TaskCount,
                    NumTAs = problem.TACount,
                    OptimalMakespan = optimalResult?.Makespan,
                    GreedyMakespan = greedyResult.Makespan,
                    GreedyTimeMs = greedyResult.ExecutionTimeMs,
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

            // Compare different greedy strategies
            foreach (GreedySortStrategy strategy in Enum.GetValues(typeof(GreedySortStrategy)))
            {
                var solver = new GreedySolver(strategy);
                var result = solver.Solve(problem);
                results.Add(result);
                Console.WriteLine($"{strategy,-25}: Makespan = {result.Makespan,5}, Time = {result.ExecutionTimeMs,5} ms");
            }

            // Try with local improvement
            var improvedSolver = new GreedyWithLocalImprovement(GreedySortStrategy.MaxProcessingTime);
            var improvedResult = improvedSolver.Solve(problem);
            results.Add(improvedResult);
            Console.WriteLine($"{"With Local Improvement",-25}: Makespan = {improvedResult.Makespan,5}, Time = {improvedResult.ExecutionTimeMs,5} ms");

            Console.WriteLine();
            Console.WriteLine("Best result: " + results.OrderBy(r => r.Makespan).First().AlgorithmName);
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
            var solver1 = new GreedySolver(GreedySortStrategy.MaxProcessingTime);
            var result1 = solver1.Solve(problem);

            var solver2 = new GreedyWithLocalImprovement(GreedySortStrategy.MaxProcessingTime, maxIterations: 50);
            var result2 = solver2.Solve(problem);

            Console.WriteLine($"Greedy (MaxProcessingTime): Makespan = {result1.Makespan}, Time = {result1.ExecutionTimeMs} ms");
            Console.WriteLine($"Greedy + Local Improvement: Makespan = {result2.Makespan}, Time = {result2.ExecutionTimeMs} ms");
            Console.WriteLine($"Improvement: {((double)result1.Makespan / result2.Makespan - 1) * 100:F2}%");
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
                        Console.WriteLine($"  Optimal: {optimalResult.Makespan}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"  Optimal: Failed ({ex.Message})");
                    }
                }

                var greedySolver = new GreedySolver(GreedySortStrategy.MaxProcessingTime);
                var greedyResult = greedySolver.Solve(problem);
                Console.WriteLine($"  Greedy:  {greedyResult.Makespan}");

                double? ratio = null;
                if (optimalResult != null && optimalResult.Makespan > 0)
                {
                    ratio = (double)greedyResult.Makespan / optimalResult.Makespan;
                    Console.WriteLine($"  Ratio:   {ratio:F3}");
                }

                experiments.Add(new ExperimentResult
                {
                    InstanceName = problem.Name,
                    NumTasks = problem.TaskCount,
                    NumTAs = problem.TACount,
                    OptimalMakespan = optimalResult?.Makespan,
                    GreedyMakespan = greedyResult.Makespan,
                    GreedyTimeMs = greedyResult.ExecutionTimeMs,
                    ApproximationRatio = ratio
                });
            }

            Console.WriteLine();
            Console.WriteLine(ResultAnalyzer.GenerateSummaryTable(experiments));
        }
    }
}

