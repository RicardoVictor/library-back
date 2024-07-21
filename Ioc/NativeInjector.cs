using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Repositories.Base;
using Library.Data.Repositories;
using Library.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;
using Library.Application.Services.Genders;
using Library.Application.Interfaces.Services.Genders;
using Library.Application.Interfaces.Services.Authors;
using Library.Application.Services.Authors;
using Library.Application.Services.Books;
using Library.Application.Interfaces.Services.Books;

namespace Library.Infra.IoC
{
    public static class NativeInjector
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IGenderService, GenderService>();
            
            services.AddScoped<IBookValidationService, BookValidationService>();
            services.AddScoped<IAuthorValidationService, AuthorValidationService>();
            services.AddScoped<IGenderValidationService, GenderValidationService>();
        }
    }
}
