using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteTecnicoWK.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace TesteTecnicoWK
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            var mySqlconnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlconnection, ServerVersion.AutoDetect(mySqlconnection)));

            services.AddMvc();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }

    }
}
