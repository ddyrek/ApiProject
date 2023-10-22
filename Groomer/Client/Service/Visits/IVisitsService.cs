using Groomer.Shared.Visits.Commands;

namespace Groomer.Client.Service.Visits
{
    public interface IVisitsService
    {
        Task AddVisitsAsync(AddVisitVM customer);
    }
}
