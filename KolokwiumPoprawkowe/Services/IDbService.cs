using KolokwiumPoprawkowe.Models.DTO;
using System.Threading.Tasks;

namespace KolokwiumPoprawkowe.Services
{
    public interface IDbService
    {
        Task<SomeTeam> GetTeam(int idTeam);
        Task<bool> AddMemberToTeam(SomeMember member);
    }
}
