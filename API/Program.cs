using API.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IIconService, IconService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEnd", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.MapGet("/api/users", async ([FromServices] IUserService userService) =>
    {
        try
        {
            var users = await userService.GetUsersAsync();
            return Results.Ok(users);
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Error fetching users",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    })
    .Produces<IEnumerable<UserDto>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status500InternalServerError);


app.MapGet("/api/icons/{iconName}", async ([FromServices] IIconService iconService, string iconName) =>
{
    try
    {
        var iconBytes = await iconService.GetIconBytesAsync(iconName);
        return Results.File(
            iconBytes,
            contentType: "image/png"
        );
    }
    catch (Exception ex)
    {
        return Results.Problem(
            title: "Error fetching icon",
            detail: ex.Message,
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
});
app.UseCors("AllowFrontEnd");
app.Run();