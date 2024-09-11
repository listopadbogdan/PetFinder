using PetFinder.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Configure().Build();

app.Configure().Run();
