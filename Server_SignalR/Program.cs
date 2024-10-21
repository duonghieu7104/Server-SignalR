using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ SignalR vào container
builder.Services.AddSignalR();

var app = builder.Build();

// Cấu hình pipeline HTTP
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<QueryHub>("/queryHub");
    endpoints.MapGet("/", () => "Hello World!");
});

// Chạy ứng dụng trên cổng 7161
app.Run("http://localhost:7161");
