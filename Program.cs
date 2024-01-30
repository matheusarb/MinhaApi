var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//GET
app.MapGet("/", () => {
    return Results.Ok("HelloWorld");
});
app.MapGet("/{nome}", (string nome) => {
    return $"Hello {nome}";
});
app.MapGet("/{nome}/{pedido}", (string nome, string pedido) => {
    return Results.Ok($"Olá {nome}, seu {pedido} está pronto");
});

//POST
app.MapPost("/", () => {

});

app.UseHttpsRedirection();

app.Run();