using FRM.Business.CustomException;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace FRM.WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //UseExceptionHandler-->çnet içindeki exception yalayan middleware
            app.UseExceptionHandler(config =>
            {
                //run metodu response döndürmek için kullanılıyor 
                config.Run(async context =>
                {
                    // try cacht  yakaladıgımız expenxını bu şekilde yakalıyoruz
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature.Error;
                    //oluşan hatayı elde ettik
                    var statusCode = StatusCodes.Status500InternalServerError;

                    switch (exception)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;
                        case NotFountException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;
                        default:
                            break;

                    }

                    context.Response.ContentType = "application/json"; // dönecegin responsun türü json dır diyoruz.

                    var response = ApiResponse<NoData>.Fail(statusCode, exception.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });


        }

    }
}
