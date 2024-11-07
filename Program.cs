using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Mapping;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StackOverflowDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectstring")));
builder.Services.AddScoped<IAnswerRepository, SQLAnswerRepository>();
builder.Services.AddScoped<ICommentRepository, SQLCommentRepository>();
builder.Services.AddScoped<IPostRepository, SQLPostRepository>();
builder.Services.AddScoped<IRoleRepository, SQLRoleRepository>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
