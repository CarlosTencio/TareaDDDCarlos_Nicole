using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDTO>> GetAllAsync();
        Task<PersonDTO> GetByIdAsync(int id);
        Task AddAsync(PersonDTO person);
        Task UpdateAsync(PersonDTO person);
        Task DeleteAsync(int id);
    }
}
