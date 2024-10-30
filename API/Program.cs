using API;
using API.Repositories;
using API.Repositories.interfaces;
using API.Services;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Rejestracja repozytoriów
builder.Services.AddScoped<IStudentsServices, StudentsService>();
builder.Services.AddScoped<IGradesServices, GradesService>();

builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IGradeRepository, GradesRepository>();

builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IAttendanceServices, AttendanceServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()   // Pozwala na dostêp z dowolnej domeny
                   .AllowAnyHeader()   // Pozwala na dowolne nag³ówki
                   .AllowAnyMethod();  // Pozwala na dowolne metody HTTP (GET, POST, PUT, DELETE, itd.)
        });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connstring = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseMySql(connstring, ServerVersion.AutoDetect(connstring)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
