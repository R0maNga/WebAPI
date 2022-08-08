using AutoMapper;
using BLL.Entities;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Test.Request.EventRequest;
using Test.Response.EventResponse;

namespace Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;


        public EventController(ILogger<EventController> logger, IEventService eventService, IMapper mapper)
        {
            _logger = logger;
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            bool includePlace = true,
            bool includeSpeaker = true,
            bool includeOrganizer = true)
        {
            try
            {

                var events = _mapper.Map<IEnumerable<GetEventResponse>>(await _eventService.GetAll(includePlace: includePlace, includeSpeaker: includeSpeaker, includeOrganizer: includeOrganizer));

                if (events.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostEventRequest event_)
        {

            try
            {
                await _eventService.Create(_mapper.Map<BLL.Entities.Event>(event_));
                return Ok("Событие создано");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteEventRequest event_)
        {
            try
            {
                await _eventService.Delete(_mapper.Map<BLL.Entities.Event>(event_));
                return Ok("Событие удалено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id,
            bool includePlace = true,
            bool includeSpeaker = true,
            bool includeOrganizer = true)
        {
            try
            {

                var event_ = _mapper.Map<GetEventResponse>(await _eventService.GetById(id, includePlace: includePlace, includeSpeaker: includeSpeaker, includeOrganizer: includeOrganizer));
                if (event_ == null)
                {
                    return NoContent();
                }
                return Ok(event_);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PutEventRequest @event)
        {
            try
            {
                var dbEvent = await _eventService.GetById(@event.Id);
                if(dbEvent == null)
                {
                    _logger.LogError("Bad event id");
                    return BadRequest();
                }
                
                await _eventService.Update(_mapper.Map(@event, dbEvent));
               
                return Ok("Событие изменено"); ;

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

    }
}
