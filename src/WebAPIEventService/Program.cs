using Microsoft.EntityFrameworkCore;
using WebAPIEventService.Infra.Data.Context;
using WebAPIEventService.Infra.Data.Repository;
using WebAPIEventService.Infra.Data.Repository.Interfaces;
using WebAPIEventService.Infra.Data.UnitOfWork;
using WebAPIEventService.Infra.Tools;
using WebAPIEventService.Service.Interfaces;
using WebAPIEventService.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<EventContext>(options =>
{
    var configuration = builder.Configuration;
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IAnfitriaoRepository, AnfitriaoRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IInscricaoRepository, InscricaoRepository>();


builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IAnfitriaoService, AnfitriaoService>();
builder.Services.AddScoped<IInscricaoService, InscricaoService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                   options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
               });

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
