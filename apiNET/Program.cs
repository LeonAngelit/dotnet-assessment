using apiNET.Services;
using apiNET;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TareasContext>(
    dbContextOptions =>
        dbContextOptions.UseMySql(
            "Server=localhost;Database=DotNetCoreMySql;User=root;Password=;",
            ServerVersion.AutoDetect(
                "Server=localhost;Database=DotNetCoreMySql;User=root;Password=;"
            )
        )
);

//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

//Otro mecanismo de inyección de dependencias
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddleWare();

app.MapControllers();

app.Run();
