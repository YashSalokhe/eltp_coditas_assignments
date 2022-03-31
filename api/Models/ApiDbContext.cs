namespace api.Models
{
    public class ApiDbContext : DbContext
    {
        public  DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                          .HasOne(c => c.Category)
                          .WithMany(p => p.Products)
                          .HasForeignKey(p => p.CategoryRowId);
            base.OnModelCreating(modelBuilder);
        }


    }
}
