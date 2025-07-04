using System.Text.Json;
using System.Text.Json.Serialization;
using e_comerce.Infrastructure;
using e_comerce.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Enum -> string
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });


var app = builder.Build();


app.UseExceptionHandlingMiddleware();
// routing
app.UseRouting();

// auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();