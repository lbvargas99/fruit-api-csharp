using Fruit.Crud.Core.Application.Mappings;
using Fruit.Crud.Core.Application.Services;
using Fruit.Crud.Core.Application.Services.Interfaces;
using Fruit.Crud.Core.Domain.Repositories;
using Fruit.Crud.Core.Infra.Data.Contexts;
using Fruit.Crud.Core.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit.Crud.Core.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Conexão com banco
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IFruitRepository, FruitRepository>();
            return services;
        }

        //Injetando o service
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IFruitService, FruitService>();
            return services;
        }

    }
}
