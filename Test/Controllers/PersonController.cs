using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Test.Request.OrganizerRequest;
using Test.Response.EventResponse.PersonResponse;

namespace Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(ILogger<PersonController> logger, IPersonService personService, IMapper mapper)
        {
            _logger = logger;
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var person = _mapper.Map<IEnumerable<GetPersonResponse>>(await _personService.GetAll());
                if (person.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostPersonRequest person)
        {
            try
            {
                await _personService.Create(_mapper.Map<BLL.Entities.Person>(person));
                return Ok("человек добавлен");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePersonRequest person)
        {
            try
            {
                await _personService.Delete(_mapper.Map<BLL.Entities.Person>(person));
                return Ok("человек удалён");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([BindRequired] PutPersonRequest person)
        {
            try
            {

                await _personService.Update(_mapper.Map<BLL.Entities.Person>(person));
                return Ok("человек изменён"); ;

            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }
    }
}
