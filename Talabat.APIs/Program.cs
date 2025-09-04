
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Extensions;
using Talabat.Domain.Contracts;
using Talabat.Infrastructure.Persistence;
using Talabat.Application;
using Talabat.Infrastructure.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services
            // Add services to the container.

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //DependencyInjection.AddPersistenceServices(builder.Services, builder.Configuration); // Calling the extension Method
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //builder.Services.AddApplicationServices(builder.Configuration);




            #endregion

            var app = builder.Build();

            #region Databases Initializer

            app.InitializerStoreContextAsync();
            

            #endregion

            #region Configure Kestrel Middlewares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers(); 

            #endregion

            app.Run();
        }
    }
}
