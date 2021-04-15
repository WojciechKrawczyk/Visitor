using System;
using Problems;

namespace Solvers
{
    class CPU : ISolver
    {
        private readonly string model;
        private readonly int threads;

        public CPU(string model, int threads)
        {
            this.model = model;
            this.threads = threads;
        }

        public int? Visit(CPUProblem cPUProblem)
        {
            if (this.threads >= cPUProblem.RequiredThreads)
            {
                System.Console.WriteLine($"{this.model} resolved the problem");
                return cPUProblem.Computation();
            }
            System.Console.WriteLine($"{this.model} failed to resolve the problem");
            return null;
        }

        public int? Visit(GPUProblem gPUProblem)
        {
            System.Console.WriteLine($"{this.model} failed to resolve the problem");
            return null;
        }

        public int? Visit(NetworkProblem networkProblem)
        {
            System.Console.WriteLine($"{this.model} failed to resolve the problem");
            return null;
        }
    }
}