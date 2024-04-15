using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true);
        });
    });
builder.Services.AddSignalR();
builder.Services.AddTransient<MyBusiness>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapHub<MyHub>("/myhub"); // Suggested usage

//app.UseEndpoints(endpoints =>
//{
    
//});

app.Run();
