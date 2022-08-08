using BLL.Entities;
using BLL.Finders;
using BLL.Repositories;
using BLL.Services;
using BLL.Services.Interfaces;
using BLL.UnitOfWork;
using DAL;
using DAL.Finders;
using DAL.Repositories;
using DAL.UnitOfWork;
using IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;
using Test.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddEnvironmentVariables();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors();

var signinkey = new RsaSecurityKey(RSA.Create());
var signingCredentials = new SigningCredentials(signinkey,
    SecurityAlgorithms.RsaSha256);

builder.Services.AddDbContext<TestContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddScoped<DbSet<Event>>(provider => provider.GetRequiredService<TestContext>().Events);
builder.Services.AddScoped<IRepository<Event>, Repository<Event>>();
builder.Services.AddScoped<IEventFinder, EventFinder>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<DbSet<Place>>(provider => provider.GetRequiredService<TestContext>().Places);
builder.Services.AddScoped<IRepository<Place>, Repository<Place>>();
builder.Services.AddScoped<IPlaceFinder, PlaceFinder>();
builder.Services.AddScoped<IPlaceService, PlaceService>();

builder.Services.AddScoped<DbSet<Person>>(provider => provider.GetRequiredService<TestContext>().Persons);
builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
builder.Services.AddScoped<IPersonFinder, PersonFinder>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<DbSet<Organizer>>(provider => provider.GetRequiredService<TestContext>().Organizers);
builder.Services.AddScoped<IRepository<Organizer>, Repository<Organizer>>();
builder.Services.AddScoped<IOrganizerFinder, OrganizerFinder>();
builder.Services.AddScoped<IOrganizerService, OrganizerService>();

builder.Services.AddScoped<DbSet<Speaker>>(provider => provider.GetRequiredService<TestContext>().Speakers);
builder.Services.AddScoped<IRepository<Speaker>, Repository<Speaker>>();
builder.Services.AddScoped<ISpeakerFinder, SpeakerFinder>();
builder.Services.AddScoped<ISpeakerService, SpeakerService>();

builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(SpeakerProfile), typeof(EventProfile), typeof(PlaceProfile), typeof(OrganizerProfile), typeof(PersonProfile));

builder.Services.AddIdentityServer()

    .AddInMemoryClients(IdentityConfiguration.Clients)
    .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddTestUsers(IdentityConfiguration.TestUsers)
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication()
 .AddJwtBearer(jwt =>
 {
     jwt.Authority = "http://localhost:5188";
     jwt.RequireHttpsMetadata = false;
     jwt.Audience = "myApi";
 });

builder.Services.AddControllersWithViews();
#region swagger
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Token Authentication API",
        Description = "ASP.NET Core 5.0 Web API"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
});
# endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    IdentityModelEventSource.ShowPII = true;
}
app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();