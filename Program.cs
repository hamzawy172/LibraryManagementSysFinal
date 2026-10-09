using System.Numerics;
using LibraryManagementSys.CustomeRepos.BookRepos;
using LibraryManagementSys.CustomeRepos.BorrowingRepos;
using LibraryManagementSys.CustomeRepos.CategoryRepos;
using LibraryManagementSys.CustomeRepos.MemberRepos;
using LibraryManagementSys.Data;
using LibraryManagementSys.Generic;
using LibraryManagementSys.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Conn")
    ));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IBookRepo , BookRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IMemberRepo, MemberRepo>();
builder.Services.AddScoped<IBorrowingRepo, BorrowingRepo>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
