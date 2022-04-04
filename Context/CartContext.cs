namespace projectServices.Context
{
    using Microsoft.EntityFrameworkCore;
    using projectServices.Models;

    public class CartContext
            : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {

        }
        public DbSet<Cart> Cart { get; set; }
    }

}

