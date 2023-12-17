var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "OK");

app.MapPost("/geodata", async (input input) =>
{
    geoData g = new geoData();
    var resultado = g.buscar(input);

    return Results.Created($"/geodata/", resultado);
});


app.Run();
