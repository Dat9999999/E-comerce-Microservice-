using e_comerce.Infrastructure;
using e_comerce.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddControllers();

var app = builder.Build();


app.UseExceptionHandlingMiddleware();
// routing
app.UseRouting();

// auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();