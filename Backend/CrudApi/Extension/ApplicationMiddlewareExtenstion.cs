using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CrudApi.Extension
{
    public static class ApplicationMiddlewareExtenstion

    {

        public static IApplicationBuilder ConfigureMiddleWare(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            app.UseRouting();
            app.UseCors("CorsPolicy");
            //app.UseIpRateLimiting();

         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        

            return app;
        }
    }
}
