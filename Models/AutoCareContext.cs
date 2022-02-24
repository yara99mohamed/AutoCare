using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoCare.ViewModels;

namespace AutoCare.Models
{
    public class AutoCareContext : IdentityDbContext
    {
        public AutoCareContext(DbContextOptions<AutoCareContext> options) : base(options)
        { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CheckUps> CheckUps { get; set; }
        public DbSet<CheckUpsServices> CheckUpsServices { get; set; }
        public DbSet<CheckUpsSpareParts> CheckUpsSpareParts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<SpareParts> SpareParts { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CarViewModel>(builder =>
            {
                builder.HasNoKey();

            });
            modelBuilder.Entity<RegisterViewModel>(builder =>
            {
                builder.HasNoKey();
            });
            modelBuilder.Entity<LoginViewModel>(builder =>
            {
                builder.HasNoKey();
            });
        }

        public DbSet<AutoCare.ViewModels.RegisterViewModel> RegisterViewModel { get; set; }

        public DbSet<AutoCare.ViewModels.LoginViewModel> LoginViewModel { get; set; }
   }
}
