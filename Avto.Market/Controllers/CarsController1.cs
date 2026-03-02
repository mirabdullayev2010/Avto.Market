using Auto.Market.Models;
using Avto.Market.BLL.Interface;
using Avto.Market.Shared.DTOs.Car;
using Microsoft.AspNetCore.Mvc;

namespace Avto.Market.Controllers;

public class CarsController : Controller
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<IActionResult> Index()
    {
        var cars = await _carService.GetAllAsync();

        return View(cars ?? new List<CarForResultDto>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CarForCreateDto dto, IFormFile ImagePath)
    {
        if (!ModelState.IsValid) return View(dto);

        string fileName = "no-image.png";

        if (ImagePath != null && ImagePath.Length > 0)
        {
            fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "cars");

            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            var fullPath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await ImagePath.CopyToAsync(stream);
            }
        }

        var car = new Car
        {
            Brend = dto.Brend ?? "Noma'lum",
            Year = dto.Year,
            Price = dto.Price,
            ImagePath = "/images/cars/" + fileName,
            CategoryId = dto.CategoryId > 0 ? dto.CategoryId : 1
        };

        await _carService.CreateByIdAsync(dto);

        return RedirectToAction(nameof(Index));
    }
}