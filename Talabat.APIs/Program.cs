
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Extensions;
using Talabat.Domain.Contracts;
using Talabat.Infrastructure.Persistence;
using Talabat.Application;
using Talabat.Infrastructure.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;
using static Talabat.APIs.Controllers.Errors.ApiValidationErrorResponse;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Controllers.Errors;
using Talabat.APIs.Middlewares;
using Talabat.Infrastructure;
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
                .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly)
                .ConfigureApiBehaviorOptions(options =>
                { 
                    options.SuppressModelStateInvalidFilter = false;
                    options.InvalidModelStateResponseFactory = actionCotext =>
                    {
                        var errors = actionCotext.ModelState.Where(e => e.Value?.Errors.Count > 0)
                        .Select(e => new ValidationError
                        {
                            Field = e.Key,
                            FieldErrors = e.Value!.Errors.Select(x => x.ErrorMessage)
                        } );

                        return new BadRequestObjectResult(new ApiValidationErrorResponse
                        {
                            Errors = errors 
                        }
                        );
                    };
                })
                ;
                 
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //DependencyInjection.AddPersistenceServices(builder.Services, builder.Configuration); // Calling the extension Method
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddInfrastructureServices(builder.Configuration);
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            //builder.Services.AddApplicationServices(builder.Configuration);




            #endregion

            var app = builder.Build();

            #region Databases Initializer

           await app.InitializerStoreContextAsync();
            

            #endregion

            #region Configure Kestrel Middlewares

            app.UseMiddleware<ExceptionHandelerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseStatusCodePagesWithReExecute("/Errors/Code");

            app.UseAuthorization();


            app.MapControllers(); 

            #endregion

            app.Run();
        }
    }
}
