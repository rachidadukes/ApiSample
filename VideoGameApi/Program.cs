using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameApi;
using VideoGameApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri("https://api.restful-api.dev/");
});
// Register IApiService and its implementation
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddDbContext<VideoGameDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "VideoGameApi api"));
    // https://localhost:7244/swagger/index.html
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
