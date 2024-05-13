using SuperheroDirectory.API.Extensions;
using SuperheroDirectory.Application.Extensions;
using SuperheroDirectory.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices();

var app = builder.Build();

app.UseApiServices();

app.Run();