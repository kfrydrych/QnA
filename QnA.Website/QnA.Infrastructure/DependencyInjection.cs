﻿using Microsoft.Extensions.DependencyInjection;
using QnA.Application.Interfaces;
using QnA.Domain.Interfaces;

namespace QnA.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDateService, DateService>();

            services.AddSingleton<IMessageBroker, MessageBroker>();
        }
    }
}
