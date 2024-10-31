using Eco_Materalize.DTO;
using Eco_Materalize.Interface;
using Eco_Materalize.Model;
using Microsoft.AspNetCore.Mvc;

namespace Eco_Materalize.Controllers
{
    public class UsuarioController : Controller
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarUsuario([FromBody] Usuario novoUsuario)
        {
            if (novoUsuario == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (string.IsNullOrEmpty(novoUsuario.Nome) ||
                string.IsNullOrEmpty(novoUsuario.Email) ||
                string.IsNullOrEmpty(novoUsuario.Senha) ||
                string.IsNullOrEmpty(novoUsuario.Telefone) ||
                string.IsNullOrEmpty(novoUsuario.Endereco) ||
                string.IsNullOrEmpty(novoUsuario.TipoUsuario))


            {
                return BadRequest("Todos os campos são obrigatórios e devem ser preenchidos corretamente.");
            }

            foreach (var usuario in usuarios)
            {
                if (usuario.Email == novoUsuario.Email)
                {
                    return BadRequest("Este e-mail já está em uso.");
                }
                if (usuario.Telefone == novoUsuario.Telefone)
                {
                    return BadRequest("Este CPF já está cadastrado.");
                }
            }

            usuarios.Add(novoUsuario);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpGet("quantidade")]
        public IActionResult GetQuantidadeUsuarios()
        {
            int quantidade = usuarios.Count; 
            return Ok(new { Quantidade = quantidade });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuarioCadastrado)
        {
            try
            {
                if (usuarioCadastrado == null || string.IsNullOrEmpty(usuarioCadastrado.Email) || string.IsNullOrEmpty(usuarioCadastrado.Senha))
                {
                    return BadRequest("Email e senha são obrigatórios.");
                }

                bool isValid = _usuarioService.ValidarLogin(usuarioCadastrado.Email, usuarioCadastrado.Senha);
                if (isValid)
                {
                    return Ok("Login bem-sucedido!");
                }
                return Unauthorized("Email ou senha inválidos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}