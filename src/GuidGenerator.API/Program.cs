﻿var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

app.MapGet("/", () =>
{
    return Guid.NewGuid();
});

app.Run();
