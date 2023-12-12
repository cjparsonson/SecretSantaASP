using SecretSanta.EntityModels;
#region Configure the web server host and services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSecretSantaContext();
var app = builder.Build();
#endregion

#region Configure the HTTP pipeline and routes
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();
app.MapGet("/hello", () => 
    $"Environment is {app.Environment.EnvironmentName}");
#endregion
// Start web server
app.Run();

WriteLine("Executes after the web server has stopped.");
