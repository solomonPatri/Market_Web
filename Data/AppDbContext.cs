using Market_Web.Object.Model;
using Microsoft.EntityFrameworkCore;


namespace Market_Web.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {




        }
        public virtual DbSet<Market> Markets
        {

            get; set;


        }





    }





}
