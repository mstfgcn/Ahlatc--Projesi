using FRM.Business.Implementations;
using FRM.Business.Interfaces;
using FRM.DataAccess.Implementations.EF.Repository;
using FRM.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FRM.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // servis geneleinde autommapper ı kullanılablir yaptık.
            //Automapperın ihtiyacı olan IMapperı  IoC ye regişter etmiş olucaz tekrar tanımlamamız gerekmiyceck.
            services.AddAutoMapper(typeof(CategoryBs));
            //typeof(Program) ----> WS.WebAPi.program   automapper ögsterilen asbmyl inceleyecek Profile sınıfını kalıtım alan sınıfı bulucak constructor calıstırıp neyi e yapcagını ögreniyor


            //IoC Container Registration

            services.AddScoped<IUserBs, UserBs>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICategoryBs, CategoryBs>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IArticleBs, ArticleBs>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            services.AddScoped<IAuthorBs, AuthorBs>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddSingleton<IAdminPanelUserBs, AdminPanelUserBs>();
            services.AddSingleton<IAdminPanelUserRepository, AdminPanelUserRepository>();


            //IoC Container Registration (END)--------------------

        }
    }
}
