using PetFinder.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Configure().Build();

await app.ConfigureAsync();
app.Run();