using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecAndIdentity.DTOs.Requests;
using SecAndIdentity.DTOs.Responses;
using SecAndIdentity.Interfaces.Services;
using SecAndIdentity.Models;
namespace SecAndIdentity.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthController(UserManager<AppUser> userManager, ITokenService tokenService) : ControllerBase
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
    public IActionResult Login()
    {
        return Ok();
    }




}