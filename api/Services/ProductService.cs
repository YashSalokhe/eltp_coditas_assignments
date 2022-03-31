namespace api.Services
{
    public class ProductService : IService<Product, int>
    {
        private readonly ApiDbContext ctx;

        public ProductService(ApiDbContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Product> IService<Product, int>.CreateAsync(Product T)
        {
            var res = await ctx.Products.AddAsync(T);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Product> IService<Product, int>.DeleteAsync(int id)
        {
            var res = await ctx.Products.FindAsync(id);
            if(res == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            ctx.Products.Remove(res);
            await ctx.SaveChangesAsync();
            return res;
        }

        async Task<IEnumerable<Product>> IService<Product, int>.GetAsync()
        {
            return await ctx.Products.ToListAsync();
        }

        async Task<Product> IService<Product, int>.GetAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await ctx.Products.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        async Task<Product> IService<Product, int>.UpdateAsync(int id, Product T)
        {
            var update = await ctx.Products.FindAsync(id);
            if(update == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

            update.ProductName = T.ProductName;
            update.Description = T.Description;
            update.ProductId = T.ProductId;

            await ctx.SaveChangesAsync();

            return update;
        }
    }
}
