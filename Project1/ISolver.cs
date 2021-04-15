using Problems;

namespace Solvers
{
    interface ISolver
    {
        int? Visit(CPUProblem cPUProblem);
        int? Visit(GPUProblem gPUProblem);
        int? Visit(NetworkProblem networkProblem);
    }
}