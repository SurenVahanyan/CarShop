using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;


public class CarController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarController(ApplicationDbContext data)
    {
        _context = data;
    }

    public IActionResult Index()
    {
        return View(_context.Categories.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(car);
    }

    public IActionResult Edit(int id)
    {
        var car = _context.Categories.ToList().FirstOrDefault(c => c.Id == id);
        if (car == null)
            return NotFound();

        return View(car);
    }

    [HttpPost]
    public IActionResult Edit(Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Update(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return NotFound();

    }

    public IActionResult Delete(int id)
    {
        var car = _context.Categories.ToList().FirstOrDefault(c => c.Id == id);
        if (car == null)
            return NotFound();

        _context.Categories.Remove(car);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}

