using Microsoft.AspNetCore.Mvc;
using WebApi.Business;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class ParserController : ControllerBase
    {
        readonly Parser parser = new Parser(); 

        [HttpGet]
        public string GetParse(string s)
        {
            string result = parser.Convert(s);
            return result;
        }
    }
}
