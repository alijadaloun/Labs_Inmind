using Lab1;
using Lab1.Exceptions;
using Lab1.Filters;
using Lab1.Mappings;
using Lab1.Models;
using Lab1.Models.UniversityModels;
using Lab1.Services;
using Lab1.Services.UniversityServices;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
// Add services to the container.
builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Host=localhost;Port=5432;Database=university_schema;Username=ALIJAD;Password=alijad")));

builder.Services.AddDbContext<LibrarydbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Host=localhost;Port=5432;Database=librarydb;Username=ALIJAD;Password=alijad")));
builder.Services.AddAutoMapper(typeof(StudentProfile));
builder.Services.AddAutoMapper(typeof(TeacherProfile));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<LoggingActionFilter>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<ClassService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<TeacherService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Book>("Books");
modelBuilder.EntitySet<Author>("Authors");
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
        .AddRouteComponents(
            routePrefix: "odata",
            model: modelBuilder.GetEdmModel())
);
    
var app = builder.Build();

// Configure the HTTP request pipeline.




app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}// this caused error when it runs before UseExceptionHandler
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
// app.UseMiddleware<RequestLoggingMiddleware>();
app.UseCors("AllowAll");
app.UseRouting();
app.MapControllers();
app.Run();