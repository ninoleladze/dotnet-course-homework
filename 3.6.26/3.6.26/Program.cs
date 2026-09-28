using _3._6._26.Data;
using _3._6._26.Services.Courses;
using _3._6._26.Services.StudentCourses;
using _3._6._26.Services.Students;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(o
    => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped<IStudentCoursesService, StudentCoursesService>();

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
