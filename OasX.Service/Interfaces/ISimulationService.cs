using OasX.Domain.Service;

namespace OasX.Service.Interfaces
{
    public interface ISimulationService
    {
        Paper GeneratePaper(string courseId, string style);
    }
}