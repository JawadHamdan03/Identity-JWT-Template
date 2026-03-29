using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecAndIdentity.Data;
using SecAndIdentity.Models;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using SecAndIdentity.Interfaces.Services;
using SecAndIdentity.Services.Classes;
using Microsoft.AspNetCore.Authorization;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();


builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddIdentity<AppUser,IdentityRole>(options =>
{
    options.Password.RequireDigit=true;
    options.Password.RequireUppercase=true;
    options.Password.RequireLowercase=true;
    options.Password.RequireNonAlphanumeric=true;
    options.Password.RequiredLength=12;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=
    options.DefaultChallengeScheme=
    options.DefaultScheme=
    options.DefaultSignInScheme=
    options.DefaultSignOutScheme=JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters= new TokenValidationParameters
    {
        ValidateIssuer=true,
        ValidIssuer=builder.Configuration["JWT:Issuer"],
        ValidateAudience=true,
        ValidAudience=builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey
            (
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!)
            )

    };
});

builder.Services.AddAuthorization();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.MapGet("/checkAuth",[Authorize(Roles ="User")] () =>
{
    return Results.Ok("all good");
});

app.Run();

