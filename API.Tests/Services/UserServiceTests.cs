using API.Services;
using Xunit;

namespace API.Tests.Services;

public class UserServiceTests
{
    private UserService _sut;

    public UserServiceTests()
    {
        _sut = new UserService();
    }
    
    [Fact]
    public async Task GetUserAsync_ShouldBeSuccess()
    {
        var response = await _sut.GetUsersAsync();
        
        Assert.NotNull(response);
    }
}