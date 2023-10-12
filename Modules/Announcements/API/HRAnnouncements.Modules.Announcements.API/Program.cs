using HRAnnouncements.Modules.Announcements.Application.Mapping;
using HRAnnouncements.Modules.Announcements.Application.Queries.Implementations;
using HRAnnouncements.Modules.Announcements.Application.Seeders;
using HRAnnouncements.Modules.Announcements.Domain.Repositories;
using HRAnnouncements.Modules.Announcements.Persistence;
using HRAnnouncements.Modules.Announcements.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register DbContext with DI container and configure it to use PostgreSQL.
builder.Services.AddDbContext<HRAnnouncementsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR and specify the assembly containing MediatR handlers and requests.
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<GetAnnouncementsQuery>());

// Register AutoMapper and specify the assembly containing AutoMapper profiles.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register custom services and repositories for Dependency Injection.
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<AnnouncementSeeder>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register and configure CORS (Cross-Origin Resource Sharing) services.
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request middleware pipeline.
if (app.Environment.IsDevelopment())
{
    // In development mode, seed the database using the seeder service.
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<AnnouncementSeeder>();
        seeder.Seed();
    }

    // Configure CORS for development to allow requests from specified origins.
    app.UseCors(builder =>
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader());

    // Use Swagger and Swagger UI for API documentation in development.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
