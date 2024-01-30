var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! I'm here222");
app.MapGet("/usuarios", () => "Estes são os diletos usuários");

app.UseHttpsRedirection();

app.Run();