using APICQRS.Data;
using APICQRS.Services;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//habilitando servicio CORS
var MyAllowSpecificOrigins = "_ApiCQRS";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                "http://127.0.0.1:5500"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        }
    );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//servicios de conexion a base de datos
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection")
);

//agregando servicio mediator para implemetar CQRS
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//agregando FluentValidator
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

//obteniendo base Uri para paginacion
builder.Services.AddSingleton<IUriService>(
    i => {
        var accessor = i.GetRequiredService<IHttpContextAccessor>();
        var request = accessor.HttpContext.Request;
        var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
        return new UriServices(uri);
    }
);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//agregamos el routing
app.UseRouting();

//usando servicio CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
