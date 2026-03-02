namespace Avto.Market.BLL.Interface.Base;

public interface ICrudService<TGetDto, TCreateDto, TUpdateDto>
{
    Task<IEnumerable<TGetDto>> GetAllAsync();
    Task<TGetDto> GetByIdAsync(long id);
    Task<TGetDto> CreateByIdAsync(TCreateDto dto);        
    Task<TGetDto> UpdateByIdAsync(long id, TUpdateDto dto);
    Task DeleteByIdAsync(long id);
}
