using Course_Project.Domain.Configurations;
using Course_Project.Domain.Entities;
using Course_Project.Service.DTOs.Users;

namespace Course_Project.Service.Interfaces;

public interface IUserService
{
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<User> RetrieveByEmailAsync(string email);
    Task RemoveAsync(int id);
    Task<UserForResultDto> RetrieveByIdAsync(int id);
    Task<UserForResultDto> ModifyAsync(int id,UserForUpdateDto dto);
    Task<UserForResultDto> PromoteToAdmin(int id);
    Task<UserForResultDto> Block (int id);
    Task<UserForResultDto> Activate (int id);
    Task<UserForResultDto> DeleteFromAdmin (int id);
}
