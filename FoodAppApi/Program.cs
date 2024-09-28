using FoodAppApi.Profiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FoodAppApi.Helpers;
using Autofac.Extensions.DependencyInjection;
using Autofac;

namespace FoodAppApi
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

            #region AutoMapper 
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            #endregion


            #region AutoFac
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            builder.RegisterModule(new AutoFacModule()));

            #endregion

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           MapperHelper.Mapper= app.Services.GetService<IMapper>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
