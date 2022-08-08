using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Test.Request.EventRequest;
using Test.Response.SpeakerResponse;

namespace Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SpeakerController : ControllerBase
    {
        private readonly ILogger<SpeakerController> _logger;
        private readonly ISpeakerService _speakerService;
        private readonly IMapper _mapper;

        public SpeakerController(ILogger<SpeakerController> logger, ISpeakerService speakerService, IMapper mapper)
        {
            _logger = logger;
            _speakerService = speakerService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var speaker = _mapper.Map<IEnumerable<GetSpeakerResponse>>(await _speakerService.GetAll());
                if (speaker.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(speaker);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostSpeakerRequest speaker)
        {
            try
            {
                await _speakerService.Create(_mapper.Map<BLL.Entities.Speaker>(speaker));
                return Ok("спикер создан");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSpeakerRequest speaker)
        {
            try
            {
                await _speakerService.Delete(_mapper.Map<BLL.Entities.Speaker>(speaker));
                return Ok("спикер удалён");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([BindRequired] PutSpeakerRequest speaker)
        {
            try
            {

                await _speakerService.Update(_mapper.Map<BLL.Entities.Speaker>(speaker));
                return Ok("спикер изменён"); ;

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }
    }
}
