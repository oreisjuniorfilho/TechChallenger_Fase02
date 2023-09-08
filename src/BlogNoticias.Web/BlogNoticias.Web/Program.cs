using BlogNoticias.Web.Services;

var builder = WebApplication.CreateBuilder(args);

string apiBaseAddress = builder.Configuration["ApiUrl"];

builder.Services.AddHttpClient<INoticiaService, NoticiaService>(client =>
{
    client.BaseAddress = new Uri(apiBaseAddress);
});

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllersWithViews();

//var app = builder.Build();
WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
 
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Noticia}/{action=Index}/{id?}");

app.Run();
