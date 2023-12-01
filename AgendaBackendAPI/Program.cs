
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AgendaBack2023.Models.Profiles;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AgendaBackendAPI.Data.Repository.Implementations;
using AgendaBackendAPI.Data.Repository.Interfaces;
using AgendaBackendAPI.Data;
using AgendaBack2023.Data.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("AgendaApiBearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Ac� pegar el token generado al loguearse"



    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "AgendaApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });
});

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebapp", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
//add context
builder.Services.AddDbContext<AgendaApiContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"));
});


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"])),

            // Configuraci�n adicional para validar solo el correo electr�nico y la contrase�a
            NameClaimType = "email",  // Especifica el tipo de reclamaci�n para el correo electr�nico
            RoleClaimType = "password",  // Especifica el tipo de reclamaci�n para la contrase�a
        };
    });





// Auto Mapper Configurations
//builder.Services.AddAutoMapper(typeof(Program));

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ContactProfile());
    cfg.AddProfile(new UserProfile());
    cfg.AddProfile(new LocationProfile());
});
var mapper = config.CreateMapper();


#region DependencyInjections
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
