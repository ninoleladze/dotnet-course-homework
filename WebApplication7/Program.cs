using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.Services.Movies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Register DataContext
builder.Services.AddDbContext<DataContext>(o
    => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Register services 
builder.Services.AddScoped<IMovieServices, MovieServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
