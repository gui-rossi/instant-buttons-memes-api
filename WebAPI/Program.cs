using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
//dotnet ef database update --project C:\Users\guilh\Dev\botoes-memes-api\Repositories  --startup-project C:\Users\guilh\Dev\botoes-memes-api\WebAPI
RepositoriesInjector.AddRepositories(builder.Services);
ServicesInjector.AddServices(builder.Services);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
