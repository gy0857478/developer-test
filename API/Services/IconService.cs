namespace API.Services;

public class IconService : IIconService
{
    private readonly string _iconPath;

    public IconService()
    {
        _iconPath = Path.Combine(Environment.CurrentDirectory, "Data", "Icons");
    }

    public Task<byte[]?> GetIconBytesAsync(string name)
    {
        var iconPath = Path.Combine(_iconPath, $"{name}.png");
        
        if (!File.Exists(iconPath))
        {
            return File.ReadAllBytesAsync(Path.Combine(_iconPath, $"unknown.png"));
        }

        return File.ReadAllBytesAsync(iconPath);
    }
}