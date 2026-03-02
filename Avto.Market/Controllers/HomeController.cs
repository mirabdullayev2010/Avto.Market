using Avto.Market.BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Avto.Market.Controllers;

public class HomeController : Controller
{
    private readonly ICarService _carService;

    public HomeController(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<IActionResult> Index()
    {
        var cars = await _carService.GetAllAsync();
        return View(cars);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}