var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCoreServices(configuration);
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
    });

var app = builder.Build();

app
    .MapAuthEndpoints()
    .MapHealthEndpoints()
    .MapFileEndpoints()
    .MapLstEndpoints();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
// app.UseSwaggerUI(c =>
// {
//     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ggl.Slst.Api");
// });

app.Run();
