using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nugatory.Models;

// Connection info stored in appsettings.json
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register the DataContext service
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(configuration["ConnectionStrings:DefaultSQLiteConnection"]));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Open",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Nugatory", 
        Version = "v1",
        Description = "A totally useless API",
        });
    c.EnableAnnotations();
    c.TagActionsBy(api => new[] { api.HttpMethod });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseCors("Open");

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
