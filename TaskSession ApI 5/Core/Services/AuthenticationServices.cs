using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServicesAbstraction;
using Shared;

namespace Services;

public class AuthenticationServices(UserManager<User> _userManager,IOptions<JwtOptions> jwtOptions): IAuthnticationServices
{
    public async Task<UserResultDto> Login(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null) throw new UnAuthenticationException();
        var userPassword= await _userManager.CheckPasswordAsync(user, dto.Password);
        if(!userPassword) throw new UnAuthenticationException();
        return new UserResultDto(user.DisplayName, await CreateTokenAsync(user),user.Email);
    }

    public async Task<UserResultDto> Register(RegisterDto dto)
    {
        var user = new User()
        {
            DisplayName = dto.DisplayName,
            Email = dto.Email,
            UserName = dto.Username,
            PhoneNumber = dto.PhoneNumber
        };
        var result =await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            throw new ValidationException(errors);
        }
        return new UserResultDto(user.DisplayName, await CreateTokenAsync(user),user.Email);
    }

    private async Task<string> CreateTokenAsync(User user)
    {
        var JwtOptions = jwtOptions.Value;
        var clamis = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.DisplayName),
            new Claim(ClaimTypes.Email, user.Email)
        };
        var roles=await _userManager.GetRolesAsync(user);
        foreach (var role in roles) clamis.Add(new Claim(ClaimTypes.Role,role));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.secretKey));
        var siginCreds= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer:JwtOptions.issuer,
            audience:JwtOptions.audience,claims:clamis,notBefore:null,expires:DateTime.UtcNow.AddDays(JwtOptions.expirationInDays),siginCreds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}