using Shared;

namespace ServicesAbstraction;

public interface IAuthnticationServices
{
    public Task<UserResultDto> Login(LoginDto dto);
    public Task<UserResultDto> Register(RegisterDto dto);
}