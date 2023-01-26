using Mail.Context;
using Mail.Context.IContext;
using Mail.Repository;
using Mail.Repository.IRepository;
using Mail.Service;
using Mail.Service.IService;
using Mail.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddDbContext<Task6Context>(options => options.UseSqlServer("Data Source=SQL8002.site4now.net;Initial Catalog=db_a935ed_task6;User Id=db_a935ed_task6_admin;Password=4704egor"));//Server=(localdb)\\mssqllocaldb;Database=task6;Trusted_Connection=True;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITask6Context, Task6Context>();

builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMessageService, MessageService>();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chat");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
