using CuallimexManagement.Infrastructure.Interfaces;
using CuallimexManagement.Infrastructure.Services;
using CuallimexManagement.Utils;
using Microsoft.AspNetCore.Http.Features;
using MongoDB.Driver;
using MudBlazor;
using MudBlazor.Services;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddSingleton<IMongoClient>(s =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDBUrl");
    return new MongoClient(connectionString);
});

builder.Services.AddSingleton<IMongoDb>(s =>
{
    var mongoClient = s.GetRequiredService<IMongoClient>();
    var databaseName = builder.Configuration["ConnectionStrings:DatabaseName"];
    return new MongoDbService(mongoClient, databaseName);
});

builder.Services.AddScoped<IReport, ReportService>();
builder.Services.AddScoped<IWorkPdf, WorkPdfService>();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
