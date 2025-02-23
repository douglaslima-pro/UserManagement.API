using UserManagement.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// custom middlewares for logging and error handling
app.UseLogging();
app.UseErrorHandling();

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
