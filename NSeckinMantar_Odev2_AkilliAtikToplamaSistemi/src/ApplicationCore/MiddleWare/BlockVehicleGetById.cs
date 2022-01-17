using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.MiddleWare
{
    public class BlockVehicleGetById
    {
        private readonly RequestDelegate _next;

        public BlockVehicleGetById(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string method = context.Request.Method;
            string path = context.Request.Path;

            if (path == "/api/v1/Vehicles/1" || path == "/api/v1/Vehicles/2" && method == "GET")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("This Method Blocked By Developers");
                return;
            }

            await _next.Invoke(context);
        }


    }
}
