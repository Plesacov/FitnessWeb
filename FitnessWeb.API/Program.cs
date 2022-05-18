using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Identity;
using FitnessWeb.API.MapperProfiles;
using FitnessWeb.API.QueryHandlers;
using FitnessWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


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

builder.Services.AddJwtAuthentication();

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

app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

