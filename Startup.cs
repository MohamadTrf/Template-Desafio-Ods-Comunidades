using Microsoft.OpenApi.Models;
using Template_Desafio_Ods_Comunidades.Data;
using Template_Desafio_Ods_Comunidades.Service;
using Microsoft.EntityFrameworkCore;

namespace Template_Desafio_Ods_Comunidades
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Carregar variáveis de ambiente do arquivo .env na pasta environments
            DotNetEnv.Env.Load("./Environment/.env");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Obter as variáveis de ambiente
              string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
             string dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            string dbName = Environment.GetEnvironmentVariable("DB_NAME");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            // Montar a string de conexão
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";
      
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString,
                b => b.MigrationsAssembly(typeof(Startup).Assembly.FullName)));

            // Registrar OligarquiaService
            services.AddScoped<OligarquiaService>();
            services.AddScoped<IndicadorService>();
            services.AddScoped<SecretariaService>();
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("*")
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Template Desafio ODS Comunidades", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Template Desafio ODS Comunidades v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
