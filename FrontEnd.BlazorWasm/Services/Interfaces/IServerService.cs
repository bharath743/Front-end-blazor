using FrondEnd.Shared.DTOs;
using FrondEnd.Shared.Models;

namespace FrontEnd.BlazorWasm.Services.Interfaces
{
    public interface IServerService
    {
        /// <summary>
        /// Used to log into the app
        /// </summary>
        /// <param name="user"></param>
        /// <returns><see cref="Response{T}"/> The response obj</returns>
        Task<Response<string>> AuthenticateAsync(UserDTO user);

        /// <summary>
        /// Load list of products from the server.
        /// </summary>
        /// <param name="token">The auth token</param>
        /// <returns><see cref="Response{T}"/> T is a <seealso cref="IReadOnlyList{T}"/> of <seealso cref="Products"/></returns>
        Task<Response<IReadOnlyList<Products>>> GetProductsAsync(string token);

        /// <summary>
        /// Get the specific product details
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response<Products>> GetProductsDetailsAsync(string token, string id);
    }
}
