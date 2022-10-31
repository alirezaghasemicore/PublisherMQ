using Application.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public class Publisher_Container
    {
        public static void RegisterServicesForPublisher(IServiceCollection services)
        {
            services.AddScoped<ISendMessageService, SendMessageService>();
        }
    }
}
