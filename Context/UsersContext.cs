namespace projectServices.Context
{
    using Microsoft.EntityFrameworkCore;
    using projectServices.Models;
    public class UsersContext
            : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {

        }
        public DbSet<Users> users { get; set; }
    }

}

