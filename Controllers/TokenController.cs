using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecAndIdentity.DTOs.Requests;
using SecAndIdentity.Interfaces.Services;
using SecAndIdentity.Models;

namespace SecAndIdentity.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class TokenController(ITokenService tokenService,UserManager<AppUser> userManager,SignInManager<AppUser> signInManager) : ControllerBase
{
    [HttpPost("generate")]
    [Authorize]
    public async Task<IActionResult> IssueToken(LoginRequest request)
    {
        
        var user =await userManager.Users.FirstOrDefaultAsync(u => u.Email==request.Email);

        var signInResult=await signInManager.CheckPasswordSignInAsync(user,request.Password,false);
        if(!signInResult.Succeeded)
            return BadRequest("wrong credentials, couldn't generate token ");

        var token = await tokenService.CreateToken(user);
        return Ok(token);
    }
}