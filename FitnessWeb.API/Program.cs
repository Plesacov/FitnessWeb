using Fitness.Infrastracture;
using FitnessWeb.API.Identity;
using FitnessWeb.API.MapperProfiles;
using FitnessWeb.API.QueryHandlers;
using FitnessWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://example.com",
                                "http://www.contoso.com");
        });
});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(FitnessMapperProfile).Assembly);
builder.Services.AddMediatR(typeof(FitnessProgramQueryHandler).Assembly);
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddIdentity<Person, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
})
.AddEntityFrameworkStores<FitnessContext>()
.AddDefaultTokenProviders();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // укзывает, будет ли валидироваться издатель при валидации токена
        ValidateIssuer = true,
        // строка, представляющая издателя
        ValidIssuer = AuthOptions.ISSUER,

        // будет ли валидироваться потребитель токена
        ValidateAudience = true,
        // установка потребителя токена
        ValidAudience = AuthOptions.AUDIENCE,
        // будет ли валидироваться время существования
        ValidateLifetime = true,

        // установка ключа безопасности
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        // валидация ключа безопасности
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddScoped<JwtHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FitnessContext>(optionBuilder =>
{
    optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

