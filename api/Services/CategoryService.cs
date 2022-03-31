namespace api.Services
{
    public class CategoryService : IService<Category, int>
    {
        private readonly ApiDbContext ctx;
        public CategoryService(ApiDbContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<Category> IService<Category, int>.CreateAsync(Category T)
        {
            var res = await ctx.Category.AddAsync(T);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Category> IService<Category, int>.DeleteAsync(int id)
        {
            var res = await ctx.Category.FindAsync(id);
            if(res == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            ctx.Category.Remove(res);
            await ctx.SaveChangesAsync();
            return res;

        }

        async Task<IEnumerable<Category>> IService<Category, int>.GetAsync()
        {
            return await ctx.Category.ToListAsync();
        }

        async Task<Category> IService<Category, int>.GetAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await ctx.Category.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        async Task<Category> IService<Category, int>.UpdateAsync(int id, Category T)
        {
            var update = await ctx.Category.FindAsync(id);
            if(update == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            update.CategoryId = T.CategoryId;
            update.CategoryName = T.CategoryName;
            update.BasePrice = T.BasePrice;

            await ctx.SaveChangesAsync();

            return update;  

        }
    }
}
