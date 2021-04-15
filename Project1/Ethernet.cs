using System;
using Problems;

namespace Solvers
{
    class Ethernet : NetworkDevice
    {
        public Ethernet(string model, int dataLimit) : base(model, dataLimit)
        {
            DeviceType = "Ethernet";
        }

        public override int? Visit(NetworkProblem networkProblem)
        {
            if (this.GetDataLimit() >= networkProblem.DataToTransfer)
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