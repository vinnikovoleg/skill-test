using Business;
using Business.Mapping;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Web;
using Web.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

builder.Services.AddAutoMapper(c =>
{
    c.AddProfile(new BusinessProfile());
    c.AddProfile(new WebProfile());
});
builder.Services.RegisterDataAccess(builder.Configuration);
builder.Services.RegisterBusiness();
builder.Services.RegisterWeb();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DataContext>();
db.Database.EnsureCreated();
db.Database.Migrate();