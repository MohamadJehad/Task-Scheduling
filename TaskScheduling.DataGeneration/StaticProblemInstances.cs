using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.DataGeneration
{
    /// <summary>
    /// Provides access to all static problem instances through a unified interface
    /// </summary>
    public static class StaticProblemInstances
    {
        /// <summary>
        /// Gets all available problem instances
        /// </summary>
        public static IEnumerable<ProblemInstance> GetAllInstances()
        {
            yield return ExampleInstances.LaTeXExample();
            yield return TestInstances.Small();
            yield return TestInstances.Medium();
            yield return TestInstances.Large();
            yield return SpecialInstances.WorstCase();
            yield return SpecialInstances.Constrained();
            yield return SpecialInstances.Balanced();
        }

        /// <summary>
        /// Gets instances suitable for brute force testing (small instances)
        /// </summary>
        public static IEnumerable<ProblemInstance> GetBruteForceInstances()
        {
            yield return ExampleInstances.LaTeXExample();
            yield return TestInstances.Small();
            yield return SpecialInstances.WorstCase(numTasks: 5, numTAs: 2);
        }

        /// <summary>
        /// Gets instances suitable for performance testing (medium to large instances)
        /// </summary>
        public static IEnumerable<ProblemInstance> GetPerformanceInstances()
        {
            yield return TestInstances.Medium();
            yield return TestInstances.Large();
            yield return SpecialInstances.Balanced();
        }

        /// <summary>
        /// Gets instances with special characteristics for algorithm analysis
        /// </summary>
        public static IEnumerable<ProblemInstance> GetSpecialInstances()
        {
            yield return SpecialInstances.WorstCase();
            yield return SpecialInstances.Constrained();
            yield return SpecialInstances.Balanced();
        }
    }
}
