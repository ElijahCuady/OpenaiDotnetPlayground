using src.OpenaiDotnetPlayground.Services;
using src.OpenaiDotnetPlayground.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Configuration>();
builder.Services.AddSingleton<CustomPrinter>();

builder.Services.AddOpenAIServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});



app.Run();
