var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCoreServices(configuration);

var app = builder.Build();

app
    .MapAuthEndpoints()
    .MapHealthEndpoints()
    .MapFileEndpoints()
    .MapLstEndpoints();

// TODO: complete app builder configuration...

app.Run();
