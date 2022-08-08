using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Test.Request.EventRequest;
using Test.Response.PlaceResponse;

namespace Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PlaceController : ControllerBase
    {
        private readonly ILogger<PlaceController> _logger;
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlaceController(ILogger<PlaceController> logger, IPlaceService placeService, IMapper mapper)
        {
            _logger = logger;
            _placeService = placeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var place = _mapper.Map<IEnumerable<GetPlaceResponse>>(await _placeService.GetAll());
                if (place.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(place);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostPlaceRequest place)
        {
            try
            {
                await _placeService.Create(_mapper.Map<BLL.Entities.Place>(place));
                return Ok("место создано");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePlaceRequest place)
        {
            try
            {
                await _placeService.Delete(_mapper.Map<BLL.Entities.Place>(place));
                return Ok("место удалено");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([BindRequired] PutPlaceRequest place)
        {
            try
            {

                await _placeService.Update(_mapper.Map<BLL.Entities.Place>(place));
                return Ok("место изменено"); ;

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }
    }
}
