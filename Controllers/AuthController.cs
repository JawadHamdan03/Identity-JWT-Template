using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecAndIdentity.Data;
using SecAndIdentity.DTOs.Requests;
using SecAndIdentity.DTOs.Responses;
using SecAndIdentity.Interfaces.Services;
using SecAndIdentity.Models;
using SecAndIdentity.Services.Classes;
namespace SecAndIdentity.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager) : ControllerBase
{
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest req )
    {
        try
        {
            if (!ModelState.IsValid)
            return BadRequest("invalid data");

            var appUser = new AppUser()
            {
                UserName=req.UserName,
                Email=req.Email
            };
            
            var isCreated=await userManager.CreateAsync(appUser,req.Password!);
            if (isCreated.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(appUser,"User");
                if (roleResult.Succeeded)
                {
                    string token=tokenService.CreateToken(appUser);
                    var res = new RegisterResponse
                    {
                      UserName=appUser.UserName,
                      Email=appUser.Email,
                      Token= token 
                    };
                    return Ok(res);
                }
                else
                {
                    return StatusCode(500,roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500,isCreated.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500,e);
            
        }
    }


    [HttpPost("login")]
    [Authorize]
    public async Task<IActionResult> Login(LoginRequest request )
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        

        var user = await userManager.Users.FirstOrDefaultAsync(u=> u.Email!.Equals(request.Email));
        
        if (user is null)
            return Unauthorized("Invalid Email");
        
        
        var signInResult=await signInManager.CheckPasswordSignInAsync(user,request.Password!,false);

        if (signInResult.Succeeded)
        {
            var token=tokenService.CreateToken(user);
            return Ok(new LoginResponse
            {
                Email=user.Email,
                UserName=user.UserName,
                Token=token
            });
        }
        
        return Unauthorized("Email or Password is not correct");
    }




}