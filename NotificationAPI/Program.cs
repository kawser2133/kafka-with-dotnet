using NotificationAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Register KafkaProducer as Singleton
builder.Services.AddSingleton<KafkaProducer>(sp =>
{
    var producer = new KafkaProducer(builder.Configuration);
    // Create topic on startup
    producer.CreateTopicIfNotExists().GetAwaiter().GetResult();
    return producer;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

