
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Talabat.APIs.Controllers.Errors;
using Talabat.APIs.Extensions;
using Talabat.APIs.Middlewares;
using Talabat.Application;
using Talabat.Domain.Contracts;
using Talabat.Domain.Contracts.Persitstence.DbInitializer;
using Talabat.Infrastructure;
using Talabat.Infrastructure.Persistence;
using Talabat.Infrastructure.Persistence._Common;
using Talabat.Infrastructure.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Talabat.Domain.Identity;
using Talabat.Infrastructure.Persistence.Identity;
using static Talabat.APIs.Controllers.Errors.ApiValidationErrorResponse;
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
            // Register Identity services here (host project) so AddIdentity extension methods are available
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<StoreIdentityDbContext>()
            .AddDefaultTokenProviders();
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
