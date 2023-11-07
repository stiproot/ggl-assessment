var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCoreServices();

var app = builder.Build();

app.MapEndpoints();

app.Run();
