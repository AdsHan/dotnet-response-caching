using ResponseCaching.API.Cache.DecoratorPattern;
using ResponseCaching.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCacheDecoratorPatternConfiguration(builder.Configuration);
builder.Services.AddCachePipelineBehaviourConfiguration(builder.Configuration);
//builder.Services.AddCacheResponseCachingConfiguration(builder.Configuration);

builder.Services.AddApiConfiguration();
builder.Services.AddDependencyConfiguration();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration();

//app.UseCacheResponseCachingConfiguration();

app.Run();