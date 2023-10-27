
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApplication1.DATA;
using WebApplication1.Services;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       // public class MappingProfile : Profile
       // {
            //public MappingProfile()
            //{
            //    CreateMap<VideoJuego, VideoJuegoDto>()
            //        .ForMember(dto => dto.desarrollador, opt => opt.MapFrom(src => src.desarrollador.nombre));
            //    CreateMap<VideoJuegoDto, VideoJuego>()
            //        .ForMember(dest => dest.desarrollador, opt => opt.Ignore()); // Ignora la propiedad de navegación para evitar problemas de seguimiento de Entity Framework


            //}
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<HeroeDB>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));
           

            // registro el servicio videojuegos para poder inyectarlo en mi videojuego controller
            services.AddScoped<HeroeService>();


            //esto seria para permitir llamadas 
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAllOrigins",
            //    policy => policy
            //        .AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());

            //});


            // Configuración de AutoMapper
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HeroeApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeroeApi v1"));
                // interfaz grafica de swagger: https://localhost:5001/swagger/index.html
            }

            //permitir solicitudds//app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}