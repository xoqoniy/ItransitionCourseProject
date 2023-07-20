using AutoMapper;
using Course_Project.Dal.IRepositories;
using Course_Project.Domain.Configurations;
using Course_Project.Domain.Entities;
using Course_Project.Service.DTOs.Users;
using Course_Project.Service.Exceptions;
using Course_Project.Service.Interfaces;
using Course_Project.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Course_Project.Service.Services;
public class UserService : IUserService
{
    private readonly IRepository<User> userRepository;
    private readonly IMapper mapper;
    public UserService(IMapper mapper,
    IRepository<User> userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<UserForResultDto> Activate(int id)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null || user.IsDeleted)
            throw new CustomException(404, "Couldn't find user for the given Id");
        if (user.IsBlocked)
        {
            user.IsBlocked = false;
        }
        await userRepository.SaveAsync();

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var existUser = await userRepository.SelectAsync(p => p.Email == dto.Email);
        if (existUser != null && !existUser.IsDeleted)
            throw new CustomException(409, "User already exist");

        if (string.IsNullOrEmpty(dto.Password))
            throw new CustomException(400, "Password cannot be empty");

        var mapped = mapper.Map<User>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.Password = PasswordHelper.Hash(dto.Password);



        var addedModel = await userRepository.InsertAsync(mapped);
        await userRepository.SaveAsync();   
        return mapper.Map<UserForResultDto>(addedModel);
    }

    public async Task<UserForResultDto> Block(int id)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null || user.IsDeleted)
            throw new CustomException(404, "Couldn't find user for the given Id");
        if (!user.IsBlocked)
        {
            user.IsBlocked = true;
        }
        await userRepository.SaveAsync();

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> DeleteFromAdmin(int id)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null || user.IsDeleted)
            throw new CustomException(404, "Couldn't find user for the given Id");
        if (user.IsAdmin)
        {
            user.IsAdmin = false;
        }
        await userRepository.SaveAsync();

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> ModifyAsync(int id, UserForUpdateDto dto)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null || user.IsDeleted)
            throw new CustomException(404, "Couldn't find user for the given Id");

        var modifiedUser = mapper.Map(dto, user);
        modifiedUser.UpdatedAt = DateTime.UtcNow;

        await userRepository.SaveAsync();

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> PromoteToAdmin(int id)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null || user.IsDeleted)
            throw new CustomException(404, "Couldn't find user for the given Id");
        if (!user.IsAdmin)
        {
            user.IsAdmin = true;
        }
        await userRepository.SaveAsync();

        return mapper.Map<UserForResultDto>(user);
    }

    public async Task RemoveAsync(int id)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null || user.IsDeleted)
            throw new CustomException(404, "Couldn't find user for this given Id");

        user.IsDeleted = true;
        await userRepository.SaveAsync();
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await userRepository.SelectAll()    
        .Where(u => u.IsDeleted == false)
        .ToListAsync();

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<User> RetrieveByEmailAsync(string email)
    => await userRepository.SelectAsync(u => u.Email == email);

    public async Task<UserForResultDto> RetrieveByIdAsync(int id)
    {
        var user = await userRepository.SelectAsync(u => u.Id == id);
        if (user is null || user.IsDeleted)
            throw new CustomException(404, "User Not Found");

        return mapper.Map<UserForResultDto>(user);   
    }
}
