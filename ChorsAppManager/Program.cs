using ChorsAppManager.Backend.EntityFramework.Data;
using ChorsAppManager.Backend.Application.ChoresServices;
using ChorsAppManager.Backend.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using ChorsAppManager.Backend.Model;
using ChorsAppManager.Backend.Application.RegistrationUserService;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ChoresAppManagerDbConnectionString");
builder.Services.AddDbContext<ChoresAppManagerDbContext>(options =>
{
    options.UseSqlServer(connectionString);

});
builder.Services.AddIdentity<User, IdentityRole<int>>(opts =>
{
opts.Password.RequiredLength = 5;
opts.Password.RequireNonAlphanumeric = false;
opts.Password.RequireLowercase = true;
opts.Password.RequireUppercase = true;
opts.Password.RequireDigit = true;
opts.User.AllowedUserNameCharacters = null;
}).AddEntityFrameworkStores<ChoresAppManagerDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IChoresService, ChoresService>();
builder.Services.AddScoped<IRepository<Chore>, Repository<Chore>>();
builder.Services.AddScoped<IRegisterService, RegisterService>();

//builder.Services.AddScoped<IChoresService, ChoresService>;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
