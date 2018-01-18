using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace simplewebserver
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            int Fib(int n)
            {
                if (n == 0)
                {
                    return 0;
                }
                if (n == 1 || n == 2)
                {
                    return 1;
                }
                else
                {
                    return (Fib(n-2) + Fib(n-1));
                }
            }
            app.Run(async (context) =>
            {
                if (context.Request.Path.Value.Contains("fibonacci"))
                {
                    if (context.Request.Query.ContainsKey("index"))
                    {
                        var indexValue = int.Parse(context.Request.Query["index"]);

                        if (0 <= indexValue && indexValue <= 40)
                        {
                            var temp = Fib(indexValue);
                            var temp1 = temp.ToString();
                            await context.Response.WriteAsync(temp1);
                        }
                    }
                }

            });
        }
    }
}
