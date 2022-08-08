using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetTokenController : ControllerBase
    {

        public ITokenService _tokenService { get; }
        public GetTokenController(ITokenService tokenService)
        {

            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var token = await _tokenService.GetToken("myApi.write");
                return Ok(token.AccessToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
