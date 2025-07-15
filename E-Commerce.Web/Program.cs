
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Services;
using Services.MappingProfiles;
using ServicesAbstraction;

namespace E_Commerce.Web
{     // V03 - AL
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options=>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork,IUnitOfWork>();
            //builder.Services.AddAutoMapper(x => x.AddProfile(new ProductProfile()));
            builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            builder.Services.AddScoped<IServiceManager, ServiceManager>();


            #endregion

            //------------------------  Build ----------------------
            var app = builder.Build();

            #region Data Seed

            using var Scope = app.Services.CreateScope();
            var ObjectOfDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            ObjectOfDataSeeding.DataSeedAsync();

            #endregion

            #region Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
