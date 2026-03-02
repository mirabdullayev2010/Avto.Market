using Auto.Market.Data;
using Auto.Market.Models;
using AutoMapper;
using Avto.Market.BLL.Interface;
using Avto.Market.Shared.DTOs.Car;
using Microsoft.EntityFrameworkCore;

namespace Avto.Market.BLL.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CarService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarForResultDto>> GetAllAsync()
    {
        var cars = await _context.Cars.Include(c => c.Category).ToListAsync();
        return _mapper.Map<IEnumerable<CarForResultDto>>(cars);
    }

    public async Task<CarForResultDto> GetByIdAsync(long id)
    {
        var car = await _context.Cars.Include(c => c.Category)
            .FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<CarForResultDto>(car);
    }

    public async Task<CarForResultDto> CreateByIdAsync(CarForCreateDto dto)
    {
        var car = _mapper.Map<Car>(dto);
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();

        // MUHIM: Bazadan yangi qo'shilgan mashinani KATEGORIYASI BILAN qayta o'qiymiz
        var resultCar = await _context.Cars
            .Include(c => c.Category)
            .FirstOrDefaultAsync(c => c.Id == car.Id);

        return _mapper.Map<CarForResultDto>(resultCar);
    }

    public async Task<CarForResultDto> UpdateByIdAsync(long id, CarForUpdateDto dto)
    {
        var existCar = await _context.Cars.FindAsync(id);
        if (existCar == null) return null;

        _mapper.Map(dto, existCar);
        _context.Cars.Update(existCar);
        await _context.SaveChangesAsync();
        return _mapper.Map<CarForResultDto>(existCar);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}