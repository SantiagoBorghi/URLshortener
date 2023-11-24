using URLshortener.Entities;
using URLshortener.Data;
using URLshortener.Models.DTOs;
using UrlShorterer.Services.Interfaces;

namespace Url_Shortener.Services.Implementations
{
    public class UserService : IUserService
    {
        private UrlShortenerContext _context;
        public UserService(UrlShortenerContext context)
        {
            _context = context;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

        public void Create(UserForCreationDto dto)
        {
            User newUser = new User()
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
