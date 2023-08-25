using FRM.Business.Extensions;
using FRM.WebAPI.Extensions;
using FRM.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAPIServices();
builder.Services.AddBusinessServices();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
