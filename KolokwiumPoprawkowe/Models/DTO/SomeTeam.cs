using System.Collections.Generic;

namespace KolokwiumPoprawkowe.Models.DTO
{
    public class SomeTeam
    {
        public int TeamID { get; set; }

        public int OrganizationID { get; set; }

        public string TeamName { get; set; }

        public string? TeamDescription { get; set; }

        public virtual SomeOrganization SomeOrganization { get; set; }

        public virtual ICollection<SomeFile> SomeFiles { get; set; }

        public virtual ICollection<SomeMembership> SomeMemberships { get; set; }
    }
}
