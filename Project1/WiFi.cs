using System;
using Problems;

namespace Solvers
{
    class WiFi : NetworkDevice
    {
        private readonly double packetLossChance;
        private static readonly Random rng = new Random(1597);

        public WiFi(string model, int dataLimit, double packetLossChance) : base(model, dataLimit)
        {
            DeviceType = "WiFi";
            this.packetLossChance = packetLossChance;
        }

        public override int? Visit(NetworkProblem networkProblem)
        {
            if (this.GetDataLimit() >= networkProblem.DataToTransfer && !(rng.NextDouble() < packetLossChance))
            {
                this.SetDataLimit(this.GetDataLimit() - networkProblem.DataToTransfer);
                System.Console.WriteLine($"{this.model} resolved the problem");
                return networkProblem.Computation();
            }
            System.Console.WriteLine($"{this.model} failed to resolve the problem");
            return null;
        }
    }
}