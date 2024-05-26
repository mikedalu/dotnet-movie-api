var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Add your React app URL here
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddHttpClient<OmdbApiClient>();

var app = builder.Build();



// Configure the HTTP request pipeline.
// Enable CORS
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
