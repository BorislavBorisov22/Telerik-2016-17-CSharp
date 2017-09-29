using ForumSystem.Data.Models;
using ForumSystem.Data.Models.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace ForumSystem.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Post> Posts { get; set; }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public void ApplyAuditInfoRules()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) || e.State == EntityState.Modified)))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified && entity.ModifiedOn == default(DateTime))
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    } 
}
