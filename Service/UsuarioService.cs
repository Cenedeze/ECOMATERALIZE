using Eco_Materalize.Interface;
using Eco_Materalize.Model;

namespace Eco_Materalize.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool ValidarLogin(string email, string senha)
        {
            var usuario = _usuarioRepository.GetUsuarioByEmailSenha(email, senha);
            return usuario != null;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
        }

        public List<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAllUsuarios();
        }
    }
}
