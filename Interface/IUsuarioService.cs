using Eco_Materalize.Model;

namespace Eco_Materalize.Interface
{
    public interface IUsuarioService
    {

        bool ValidarLogin(string email, string senha);
        void CadastrarUsuario(Usuario usuario);
        List<Usuario> GetAllUsuarios();


    }
}