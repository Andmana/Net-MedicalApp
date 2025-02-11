using Med_341A.Middlewares;
using Med_341A.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add all scope services
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddScoped<PasienService>();
builder.Services.AddScoped<DokterProfilService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<ResetPasswordService>();
builder.Services.AddScoped<MenuRoleService>();
builder.Services.AddScoped<MedicalItemService>();
builder.Services.AddScoped<FindDoctorService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromHours(1); // bisa disetting di appsetting
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

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

// add session
app.UseSession();

app.UseRouting();

app.UseAuthorization();

// add middleware session
// app.UseMiddleware<SessionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
