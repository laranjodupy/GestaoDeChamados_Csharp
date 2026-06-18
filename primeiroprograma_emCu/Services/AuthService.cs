using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Repositories;

namespace primeiroprograma_emCu.Services
{
    public static class AuthService
    {
        private static readonly UsuarioRepository _repo =
            new UsuarioRepository();

        public static bool Login(
            string login,
            string senha)
        {
            var usuario = _repo.BuscarPorLogin(login);

            if (usuario == null)
                return false;

            bool ok = SecurityService.VerificarSenha(
                senha,
                usuario.SenhaHash);

            if (!ok)
                return false;

            Sessao.UsuarioAtual = usuario;

            return true;
        }

        public static void Logout()
        {
            Sessao.UsuarioAtual = null;
        }

        public static bool TemPermissao(
            Permissao permissao)
        {
            if (Sessao.UsuarioAtual == null)
                return false;

            return PermissionService.TemPermissao(
                Sessao.UsuarioAtual.Papel,
                permissao);
        }
    }
}