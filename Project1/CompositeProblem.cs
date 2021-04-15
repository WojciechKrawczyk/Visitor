using System;
using System.Collections.Generic;
using System.Linq;
using ResultsCombiners;
using Solvers;

namespace Problems
{
    class CompositeProblem : Problem
    {
        private readonly IEnumerable<Problem> problems;
        private readonly IResultsCombiner resultsCombiner;

        public CompositeProblem(string name, IEnumerable<Problem> problems,
            IResultsCombiner resultsCombiner) : base(name, () => 0)
        {
            this.problems = problems;
            this.resultsCombiner = resultsCombiner;
        }

        public override int? Accept(ISolver visitor)
        {
            List<int> results = new List<int>();
            bool solved = true;
            foreach (var problem in problems)
            {
                if (problem.Solved == false)
                {
                    problem.Accept(visitor);
                    if (problem.Solved == false)
                        solved = false;
                }
                else
                    results.Add(problem.Result.Value);
            }
            if(solved)
            {
                int value = resultsCombiner.CombineResults(results);
                TryMarkAsSolved(value);
                return value;
            }
            return null;
        }
    }
}