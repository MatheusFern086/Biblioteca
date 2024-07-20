using Biblioteca.Models.Contexts;
using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Contracts.Services;
using Biblioteca.Models.Repositories;
using Biblioteca.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();

ConfigureDataSource(builder);

void ConfigureDataSource(WebApplicationBuilder services)
{
    var configuration = builder.Configuration;
    var datasource = configuration["DataSource"];
    switch (datasource)
    {
        case "Local":
                builder.Services.AddSingleton<IContextData, ContextDataFake>();
            break;
        case "SqlServer":
                builder.Services.AddSingleton<IContextData, ContextDataSqlServer>();
                builder.Services.AddSingleton<IConnectionManager, ConnectionManager>();
            break;
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
