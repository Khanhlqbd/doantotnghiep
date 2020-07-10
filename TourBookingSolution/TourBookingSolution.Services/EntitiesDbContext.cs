using TourBookingSolution.Data.Models;
using System.Data.Entity;

namespace TourBookingSolution.Services
{
    public class EntitiesDbContext : DbContext
    {
        public EntitiesDbContext() : base("conStr")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AssignPosition> AssignPositions { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberLevel> MemberLevels { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public static EntitiesDbContext Create()
        {
            return new EntitiesDbContext();
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
