using Website.Models.Interfaces;
using Website.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//*********************************
builder.Services.AddHttpClient<IHotelBooking, HotelBookingService>(client => client.BaseAddress = new Uri("https://localhost:7167/api"));
builder.Services.AddHttpClient<IHotelReservation, HotelReservationService>(client => client.BaseAddress = new Uri("https://localhost:7167/api"));
builder.Services.AddHttpClient<IHotelRoom, HotelRoomService>(client => client.BaseAddress = new Uri("https://localhost:7167/api"));

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
