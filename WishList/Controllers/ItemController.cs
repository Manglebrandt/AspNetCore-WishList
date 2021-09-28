using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
	    private readonly ApplicationDbContext _context;
        
	    public ItemController(ApplicationDbContext context)
	    {
		    _context = context;
	    }

		[HttpGet]
	    public IActionResult Index()
	    {
		    var items =_context.Items.ToList();
		    return View("Index", items);
	    }

		[HttpPost]
	    public IActionResult Create(Item item)
	    {
		    _context.Items.Add(item);
		    _context.SaveChanges();

		    return RedirectToAction("Create");
	    }

	    public IActionResult Delete(int Id)
	    {
		    var itemToDelete = _context.Items.Find(Id);
		    _context.Remove(itemToDelete);
		    _context.SaveChanges();

		   return RedirectToAction("Index");
	    }
    }
}
