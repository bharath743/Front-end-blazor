using FrondEnd.Shared.DTOs;
using FrondEnd.Shared.Models;

namespace FrontEnd.Api.Services.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticate users
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns><see cref="Response{T}"/> T is the token.</returns>
        Task<Response<string>> AuthenticateAsync(string username, string password);

        /// <summary>
        /// Register new users
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns><see cref="Response{T}"/> T Is The registered user.</returns>
        Task<Response<UserDTO>> RegisterAsync(UserDTO userDTO);
    }
}
