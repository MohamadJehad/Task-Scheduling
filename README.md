# Task Scheduling with Eligibility Constraints

**CSCE 5221: Algorithms & Complexity Analysis**  
**Fall 2025**  
**Student:** Mohamad Jehad

## Project Overview

This project implements and evaluates algorithms for the TA task assignment problem with eligibility constraints and TA-dependent processing times. The goal is to minimize the makespan (maximum load across all TAs).

## Problem Definition

- **Input:**
  - Set of tasks P = {1, 2, ..., n}
  - Set of TAs T = {t₁, t₂, ..., tₘ}
  - Each task i has an eligibility set Eᵢ ⊆ T
  - Processing time p_{i,t} for task i assigned to TA t

- **Objective:** Find assignment φ: P → T that minimizes:
  ```
  C_max(φ) = max_{t ∈ T} Σ_{i: φ(i)=t} p_{i,t}
  ```

## Project Structure

```
TaskScheduling/
│
├── TaskScheduling.Common/
│   ├── Models.cs              # Core data structures (TaskInfo, SchedulingResult, etc.)
│   └── ResultAnalyzer.cs      # Result formatting and comparison utilities
│
├── TaskScheduling.BruteForce/
│   └── BruteForceSolver.cs    # Exact algorithm (O(n · ∏|Eᵢ|))
│
├── TaskScheduling.Greedy/
│   └── GreedySolver.cs        # Greedy heuristics with multiple strategies
│
├── TaskScheduling.DataGeneration/
│   └── DatasetGenerator.cs    # Test case generation (small, medium, large)
│
├── Program.cs                  # Main entry point with experiments
├── TaskScheduling.csproj       # C# project file
└── README.md                   # This file
```

## Algorithms Implemented

### 1. Brute Force (Exact)
- **Namespace:** `TaskScheduling.BruteForce`
- **Algorithm:** Recursive enumeration of all feasible assignments
- **Complexity:** O(n · ∏|Eᵢ|)
- **Usage:** Only for small instances (n ≤ 10, |Eᵢ| = 2)

### 2. Greedy Heuristic
- **Namespace:** `TaskScheduling.Greedy`
- **Algorithm:** Eligibility-aware greedy assignment
- **Complexity:** O(n log n + Σ|Eᵢ|)
- **Sorting Strategies:**
  - `MaxProcessingTime`: Sort by maximum processing time (LPT-like)
  - `MinProcessingTime`: Sort by minimum processing time
  - `ProcessingTimeRange`: Sort by range (max - min)
  - `LeastEligible`: Process most constrained tasks first
  - `NoSorting`: Process in given order

### 3. Greedy with Local Improvement
- **Namespace:** `TaskScheduling.Greedy`
- **Algorithm:** Greedy + post-processing local search
- **Improvement:** Iteratively moves tasks to reduce makespan

## How to Build and Run

### Prerequisites
- .NET 6.0 SDK or later
- Windows/Linux/macOS

### Build
```bash
cd "C:\Users\Jehad\Documents\GitHub\Task Scheduling"
dotnet build TaskScheduling.csproj
```

### Run
```bash
dotnet run --project TaskScheduling.csproj
```

## Experiments

The program runs five main experiments:

1. **LaTeX Example** - Validates correctness on the example from the assignment document
2. **Small Instances** - Compares brute force vs greedy on small instances
3. **Medium Instances** - Tests different greedy strategies
4. **Large Instances** - Demonstrates scalability
5. **Comprehensive Evaluation** - Tests various instance types (balanced, constrained, worst-case)

## Dataset Generation

The `DatasetGenerator` class provides several methods:

- `CreateSmallInstance()` - 8 tasks, 3 TAs, |Eᵢ| = 2
- `CreateMediumInstance()` - 30 tasks, 5 TAs, |Eᵢ| ∈ [2,4]
- `CreateLargeInstance()` - 100 tasks, 10 TAs, |Eᵢ| ∈ [2,5]
- `CreateBalancedInstance()` - Uniform task distribution
- `CreateConstrainedInstance()` - Minimal eligibility sets
- `CreateWorstCaseInstance()` - All tasks eligible for all TAs
- `CreateLaTeXExample()` - Example from assignment document

## Results and Analysis

The program outputs:

1. **Comparison Tables** - Side-by-side comparison of algorithms
2. **Approximation Ratios** - Greedy makespan / Optimal makespan
3. **Execution Times** - Runtime measurements
4. **Load Visualizations** - Bar charts showing TA loads
5. **Summary Statistics** - Average, min, max, median approximation ratios

## Key Features

✓ **Two separate namespaces** for brute force and greedy algorithms  
✓ **Multiple dataset sizes** (small, medium, large)  
✓ **TA-dependent processing times** (Extension 1 from assignment)  
✓ **Eligibility constraints** (per-task eligible TA sets)  
✓ **Comprehensive evaluation** with approximation ratio analysis  
✓ **Clean, modular design** with reusable components  
✓ **Detailed output** with visualizations and statistics  

## Sample Output

```
═══════════════════════════════════════════════════════════════
   CSCE 5221: Task Scheduling with Eligibility Constraints
   Mohamad Jehad - Fall 2025
═══════════════════════════════════════════════════════════════

EXPERIMENT 1: LaTeX Document Example
─────────────────────────────────────────────────────────────
Problem: LaTeX Example
Tasks: 2, TAs: 3

ALGORITHM COMPARISON
─────────────────────────────────────────────────────────────
Algorithm                                  Makespan    Time (ms)  Approx Ratio
─────────────────────────────────────────────────────────────
Brute Force (Exact)                               8            5         1.000
Greedy (MaxProcessingTime)                        8            1         1.000
...
```

## Complexity Analysis

### Brute Force
- **Time:** O(n · ∏ᵢ|Eᵢ|)
- **Space:** O(n)
- **Optimal:** Yes

### Greedy
- **Time:** O(n log n + Σᵢ|Eᵢ|)
- **Space:** O(n + m)
- **Optimal:** No (approximation)

## Future Extensions

From assignment (not yet implemented):
- Extension 2: More than two eligible TAs per task ✓ (already supported)
- Extension 3: Performance degradation (sequential task efficiency)
- Extension 4: Fairness constraints

## References

- Assignment: CSCE 5221 Lecture 5 (Prof. Nouri Sakr)
- Related Work: Unrelated machines scheduling, LP-relaxation approaches
- Classical Algorithm: LPT (Longest Processing Time first)

## Author

**Mohamad Jehad**  
Email: mohamadjehad@aucegypt.edu  
Date: October 2025

