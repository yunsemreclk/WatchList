using Microsoft.AspNetCore.Identity;
using WatchList.WebUI.DTOs.UserDtos;
using WatchList.WebUI.Models;

namespace WatchList.WebUI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public async Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();

        }

        public async Task<List<UserViewModel>> GetAllUsersAsync()
        {
            return await _client.GetFromJsonAsync<List<UserViewModel>>("roleassigns");
        }

        public async Task<int> GetUserCount()
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AssignRoleDto>> GetUserForRoleAssign(int id)
        {
            return await _client.GetFromJsonAsync<List<AssignRoleDto>>("roleassigns/" + id);
        }
    }
}
