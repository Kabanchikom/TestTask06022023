using TestTask06022023.Cors;
using TestTask06022023.IcuTech;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddIcuTech();

var app = builder.Build();

app.UseCors(CorsSetupExtensions.FrontEnd);

app.MapPost("/api/login", async (
    IcuTechService icuTechService,
    string username,
    string password) =>
{
    try
    {
        var response = await icuTechService.Login(username, password);
        return Results.Text(response,  "application/json");
    }
    catch (NullReferenceException e)
    {
        return Results.UnprocessableEntity(e.Message);
    }
    catch (UnauthorizedAccessException e)
    {
        return Results.Unauthorized();
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

app.Run();