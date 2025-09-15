using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("localDatabase")));
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<ILocationRoomRepository, LocationRoomRepository>();


var app = builder.Build();


app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
