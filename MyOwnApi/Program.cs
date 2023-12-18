using MyOwnApi.DAL;
using MyOwnAPI.Application.Handlers;
using MyOwnAPI.Application.Queries;
using MyOwnAPI.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IReadDbContext, MyApiDbContext>();
builder.Services.AddScoped<IWriteDbContext, MyApiDbContext>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(ReadAllDriversQuery).Assembly));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(ReadAllDriversHandler).Assembly));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
