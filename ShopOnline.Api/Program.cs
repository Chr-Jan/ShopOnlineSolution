global using Microsoft.EntityFrameworkCore;
global using ShopOnline.Api.Entities;
global using ShopOnline.Api.Data;
global using ShopOnline.Api.Repositories.Contacts;
global using ShowOnline.Models.Dtos;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using ShopOnline.Api.Extensions;
global using System.Collections;
global using ShopOnline.Api.Repositories;

namespace ShopOnline.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContextPool<ShopOnlineDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
        }
    }
}