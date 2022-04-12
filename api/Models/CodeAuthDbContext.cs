namespace api.Models
{
    public class CodeAuthDbContext : IdentityDbContext<IdentityUser>
    {
        public CodeAuthDbContext(DbContextOptions<CodeAuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
