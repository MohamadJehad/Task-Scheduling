using System;
using System.Collections.Generic;
using System.Linq;
using TaskScheduling.Common;

namespace TaskScheduling.Greedy
{
    /// <summary>
    /// TA Skill Sort Solver - Sorts TAs by number of tasks they can perform (ascending) and current load (descending)
    /// Prioritizes constrained TAs (fewer eligible tasks) first, then prefers TAs with higher current load
    /// </summary>
    public class TASkillSortSolver
    {
        /// <summary>
        /// Solves by considering TAs sorted by skills (ascending) and loads (descending)
        /// First prioritizes TAs with fewer eligible tasks (more constrained), then prefers those with higher current load
        /// </summary>
        public SchedulingResult Solve(ProblemInstance problem)
        {
            // Initialize loads for all TAs
            var loads = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
                loads[ta.Name] = 0;

            // Calculate skills for each TA (number of tasks they can perform)
            var taSkills = new Dictionary<string, int>();
            foreach (var ta in problem.TAs)
            {
                int skillCount = problem.Tasks.Count(t => t.EligibleTAs.Any(e => e.Name == ta.Name));
                taSkills[ta.Name] = skillCount;
            }

            var assignment = new Dictionary<string, string>();

            // Process tasks in order
            foreach (var task in problem.Tasks)
            {
                // Sort eligible TAs by: skills ascending (prioritize constrained TAs), then load descending
                // This ensures we prioritize TAs with fewer eligible tasks first, then prefer those with higher current load
                string bestTA = task.EligibleTAs
                    .OrderBy(ta => taSkills[ta.Name])      // Ascending by skills (fewer tasks = more constrained, prioritize these)
                    .ThenByDescending(ta => loads[ta.Name])  // Descending by load (prefer TAs with higher current load)
                    .Select(ta => ta.Name)
                    .First();

                assignment[task.Name] = bestTA;
                loads[bestTA] += task.ProcessingTimes[bestTA];
            }

            int makespan = loads.Values.Max();

            return new SchedulingResult
            {
                Assignment = assignment,
                Loads = loads,
                Makespan = makespan,
                AlgorithmName = "TA Skill Sort (Skills Asc, Load Desc)"
            };
        }
    }
}

