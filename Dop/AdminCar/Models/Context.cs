using Microsoft.EntityFrameworkCore;

namespace AdminCar.Models
{
    public class Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string userRoleName = "user";

            string adminRoleName = "admin";
            string adminEmail = "admin";
            string adminPassword = "1111";
            
            string moderRoleName = "moder";
            string moderEmail = "moder";
            string moderPassword = "1111";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            Role moderRole = new Role { Id = 3, Name = moderRoleName };

            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            User moderUser = new User { Id = 2, Email = moderEmail, Password = moderPassword, RoleId = moderRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, moderRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, moderUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
