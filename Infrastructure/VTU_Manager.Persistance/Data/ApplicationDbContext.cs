using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using VTU_Manager.Domain.Entities;
using VTU_Manager.Domain.Interfaces.Models;
using VTU_Manager.Domain.Interfaces.Services.Utility;

namespace VTU_Manager.Persistance.Data
{
    public class ApplicationDbContext : IdentityDbContext<VTUser, VTRole, string>
    {
        private readonly ICurrentUserService currentUserService;

        public ApplicationDbContext(DbContextOptions options,
            ICurrentUserService currentUserService) : base(options)
        {
            this.currentUserService = currentUserService;
        }

        public DbSet<EligibleEmail> EligableEmails { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Protocol> Protocols { get; set; }

        public DbSet<ProjectAccess> ProjectAccesses { get; set; }

        public DbSet<ProtocolFile> ProtocolFiles { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<DropDownSource> DropDawnSources { get; set; }

        public DbSet<DropDownItem> DropDownItems { get; set; }

        public DbSet<ProjectAccessVTUser> ProjectAccessVTUsers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is IEntityBase && x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified).ToList();

            foreach (EntityEntry entry in entries)
            {
                var entity = (IEntityBase)entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedBy = currentUserService.UserId;
                        entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entity.LastModifiedBy = currentUserService.UserId;
                        entity.LastModified = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entity.DateDeleted = DateTime.Now;
                        entity.IsDeleted = true;
                        entity.DeletedBy = currentUserService.UserId;
                        entry.State = EntityState.Modified;
                        break;
                }
            }

            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Protocol>().ToTable("Protocols", "Antiplagiat");
            builder.Entity<Department>().ToTable("Departments", "Antiplagiat");
            builder.Entity<ProtocolFile>().ToTable("ProtocolFiles", "Antiplagiat");

            builder.Entity<ProjectAccessVTUser>()
                .HasKey(p => new { p.VTUserId, p.ProjectAccessId }); // Composite primary key

            builder.Entity<ProjectAccessVTUser>()
                .HasOne(pt => pt.VTUser)
                .WithMany(p => p.VTUserProjectAccesses)
                .HasForeignKey(pt => pt.VTUserId);

            builder.Entity<ProjectAccessVTUser>()
                .HasOne(pt => pt.ProjectAccess)
                .WithMany(t => t.ProjectAccessesVTUsers)
                .HasForeignKey(pt => pt.ProjectAccessId);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
