using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
	    private readonly ApplicationDbContext _context;
        
	    public ItemController(ApplicationDbContext context)
	    {
		    _context = context;
	    }

	    public IActionResult Index()
	    {
		    var items = _context.Items.ToList();
		    return View("Index", items);
	    }

		[HttpGet]
	    public IActionResult Create()
	    {
		    return View("Create");
	    }

		[HttpPost]
	    public IActionResult Create(Models.Item item)
	    {
		    _context.Items.Add(item);
		    _context.SaveChanges();

		    return RedirectToAction("Index");
	    }

	    public IActionResult Delete(int id)
	    {
		    var itemToDelete = _context.Items.FirstOrDefault(x => x.Id == id);
		    _context.Items.Remove(itemToDelete);
		    _context.SaveChanges();

		   return RedirectToAction("Index");
	    }
    }
}
