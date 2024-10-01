using CQRS.Connection;
using CQRS.CQRS.Command;
using CQRS.CQRS.Handler;
using CQRS.CQRS.Queries;
using CQRS.CQRS.Result;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<GetProductHandler>();
builder.Services.AddScoped<GetProductResult>();
builder.Services.AddScoped<AddProductHandler>();
builder.Services.AddScoped<DeleteProductHandler>();
builder.Services.AddScoped<UpdateProductHandler>();
builder.Services.AddScoped<UpdateProductCommand>();
builder.Services.AddScoped<GetProductByIdHandler>();



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
