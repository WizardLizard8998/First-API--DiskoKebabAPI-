using Microsoft.EntityFrameworkCore;
using projectServices.Models;


namespace projectServices.Context
{
    public class LoginContext
                    : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options)
                    : base(options)
        {

        }
        public DbSet<Login> login { get; set; }
    }

}