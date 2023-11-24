using URLshortener.Entities;
using URLshortener.Models.DTOs;

namespace UrlShorterer.Services.Interfaces
{
    public interface IUserService
    {
        void Create(UserForCreationDto dto);
        User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}