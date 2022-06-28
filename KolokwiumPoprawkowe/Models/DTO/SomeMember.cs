using System.Collections.Generic;

namespace KolokwiumPoprawkowe.Models.DTO
{
    public class SomeMember
    {
        public int MemberID { get; set; }

        public int OrganizationID { get; set; }

        public string MemberName { get; set; }

        public string MemberSurname { get; set; }

        public string? MemberNickName { get; set; }

        public virtual SomeOrganization SomeOrganization { get; set; }

        public ICollection<SomeMembership> SomeMemberships { get; set; }
    }
}
