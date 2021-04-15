using System;
using Problems;

namespace Solvers
{
    abstract class NetworkDevice : ISolver
    {
        protected string DeviceType { get; set; } = "NetworkDevice";

        protected readonly string model;
        private int dataLimit;

        protected NetworkDevice(string model, int dataLimit)
        {
            this.model = model;
            this.dataLimit = dataLimit;
        }

        protected int GetDataLimit()
        {
            return this.dataLimit;
        }

        protected void SetDataLimit(int value)
        {
            this.dataLimit = value;
        }

        public int? Visit(CPUProblem cPUProblem)
        {
            System.Console.WriteLine($"{this.model} failed to resolve the problem");
            return null;
        }

        public int? Visit(GPUProblem gPUProblem)
        {
            System.Console.WriteLine($"{this.model} failed to resolve the problem");
            return null;
        }

        public abstract int? Visit(NetworkProblem networkProblem);
    }
}