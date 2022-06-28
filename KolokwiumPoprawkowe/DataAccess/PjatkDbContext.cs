using KolokwiumPoprawkowe.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KolokwiumPoprawkowe.DataAccess
{
    public class PjatkDbContext : DbContext
    {
        public PjatkDbContext()
        {
        }

        public PjatkDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<File>(p =>
            {
                p.HasKey(e => new { e.FileID, e.TeamID });
                p.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                p.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                p.Property(e => e.FileSize).IsRequired();
                p.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.NoAction);
                p.HasData(
                    new File { FileID = 1, TeamID = 1, FileName = "NewFile", FileExtension = "xls", FileSize = 1000 }
                    );
            });

            modelBuilder.Entity<Team>(p =>
            {
                p.HasKey(e => e.TeamID);
                p.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                p.Property(e => e.TeamDescription).IsRequired().HasMaxLength(500);
                p.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.NoAction);
                p.HasData(
                    new Team { TeamID = 1, OrganizationID = 1, TeamName = "NewTeam", TeamDescription = "test" }
                    );
            });

            modelBuilder.Entity<Organization>(p =>
            {
                p.HasKey(e => e.OrganizationID);
                p.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                p.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);
                p.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "NewOrganization", OrganizationDomain = "test" }
                    );
            });

            modelBuilder.Entity<Member>(p =>
            {
                p.HasKey(e => e.MemberID);
                p.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                p.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                p.Property(e => e.MemberNickName).IsRequired().HasMaxLength(20);
                p.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.NoAction);
                p.HasData(
                    new Member { MemberID = 1, OrganizationID = 1, MemberName = "NewMember", MemberSurname = "MemberSurname", MemberNickName= "MemberNick" }
                    );
            });

            modelBuilder.Entity<Membership>(p =>
            {
                p.HasKey(e => new { e.MemberID, e.TeamID });
                p.Property(e => e.MembershipDate).IsRequired();
                p.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.NoAction);
                p.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID).OnDelete(DeleteBehavior.NoAction);
                p.HasData(
                    new Membership { MemberID = 1, TeamID = 1, MembershipDate = DateTime.Parse("2022-06-01") }
                    );
            });
        }
    }
}
