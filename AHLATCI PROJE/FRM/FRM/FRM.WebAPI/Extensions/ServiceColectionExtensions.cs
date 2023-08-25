using System.Text.Json.Serialization;

namespace FRM.WebAPI.Extensions
{
    public static class ServiceColectionExtensions
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            // Add services to the container.
            //jsona çevirirken döngüleri görmezden gel diyoruz
            services.AddControllers().AddJsonOptions(
                opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
    }
}
