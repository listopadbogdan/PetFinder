using PetFinder.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configure();

var app = builder.Build();
app.Configure().Run();
