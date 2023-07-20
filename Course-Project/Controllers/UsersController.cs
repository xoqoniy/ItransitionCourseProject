using AutoMapper;
using Course_Project.Domain.Configurations;
using Course_Project.Domain.Entities;
using Course_Project.Models;
using Course_Project.Service.DTOs.Users;
using Course_Project.Service.Exceptions;
using Course_Project.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course_Project.Controllers;

public class UsersController : Controller
{
    private readonly IUserService userService;
    private readonly IMapper mapper;

    public UsersController(IMapper mapper, IUserService userService)
    {
        this.mapper = mapper;
        this.userService = userService;
    }

    #region Index
    public async Task<IActionResult> Index(int pg = 1)
    {
        var users = await userService.RetrieveAllAsync(null);

        const int pageSize = 10;
        if (pg < 1)
            pg = 1;
        int recsCount = users.Count();
        var pager = new Pager(recsCount, pg, pageSize);

        int recSkip = (pg - 1) * pageSize;

        var data = users.Skip(recSkip).Take(pager.PageSize).ToList();

        this.ViewBag.Pager = pager;
        // Wrap the data in a task
        var taskData = Task.FromResult<IEnumerable<UserForResultDto>>(data);

        return View(taskData);
        
    }

    #endregion

    #region Delete
    
    //Get: Users/Delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var user = await userService.RetrieveByIdAsync(id);
        if (user is null || user.IsDeleted)
            return View("NotFound");
        var userForUpdateDto = mapper.Map<UserForUpdateDto>(user);
        return View(userForUpdateDto);
    }


    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var user = await userService.RetrieveByIdAsync(id);
        if (user is null || user.IsDeleted)
            return View("NotFound");

        await userService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Create
    public async Task<IActionResult> Create([Bind("UserName, Email, Password")] UserForCreationDto dto)
    {
        // Perform server-side validation
        if (!ModelState.IsValid)
        {
            // If there are validation errors, redisplay the form with the errors
            return View(dto);
        }

        // If the password is empty or null, throw a CustomException
        if (string.IsNullOrEmpty(dto.Password))
        {
            ModelState.AddModelError("Password", "Password cannot be empty.");
            return View(dto);
        }

        try
        {
            // If the model is valid and password is not empty, proceed with adding the user
            var user = await userService.AddAsync(dto);
            //return View(user);
            return RedirectToAction(nameof(Index));
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }

    #endregion

    #region Details

    public async Task<IActionResult> Details(int id)
    {
        var userDetails = await userService.RetrieveByIdAsync(id);

        if (userDetails == null) return View("NotFound");
        return View(userDetails);
    }

    #endregion

    #region Edit

    //Get: Users/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var user = await userService.RetrieveByIdAsync(id);
        if (user is null)
            return View("NotFound");
        var userForUpdateDto = mapper.Map<UserForUpdateDto>(user);
        return View(userForUpdateDto);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UserName, Email, Password")] UserForUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            // If there are validation errors, redisplay the form with the errors
            return View(dto);
        }

        // If the model is valid and password is not empty, proceed with adding the user
        try
        {
            var user = await userService.ModifyAsync(id, dto);
            return RedirectToAction(nameof(Index));
            //// Pass the updated user to the view
            //return View("Details", user);
        }
        catch (CustomException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(dto);
        }
    }

    #endregion

    #region Block
    //Get: Users/Block/1
    public async Task<IActionResult> Block(int id)
    {
        var user = await userService.RetrieveByIdAsync(id);
        if (user is null || user.IsDeleted)
            return View("NotFound");
        var userForUpdateDto = mapper.Map<UserForUpdateDto>(user);
        return View(userForUpdateDto);
    }


    [HttpPost, ActionName("Block")]
    public async Task<IActionResult> BlockConfirmed(int id)
    {
        var user = await userService.RetrieveByIdAsync(id);
        if (user is null || user.IsDeleted)
            return View("NotFound");

        await userService.Block(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
