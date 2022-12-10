using ANCASE.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddIoCConfiguration(builder.Configuration);

var app = builder.Build();
app.UseSwagger(app.Environment);
app.UseApiConfiguration();
app.UseControllersConfiguration();

app.Run();
