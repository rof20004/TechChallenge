using Microsoft.EntityFrameworkCore;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Interfaces.Services;
using TechChallenge.Domain.Interfaces.Infra;
using TechChallenge.Infra.Repositories;
using TechChallenge.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TechChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //add connection from mysql
            builder.Services.AddDbContext<ApiDbContext>(options =>
                           options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                                              new MySqlServerVersion(new Version(8, 0)),
                                              mySqlOptions =>
                                              {
                                                  mySqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                                              }));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "TechChallengerIssuer",
                    ValidAudience = "TechChallengerAudience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("privateKeyTechChallenger Grupo 4SOAT")),
                    ClockSkew = TimeSpan.Zero
                };
            }
            
            );

            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            // migrate any database changes on startup (includes initial db creation)
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
                dataContext.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}