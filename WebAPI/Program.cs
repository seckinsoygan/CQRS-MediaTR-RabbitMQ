using CQRS.Abstract_Requests;
using CQRS.Commands.Request;
using CQRS.Commands.Response;
using CQRS.Handlers.CommandHandlers;
using CQRS.Handlers.QueryHandlers;
using CQRS.Queries.Request;
using CQRS.RabbitMQ;
using DataAccess;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CreateProductCommandHandler>();
builder.Services.AddTransient<DeleteProductCommandHandler>();
builder.Services.AddTransient<GetAllProductQueryHandler>();
builder.Services.AddTransient<GetByIdProductQueryHandler>();


builder.Services.AddMvc();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(),
    typeof(CreateProductCommandRequest).Assembly,
    typeof(UpdateProductCommandRequest).Assembly,
    typeof(DeleteProductCommandRequest).Assembly,
    typeof(GetAllProductQueryRequest).Assembly,
    typeof(GetByIdProductQueryRequest).Assembly,
    typeof(ApplicationDbContext).Assembly);


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
