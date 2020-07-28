using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController() { }

        [HttpGet]
        public IActionResult get()
        {
            return Ok("Alunos: Marta, Maria, João");
        }
    }
}