using Microsoft.EntityFrameworkCore;
using WebApi2.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionar el contexto de la base de datos
builder.Services.AddDbContext<TasksDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("TasksDbContext")));

// Permitir llamados desde otros origenes
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy => policy.WithOrigins("http://localhost:4200", "http://localhost:8081")
            .AllowAnyHeader()
            .AllowAnyMethod()
        );
});


var app = builder.Build();

// usar cors
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
