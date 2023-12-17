var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/geo/", () => {

geo g = new geo();

return g.buscar(-10,-20);
});

app.Run();
