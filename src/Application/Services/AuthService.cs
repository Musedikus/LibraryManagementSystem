using Application.Common.Models;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public AuthService(IRepository<User> userRepo, IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<ResultModel<AuthResponse>> RegisterAsync(RegisterRequest request)
        {
            var exists = await _userRepo.AnyAsync(u => u.EmailAddress == request.EmailAddress);
            if (exists)
                return ResultModel<AuthResponse>.Failure("Email already registered.");

            var hashed = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                EmailAddress = request.EmailAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,    
                PasswordHash = hashed,
                TokenVersion = Guid.NewGuid().ToString()
            };

            await _userRepo.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var token = _jwtService.GenerateToken(user);

            return ResultModel<AuthResponse>.SuccessResponse(new AuthResponse
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                EmailAddress = user.EmailAddress
            });
        }

        public async Task<ResultModel<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _userRepo.GetAll().Where(u => u.EmailAddress == request.EmailAddress).FirstOrDefaultAsync();
            if (user == null)
                return ResultModel<AuthResponse>.Failure("Invalid email or password.");

            var valid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!valid)
                return ResultModel<AuthResponse>.Failure("Invalid email or password.");

            user.TokenVersion = Guid.NewGuid().ToString(); // Invalidate old tokens
            _userRepo.Update(user);
            await _unitOfWork.SaveChangesAsync();

            var token = _jwtService.GenerateToken(user);

            return ResultModel<AuthResponse>.SuccessResponse(new AuthResponse
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                EmailAddress = user.EmailAddress    
            });
        }

        public async Task<ResultModel<string>> LogoutAsync(int userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                return ResultModel<string>.Failure("User not found.");

            user.TokenVersion = Guid.NewGuid().ToString(); // Invalidate old tokens
            _userRepo.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return ResultModel<string>.SuccessResponse("Logged out.");
        }
    }

}
