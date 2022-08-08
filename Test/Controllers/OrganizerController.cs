using AutoMapper;
using BLL.Entities;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Test.Request.OrganizerRequest;
using Test.Response.OrganizerResponse;

namespace Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrganizerController : ControllerBase
    {
        private readonly ILogger<OrganizerController> _logger;
        private readonly IOrganizerService _organizerService;
        private readonly IMapper _mapper;

        public OrganizerController(ILogger<OrganizerController> logger, IOrganizerService organizerService, IMapper mapper)
        {
            _logger = logger;
            _organizerService = organizerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var organizer = _mapper.Map<IEnumerable<GetOrganizerResponse>>(await _organizerService.GetAll());
                if (organizer.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(organizer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostOrganizerRequest organizer)
        {
            try
            {
                await _organizerService.Create(_mapper.Map<BLL.Entities.Organizer>(organizer));
                return Ok("Организатор создан");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrganizerRequest organizer)
        {
            try
            {
                await _organizerService.Delete(_mapper.Map<BLL.Entities.Organizer>(organizer));
                return Ok("Организатор удален");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([BindRequired] PutOrganizerRequest organizer)
        {
            try
            {

                await _organizerService.Update(_mapper.Map<Organizer>(organizer));
                return Ok("Организатор изменён"); ;

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }
    }
}
