using Auto.Market.Data;
using Auto.Market.DTOs.Category;
using Auto.Market.Models;
using AutoMapper;
using Avto.Market.BLL.Interface;
using Microsoft.EntityFrameworkCore;

namespace Avto.Market.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryForResultDto>> GetAllAsync()
    {
        var categories = await _context.Categories.Include(c => c.Cars).ToListAsync();
        return _mapper.Map<IEnumerable<CategoryForResultDto>>(categories);
    }

    public async Task<CategoryForResultDto> GetByIdAsync(long id)
    {
        var category = await _context.Categories.Include(c => c.Cars)
            .FirstOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<CategoryForResultDto>(category);
    }

    public async Task<CategoryForResultDto> CreateByIdAsync(CategoryForCreateDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryForResultDto>(category);
    }

    public async Task<CategoryForResultDto> UpdateByIdAsync(long id, CategoryForUpdateDto dto)
    {
        var existCategory = await _context.Categories.FindAsync(id);
        if (existCategory == null) return null;

        _mapper.Map(dto, existCategory);
        _context.Categories.Update(existCategory);
        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryForResultDto>(existCategory);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}