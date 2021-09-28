using System.Collections.Generic;
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

	    public IActionResult Index()
	    {
		    return View("Index", new List<Item>(_context.Items));
	    }

		[HttpGet]
	    public IActionResult Create()
	    {
		    return View("Create");
	    }

		[HttpPost]
	    public IActionResult Create(Item item)
	    {
		    _context.Items.Add(item);
		    _context.SaveChanges();

		    return RedirectToAction("Index");
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
