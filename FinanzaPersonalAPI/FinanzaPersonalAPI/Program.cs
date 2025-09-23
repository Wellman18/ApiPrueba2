using FinanzaPersonalAPI.DataAccess;
using FinanzaPersonalAPI.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<FinanzaPersonalAPI.BusinessLogic.Interface.IUsuario, FinanzaPersonalAPI.BusinessLogic.Usuario>();
builder.Services.AddScoped<IConnectionManagerDbContext, ConnectionManagerDbContext>();
builder.Services.AddScoped<FinanzaPersonalAPI.DataAccess.Interface.IUsuario, FinanzaPersonalAPI.DataAccess.Usuario>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConnectionManagerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
