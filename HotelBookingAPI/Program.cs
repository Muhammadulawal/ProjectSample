using HotelBookingAPI.Connection;
using HotelBookingAPI.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddTransient<SqlConnectionFactory>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoomTypeRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<AmenityRepository>();
builder.Services.AddScoped<RoomAmenityRepository>();
builder.Services.AddScoped<HotelSearchRepository>();
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<CancellationRepository>();

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
