using Fintalks.Common.Constants;
using Fintalks.DB.DBEntity;
using Fintalks.DB.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Fintalks.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options) { }

        public DbSet<DBUser> Users { get; set; }
        public DbSet<DBUserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBUser>().HasQueryFilter(e => e.DeletedAt == null);
            modelBuilder.Entity<DBUser>().HasKey(e => e.ID);
            modelBuilder.Entity<DBUser>().Property(e => e.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<DBUser>().HasIndex(e => e.UserID).IsUnique();
            modelBuilder.Entity<DBUser>().HasIndex(e => e.UserName).IsUnique();
            modelBuilder.Entity<DBUser>().HasIndex(e => e.Email).IsUnique();
            modelBuilder
                .Entity<DBUser>()
                .Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(UserConst.Length.maxUserName);
            modelBuilder
                .Entity<DBUser>()
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(UserConst.Length.maxFirstName);
            modelBuilder
                .Entity<DBUser>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(UserConst.Length.maxLastName);
            modelBuilder
                .Entity<DBUser>()
                .Property(e => e.Email)
                .HasMaxLength(UserConst.Length.maxEmail);
            modelBuilder
                .Entity<DBUser>()
                .Property(e => e.Bio)
                .HasMaxLength(UserConst.Length.maxBio);

            modelBuilder
                .Entity<DBUser>()
                .HasOne(e => e.UserInfo)
                .WithOne(e => e.User)
                .HasForeignKey<DBUserInfo>(e => e.DBUserID)
                .IsRequired();

            modelBuilder.Entity<DBUserInfo>().HasKey(e => e.ID);
            modelBuilder.Entity<DBUserInfo>().Property(e => e.ID).ValueGeneratedOnAdd();
            modelBuilder
                .Entity<DBUserInfo>()
                .Property(e => e.FatherName)
                .HasMaxLength(UserConst.Length.maxFatherName);
            modelBuilder
                .Entity<DBUserInfo>()
                .Property(e => e.MotherName)
                .HasMaxLength(UserConst.Length.maxMotherName);
            modelBuilder
                .Entity<DBUserInfo>()
                .Property(e => e.Nid)
                .HasMaxLength(UserConst.Length.maxNid);
            modelBuilder
                .Entity<DBUserInfo>()
                .Property(e => e.PhoneNumber)
                .HasMaxLength(UserConst.Length.maxPhoneNumber);

            base.OnModelCreating(modelBuilder);
        }
    }
}
