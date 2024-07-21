using Libraty.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Library.Api
{
    public static class NativeInjector
    {
        public static void AddSqlServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("InMemoryEnvironment"))
            {
                services.AddDbContext<DefaultContext>(options =>
                {
                    options.UseInMemoryDatabase(configuration["ConnectionStringDB"]);
                    options.UseLazyLoadingProxies();
                });
            }
            else
            {
                services.AddDbContext<DefaultContext>(options =>
                {
                    options.UseSqlServer(configuration["ConnectionStringDB"], opt => opt.MigrationsAssembly("Data.Configuration"));
                    options.UseLazyLoadingProxies();
                });                
            }
        }

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
           services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Library",
                        Version = "v1",
                        Description = "Library API MVP",
                        Contact = new OpenApiContact
                        {
                            Name = "Library",
                        }
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
        }
    }
}
