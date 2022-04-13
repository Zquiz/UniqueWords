using Microsoft.EntityFrameworkCore;
using UniqueWords.Core.Models;
using UniqueWords.Core.Services;
using UniqueWords.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<UniqueWordContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UniqueWords.Database")));
builder.Services.AddTransient<UniqueWordService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/uniquewords", ([Microsoft.AspNetCore.Mvc.FromBody] string text,UniqueWordService uniqueWordService) =>
{
    return uniqueWordService.UniqueCount(text);
});

app.MapPost("/savewatchlistWord", (AddWatchlistWordDTO text, UniqueWordService uniqueWordService) =>
{
    uniqueWordService.AddWatchlistWord(text);
});

app.Run();
