using KolokwiumPoprawkowe.DataAccess;
using KolokwiumPoprawkowe.Models;
using KolokwiumPoprawkowe.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumPoprawkowe.Services
{
    public class DbService : IDbService
    {
        private readonly PjatkDbContext _context;

        public DbService(PjatkDbContext context)
        {
            _context = context;
        }
         
        public async Task<SomeTeam> GetTeam(int idTeam)
        {
            return await _context.Teams
                .Include(e => e.Organization)
                .Include(e => e.Memberships)
                .Select(e => new SomeTeam
                {
                    TeamID = e.TeamID,
                    OrganizationID = e.OrganizationID,
                    TeamName = e.TeamName,
                    TeamDescription = e.TeamDescription,
                    SomeOrganization = new SomeOrganization
                    {
                        OrganizationName = e.Organization.OrganizationName,
                    }
                }).SingleOrDefaultAsync(e => e.TeamID == idTeam);

        }

        public async Task<bool> AddMemberToTeam(SomeMember member)
        {
            var existingMember = await _context.Members.SingleOrDefaultAsync(e => e.MemberID == member.MemberID);

            if(existingMember != null)
            {
                return false;
            }

            var newMember = new Member
            {
                OrganizationID = member.OrganizationID,
                MemberID = member.MemberID,
                MemberName = member.MemberName,
                MemberNickName = member.MemberNickName,
                MemberSurname = member.MemberSurname

            };

            await _context.Members.AddAsync(newMember);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}       
