using Application.Common.Models;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<ResultModel<AuthResponse>> RegisterAsync(RegisterRequest request);
        Task<ResultModel<AuthResponse>> LoginAsync(LoginRequest request);
        Task<ResultModel<string>> LogoutAsync(int userId);
    }
}
