using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sensores.Radix.Application.Interfaces;
using Sensores.Radix.Application.Services;
using Sensores.Radix.Domain.Core.Interfaces.Repositories;
using Sensores.Radix.Domain.Entity;
using Sensores.Radix.Domain.Events.Handlers;
using Sensores.Radix.Domain.Events.Repository;
using Sensores.Radix.Domain.Events.Requests;
using Sensores.Radix.Infra.Data.Repositories;
using Sensores.Radix.Infra.Data.UOW;


namespace Sensores.Radix.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //SensorEvent
            services.AddScoped<ISensorEventRepository, SensorEventRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISensorEventService, SensorEventService>();
            services.AddScoped<IRequestHandler<AddSensorEventRequest, SensorEvent>, SensorEventHandler>();

        }
    }
}
