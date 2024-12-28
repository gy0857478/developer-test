using System.Text.Json;

namespace API.Services;

public class UserService : IUserService
{
    private readonly string _userJsonPath;

    public UserService()
    {
        _userJsonPath = Path.Combine(Environment.CurrentDirectory, "Data", "Users");
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        List<UserDto> users = new List<UserDto>();

        var files = Directory.GetFiles(_userJsonPath, "*.json");


        foreach (var file in files)
        {
            var jsonContent = await File.ReadAllTextAsync(file);

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var user = JsonSerializer.Deserialize<User>(jsonContent, options);

            if (user != null)
            {
                var iconPath =
                    string.IsNullOrEmpty(user.IconName) ? "unknown" : user.IconName;
                var userDto = new UserDto
                (
                    user.Name,
                    user.Age,
                    user.Registered,
                    user.Email,
                    user.Balance,
                    iconPath
                );

                users.Add(userDto);
            }
        }

        return users;
    }
}