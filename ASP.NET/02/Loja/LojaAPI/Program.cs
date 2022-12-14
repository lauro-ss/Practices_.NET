using Core;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service;

namespace LojaAPI
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

            builder.Services.AddDbContext<LojaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("LojaDatabase"))
                );

            builder.Services.AddScoped<ICategoria, CategoriaService>();
            builder.Services.AddScoped<IProduto, ProdutoService>();

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