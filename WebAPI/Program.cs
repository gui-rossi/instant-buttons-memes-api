using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using WebAPI.Configs;

var builder = WebApplication.CreateBuilder(args);
//dotnet ef database update --project C:\Users\guilh\Dev\botoes-memes-api\Repositories  --startup-project C:\Users\guilh\Dev\botoes-memes-api\WebAPI
RepositoriesInjector.AddRepositories(builder.Services);
ServicesInjector.AddServices(builder.Services);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
