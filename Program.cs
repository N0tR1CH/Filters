using Filters.Services;
using Filters.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AddFolderApplicationModelConvention("/Pages", model => model.Filters.Add(new CustomPageFilter(new GeoService())));
    });

builder.Services.AddTransient<BrowserRedirectMiddleware>();

// Add services to the mvc
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new CustomPageFilter(new GeoService()));
});

builder.Services.AddTransient<IGeoService, GeoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<BrowserRedirectMiddleware>();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
