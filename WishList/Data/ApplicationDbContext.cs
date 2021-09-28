using Microsoft.EntityFrameworkCore;
using WishList.Models;

namespace WishList.Data
{
    public class ApplicationDbContext : DbContext
    {
	    public ApplicationDbContext(DbContextOptions <ApplicationDbContext>options) : base(options)
	    {
		    throw new System.NotImplementedException();
	    }

	    public DbSet<Item> Items { get; set; }

    }
}
