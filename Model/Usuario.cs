using System.Text.Json.Serialization;

namespace Eco_Materalize.Model
{
    public class Usuario
    {
        private string nome;
        private string email;
        private string senha;
        private string endereco;
        private string telefone;
        private string tipoUsuario;

        public Usuario() { }

        [JsonConstructor]
        public Usuario(string nome, string email, string senha, string endereco, string telefone, string tipoUsuario)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.endereco = endereco;
            this.telefone = telefone;
            this.tipoUsuario = tipoUsuario;
        }

        public Usuario(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}
