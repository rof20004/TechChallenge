using TechChallenge_Fiap_Soat4.Data;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace TechChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //add connection from mysql
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                                              new MySqlServerVersion(new Version(8,0)),
                                              mySqlOptions =>
                                              {
                                                  mySqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                                              }));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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