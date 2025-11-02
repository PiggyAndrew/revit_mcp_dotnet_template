using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NET.Mcp.Server.Services;

namespace NET.Mcp.Server.Extensions
{
    public static  class RegisterServicesExtension
    {
       public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<SocketService>();
        }
    }
}
