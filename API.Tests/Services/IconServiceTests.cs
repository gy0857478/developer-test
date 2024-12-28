using API.Services;
using Xunit;

namespace API.Tests.Services;

public class IconServiceTests
{
    private IconService _sut;

    public IconServiceTests()
    {
        _sut = new IconService();
    }

    [Fact]
    public async Task GetIconBytesAsync_ShouldBeSuccess()
    {
        var response = await _sut.GetIconBytesAsync("");
        
        Assert.NotNull(response);
    }
}