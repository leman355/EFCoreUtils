using EFCoreUtils.Business.Abstract;
using EFCoreUtils.Business.Concrete;
using EFCoreUtils.Business.Mappers;
using EFCoreUtils.DataAccess;
using EFCoreUtils.DataAccess.Abstract;
using EFCoreUtils.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IMusicianRepository, MusicianRepository>();
builder.Services.AddScoped<IMusicianService, MusicianManager>();

builder.Services.AddScoped<IMusicBandRepository, MusicBandRepository>();
builder.Services.AddScoped<IMusicBandService, MusicBandManager>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


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
