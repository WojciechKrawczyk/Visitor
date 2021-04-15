using System;
using Solvers;

namespace Problems
{
    class NetworkProblem : Problem
    {
        public int DataToTransfer { get; }

        public NetworkProblem(string name, Func<int> computation, int dataToTransfer) : base(name, computation)
        {
            DataToTransfer = dataToTransfer;
        }

        public override int? Accept(ISolver visitor)
        {
            int? value = visitor.Visit(this);
            TryMarkAsSolved(value);
            return value;
        }
    }
}