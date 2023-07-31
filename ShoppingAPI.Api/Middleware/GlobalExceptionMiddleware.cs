using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI.Entity.Result;
using ShoppingAPI.Helper.CustomException;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShoppingAPI.Api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {

                await _next(httpContext);

            }
            catch (Exception e)
            {
                if (e.GetType()==typeof(FieldValidationException))
                {
                    List<string>? errors = e.Data["FieldValidationMessage"] as List<string>;

                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(Sonuc<FieldValidationException>.FieldValidationError(HataBilgisi.FieldValidationError(errors)), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy=null
                    });
                }
               else if (e.GetType()==typeof(TokenNotFoundException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(Sonuc<TokenNotFoundException>.TokenNotFound(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
               else if (e.GetType()==typeof(SecurityTokenSignatureKeyNotFoundException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(Sonuc<TokenNotFoundException>.TokenValidationError(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }

                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(Sonuc<Exception>.Error(),new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }

            }

            
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
