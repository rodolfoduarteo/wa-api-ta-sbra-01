using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using wa_api_ta_azure_02.Data;
using wa_api_ta_azure_02.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreDataContext>(options => options.UseSqlServer(builder.Configuration["DbStoreConnectionString"]));
builder.Services.AddTransient<NotificationService>();
builder.Services.AddTransient<MessageBusService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Store.Pedidos",
                    Version = "v1"
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseSwagger();
    app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store.Pedidos v1");
            });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
