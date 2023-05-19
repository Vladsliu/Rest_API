using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestApi_test.Db;
using System.Text.Json;
using RestApi_test.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddServerSideBlazor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc();
builder.Services.AddScoped<StatisticsService>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExperimentRepository, ExperimentRepository>();
builder.Services.AddSwaggerGen(c =>
{ 
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Experiment API", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Experiment API v1");
    });
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
    endpoints.MapRazorPages();
    endpoints.MapGet("/st", async context =>
    {
            var experimentRepository = context.RequestServices.GetService<IExperimentRepository>();

            var experiments = experimentRepository.GetExperimentData();

            var json = JsonSerializer.Serialize(experiments);

            context.Response.ContentType = "text/json";
            await context.Response.WriteAsync(json);
    });

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
});
