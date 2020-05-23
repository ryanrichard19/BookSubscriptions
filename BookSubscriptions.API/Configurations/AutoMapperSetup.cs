using System;
using AutoMapper;
using BookSubscriptions.Infrastructure.Data.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace BookSubscriptions.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DataProfile));
        }
    }
}
