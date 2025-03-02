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
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://your-keycloak-domain/auth/realms/myrealm";
        options.Audience = "myclient";
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
    options.AddPolicy("StudentOnly", policy => policy.RequireRole("student"));
    options.AddPolicy("TeacherOnly", policy => policy.RequireRole("teacher"));
});
builder.Services.AddControllers();
builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration["AzureBlobStorage:ConnectionString"]));
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
builder.Services.AddScoped<IAdminService, AdminService>();
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
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();