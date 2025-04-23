using EventDrivenCrudApp.Extensions;
using EventDrivenCrudApp.Handlers;
using EventDrivenCrudApp.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configuration();

var app = builder.Build();

// Get the event bus and repository from DI container to use in event handlers
var bus = app.Services.GetRequiredService<IEventBus>();
var repo = app.Services.GetRequiredService<IProductRepository>();

// Instantiate and subscribe event handlers for product events
_ = new ProductCreatedHandler(bus, repo);  // Handle product creation events
_ = new ProductUpdatedHandler(bus, repo);  // Handle product update events
_ = new ProductDeletedHandler(bus, repo);  // Handle product deletion events

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
