using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models;
using ProjetoAPI.Models.Identity;

namespace ProjetoAPI.Persistence.Contextos
{
    public class ProjetoContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public ProjetoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            }
            );

        }
    }
}
