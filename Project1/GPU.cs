using System;
using Problems;

namespace Solvers
{
    class GPU : ISolver
    {
        static private int MaxTemperature { get; } = 100;
        static private int CPUProblemTemperatureMultiplier { get; } = 3;

        private readonly string model;
        private int temperature;
        private int coolingFactor;

        public GPU(string model, int temperature, int coolingFactor)
        {
            this.model = model;
            this.temperature = temperature;
            this.coolingFactor = coolingFactor;
        }

        private bool DidThermalThrottle()
        {
            if (temperature > MaxTemperature)
            {
                Console.WriteLine($"GPU {model} thermal throttled");
                CoolDown();
                return true;
            }

            return false;
        }

        private void CoolDown()
        {
            temperature -= coolingFactor;
        }

        public int? Visit(CPUProblem cPUProblem)
        {
            if (!DidThermalThrottle())
            {
                this.temperature += CPUProblemTemperatureMultiplier * cPUProblem.RequiredThreads;
                System.Console.WriteLine($"{this.model} resolved the problem");
                return cPUProblem.Computation();
            }
            System.Console.WriteLine($"{this.model} failed to resolve the problem");
            return null;
        }

        public int? Visit(GPUProblem gPUProblem)
        {
            if (!DidThermalThrottle())
            {
                this.temperature += gPUProblem.GpuTemperatureIncrease;
                System.Console.WriteLine($"{this.model} resolved the problem");
                return gPUProblem.Computation();
            }
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