using System;

namespace KolokwiumPoprawkowe.Models.DTO
{
    public class SomeMembership
    {
        public int MemberID { get; set; }

        public int TeamID { get; set; }

        public DateTime MembershipDate { get; set; }

        public virtual SomeMember SomeMember { get; set; }

        public virtual SomeTeam SomeTeam { get; set; }
    }
}
