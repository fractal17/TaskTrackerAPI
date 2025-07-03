using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(UserRegisterDto dto);
    Task<AuthResponseDto> LoginAsync(UserLoginDto dto);
}
