using BlazorWebClient.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(cfg => {
    cfg.RootDirectory = "/";
});
builder.Services.AddServerSideBlazor();
builder.Services.AddViewModels();
builder.Services.AddServices();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints => { 
    endpoints.MapBlazorHub();
    endpoints.MapRazorPages();
});

app.Run();
