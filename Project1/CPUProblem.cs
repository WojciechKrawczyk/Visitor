using System;
using Solvers;

namespace Problems
{
    class CPUProblem : Problem
    {
        public int RequiredThreads { get; }

        public CPUProblem(string name, Func<int> computation, int requiredThreads) : base(name, computation)
        {
            RequiredThreads = requiredThreads;
        }

        public override int? Accept(ISolver visitor)
        {
            int? value = visitor.Visit(this);
            TryMarkAsSolved(value);
            return value;
        }
    }
}