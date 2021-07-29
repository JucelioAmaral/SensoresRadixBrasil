using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Sensores.Radix.Application.DTOs;
using Sensores.Radix.Application.Interfaces;
using SensoresRadixBrasil.Hubs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensoresRadixBrasil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorEventsController : ControllerBase
    {
        private readonly ISensorEventService _sensorEventService;
        private readonly IHubContext<DashboardHub> _dashboardHubContext;

        public SensorEventsController(ISensorEventService sensorEventService, IHubContext<DashboardHub> dashboardHubContext)
        {
            _sensorEventService = sensorEventService;
            _dashboardHubContext = dashboardHubContext;
        }

        [HttpGet]
        public async Task<IEnumerable<SensorEventDto>> Get()
        {
            return await _sensorEventService.GetAll();
        }

        [HttpPost]
        public async Task<SensorEventDto> Insert(SensorEventDto sensorEventDto)
        {
            var sensorEvent = await _sensorEventService.AddSensorEvent(sensorEventDto);
            await _dashboardHubContext.Clients.All.SendAsync("updateListEvent", sensorEvent);
            return sensorEvent;
        }

        [HttpGet("/GetAllForGraph")]
        public async Task<DataForGraphDto> GetAllForGraph()
        {
            return await _sensorEventService.GetAllForGraph();
        }
    }
}
