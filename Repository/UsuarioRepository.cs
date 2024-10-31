using Eco_Materalize.Interface;
using Eco_Materalize.Model;

namespace FindingPet.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public Usuario GetUsuarioByEmailSenha(string email, string senha)
        {
            return _usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public List<Usuario> GetAllUsuarios()
        {
            return _usuarios;
        }
    }
}