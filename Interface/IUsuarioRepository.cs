using Eco_Materalize.Model;

namespace Eco_Materalize.Interface
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioByEmailSenha(string email, string senha);
        void AdicionarUsuario(Usuario usuario);
        List<Usuario> GetAllUsuarios();
    }
}