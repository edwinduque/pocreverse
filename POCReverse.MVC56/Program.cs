var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSystemWebAdapters()
    .AddJsonSessionSerializer(options =>
    {
        options.RegisterKey<string>("Test");
    })
    .AddRemoteAppClient(options =>
    {
        options.RemoteAppUrl = new("https://localhost:44323");
        options.ApiKey = "24B0E9BE-22D4-4979-9E08-6C2726839885";
    })
    .AddSessionClient();

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
app.UseSystemWebAdapters();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    //.BufferResponseStream()
    //.PreBufferRequestStream()
    .RequireSystemWebAdapterSession();

app.Run();
