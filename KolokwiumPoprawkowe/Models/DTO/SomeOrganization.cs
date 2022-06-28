using System.Collections.Generic;

namespace KolokwiumPoprawkowe.Models.DTO
{
    public class SomeOrganization
    {
        public int OrganizationID { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationDomain { get; set; }

        public virtual ICollection<SomeTeam> SomeTeams { get; set; }

        public virtual ICollection<SomeMember> SomeMembers { get; set; }
    }
}
