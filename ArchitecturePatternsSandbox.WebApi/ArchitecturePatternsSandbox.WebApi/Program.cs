using ArchitecturePatternsSandbox.WebApi.Extensions;

var CustomOriginsPolicy = "_customOriginsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CustomOriginsPolicy,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                      });
});

builder.Services.AddServicesExtensions(builder.Configuration);
builder.Configuration.AddConfigurationExtensions(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CustomOriginsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
