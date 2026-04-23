using Escola.Domain.Entities;

namespace Escola.Domain.Intefaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorEmailESenha(string email, string senha);
        Task<Usuario> AdicionarUsuario(Usuario usuario);

        Task<Usuario> ObterUsuario(string email);
    }
}
