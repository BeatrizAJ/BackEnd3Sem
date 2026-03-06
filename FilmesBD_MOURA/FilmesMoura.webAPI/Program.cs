

using FilmesMoura.webAPI.BdContextFilme;
using FilmesMoura.webAPI.Interfaces;
using FilmesMoura.webAPI.repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//ADD serv de jwt bearer (froma de autent)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBaerer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new
        Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            //valida qm esta solicitand0
            ValidateIssuer = true,

            //valida qm esta recebendo o token
            ValidateAudience = true,

            //define se o tempo de exp sera validado
            ValidateLifetime = true,

            //forma de criptografia q valida a chave de autent
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            //valida o tempo de expiracao do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //Nome do issuer (d onde ta vindo)
            ValidIssuer = "api_filmes",

            //nome do audience (p onde esta indo)
            ValidAudience = "api_filmes"
        };

    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "Filmes API",
        Description = "Uma API com um catalogo de filmes",
        TermsOfService = new Uri("https://examplo.com/terms"),
        Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "marcaumdev",
            Url = new Uri("https://example.com/license")
        },
        License = new Microsoft.OpenApi.OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT:",
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {


        builder.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod();

    });
    


});


// adiciona servico de controle
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });

    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;

    });
}

app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();



// adiciona mapemaneto nos controlers
app.MapControllers();
app.Run();   