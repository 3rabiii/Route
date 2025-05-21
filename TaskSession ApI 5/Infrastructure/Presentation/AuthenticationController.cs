using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction;
using Shared;

namespace Presentation;
[ApiController]
[Route("/api/[controller]")]
public class AuthenticationController(IServiceMangger serviceMangger) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<ActionResult<UserResultDto>> Login(LoginDto dto)
    {
        var result = await serviceMangger.AuthnticationServices.Login(dto);
        return Ok(result);
    }
    [HttpPost("Register")]
    public async Task<ActionResult<UserResultDto>> Register(RegisterDto dto)
    {
        var result = await serviceMangger.AuthnticationServices.Register(dto);
        return Ok(result);
    }
}