using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using P.A_API.JWT;
using P.A_Contract.EndPoint.ExceptionHandler;
using P.A_Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ServiceInit();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDataContext>(option =>
{
    option.UseSqlServer(builder.Configuration["ConnectionStrings:PADatabase"]);
});
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 4;
        options.Window = TimeSpan.FromSeconds(12);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRateLimiter();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseApiCustomExceptionHandler();

app.MapControllers();

app.Run();
