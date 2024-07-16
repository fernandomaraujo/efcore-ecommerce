using eCommerce.API.Repositories;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;


namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        // {endereco_site}/api/usuarios}
        [HttpGet]
        public IActionResult Get()
        {
            var listaUsuarios = _repository.Get();

            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            var usuario = _repository.Get(id);

            return usuario == null ? NotFound("Não encontrado") : Ok(usuario);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Usuario usuario)
        {
            _repository.Add(usuario);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Usuario usuario, int id)
        {
            // Não há validação de que o ID do usuário é o mesmo do usuário recebido no corpo da requisição

            _repository.Update(usuario);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            _repository.Delete(id);
        
            return Ok();
        }

    }
}
