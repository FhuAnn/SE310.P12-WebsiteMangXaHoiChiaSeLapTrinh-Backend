using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NZWalk.API.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.CustomIdentityValidator;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Mapping;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Services;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Services.Implement;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
/*builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Cấu hình JsonSerializerOptions để bỏ qua các trường null và các danh sách rỗng
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    });*/
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stackoverflow API", Version = "v1" }); 

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put Bearer + your token in the box below",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            jwtSecurityScheme, Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<StackOverflowDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectstring")));
builder.Services.AddScoped<IAnswerRepository, SQLAnswerRepository>();
builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
builder.Services.AddScoped<IUserRoleRepository, SQLUserRoleRepository>();
builder.Services.AddScoped<IPostRepository, SQLPostRepository>();
builder.Services.AddScoped<ICommentRepository, SQLCommentRepository>();
builder.Services.AddScoped<IRoleRepository, SQLRoleRepository>();
builder.Services.AddScoped<ITagRepository, SQLTagRepository>();
builder.Services.AddScoped<IWatchedTagRepository, SQLWatchedTagRepository>();
builder.Services.AddScoped<IIgnoreTagRepository, SQLIgnoredTagRepository>();
builder.Services.AddScoped<IImageRepository, LocalImageRepositiory>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPosttagRepository, SQLPosttagRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped(typeof(IStackOverflowRepository<>),typeof(StackOverflowRepository<>));

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options
    => options.TokenValidationParameters =
    new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey =
        new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    }
 );


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true"));
}

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

app.UseAuthorization();

app.MapControllers();

app.Run();
