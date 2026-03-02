using Avto.Market.BLL.Interface;
using Avto.Market.Shared.DTOs.Car;
using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    private readonly ICarService _carService;
    private readonly IWebHostEnvironment _env;

    public AdminController(ICarService carService, IWebHostEnvironment env)
    {
        _carService = carService;
        _env = env;
    }

    public async Task<IActionResult> Index()
    {
        var cars = await _carService.GetAllAsync();
        return View(cars);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CarForCreateDto carDto, IFormFile? ImageFile)
    {
        // 1. Fayl orqali rasm yuklash
        if (ImageFile != null)
        {
            string folder = Path.Combine("images", "cars");
            string pathToSave = Path.Combine(_env.WebRootPath, folder);

            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);

            string fileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
            string fullPath = Path.Combine(pathToSave, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }
            carDto.ImagePath = "/" + folder.Replace("\\", "/") + "/" + fileName;
        }

        // 2. Kategoriya ID xatosini oldini olish
        if (carDto.CategoryId == 0)
        {
            carDto.CategoryId = 1; // Program.cs da yaratgan 1-ID li kategoriyamiz
        }

        if (ModelState.IsValid)
        {
            await _carService.CreateByIdAsync(carDto);
            return RedirectToAction(nameof(Index));
        }
        return View(carDto);
    }
}