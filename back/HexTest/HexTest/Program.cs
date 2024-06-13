using HexTest.Application;
using HexTest.Endpoints.Shared;
using HexTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication().AddInfrastructure();
builder.Services.AddCors();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .WithOrigins(app.Configuration.GetSection("AllowedOrigins").Get<string[]>()!)
    .AllowCredentials());

app.UseEndPoints<Program>();
app.UseHttpsRedirection();
app.Run();
