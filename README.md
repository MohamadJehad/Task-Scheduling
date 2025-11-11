# Task Scheduling Project

CSCE 5221: Algorithms & Complexity Analysis  
**Mohamad Jehad - Fall 2025**

## 🚀 Quick Start in Google Colab

The easiest way to run this project is using Google Colab - **no login required!**

### Option 1: Direct Link (Easiest)
Click this badge to open the notebook directly in Google Colab:

[![Open In Colab](https://colab.research.google.com/assets/colab-badge.svg)](https://colab.research.google.com/github/MohamadJehad/Task-Scheduling/blob/main/run_in_colab.ipynb)

### Option 2: Manual Steps
1. Go to [colab.research.google.com](https://colab.research.google.com)
2. Click **"File"** → **"Open notebook"**
3. Select the **"GitHub"** tab
4. Enter: `MohamadJehad/Task-Scheduling`
5. Select `run_in_colab.ipynb`
6. Click **"Runtime"** → **"Run all"** (or press `Ctrl+F9`)

That's it! The notebook will:
- ✅ Install .NET SDK automatically
- ✅ Clone the repository
- ✅ Build and run all experiments
- ✅ Display results in the notebook

## 📋 Project Description

This project implements and compares different algorithms for task scheduling with eligibility constraints:
- **Brute Force (Exact)** - Optimal solution using exhaustive search
- **Greedy (No Sorting)** - Simple greedy heuristic
- **Greedy (Sort Loads Desc)** - Greedy with load-based task sorting
- **Greedy (Sort Loads Desc, TAs Asc by Skills)** - Greedy with both task and TA sorting

## 📊 Output

The project generates:
- **Master Summary Report** - Comprehensive comparison of all algorithms across all instances
- **Individual Reports** - Detailed analysis for each problem instance

All reports are displayed in the Colab notebook and saved in the `reports/` folder.

## 🛠️ Local Development

If you want to run locally:

### Prerequisites
- .NET SDK 6.0 or later

### Steps
```bash
# Clone the repository
git clone https://github.com/MohamadJehad/Task-Scheduling.git
cd Task-Scheduling

# Restore packages
dotnet restore

# Build the project
dotnet build

# Run all experiments
dotnet run
```

Reports will be generated in the `reports/` directory.

## 📁 Project Structure

```
Task-Scheduling/
├── run_in_colab.ipynb      # Google Colab notebook
├── Program.cs              # Main entry point
├── TaskScheduling.Common/   # Common utilities
├── TaskScheduling.BruteForce/  # Brute force solver
├── TaskScheduling.Greedy/     # Greedy algorithms
├── TaskScheduling.DataGeneration/  # Test instances
└── reports/                # Generated reports
```

## 📝 Notes

- The project automatically clears old reports before generating new ones
- All test instances follow the constraint: each task can be performed by exactly 2 TAs with identical processing times
- Results are displayed in the console and saved to text files

## 🔗 Links

- **Repository**: https://github.com/MohamadJehad/Task-Scheduling
- **Colab Notebook**: [Open in Colab](https://colab.research.google.com/github/MohamadJehad/Task-Scheduling/blob/main/run_in_colab.ipynb)

