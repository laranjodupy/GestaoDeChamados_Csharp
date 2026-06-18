using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Repositories;

namespace primeiroprograma_emCu.Services
{
    public static class AuthService  // <-- muda para static
    {
        private static readonly UsuarioRepository _repo = new UsuarioRepository();

        public static bool Login(string login, string senha)
        {
<<<<<<< HEAD
            usuarios = [
                new Usuario
                {
                    Id = 1,
                    Name = "Administrador",
                    Login = "admin",
                    SenhaHash = SecurityService.GerarHash("123456"),
                    Papel = Papel.Admin
                }
            ];
        }
=======
            var usuario = _repo.BuscarPorLogin(login);
            if (usuario == null) return false;
>>>>>>> 72a937cc722722d83febc9320f71d9202dbd0c17

            bool ok = SecurityService.VerificarSenha(senha, usuario.SenhaHash);
            if (!ok) return false;

            Sessao.UsuarioAtual = usuario;
            return true;
        }

        public static void Logout()
        {
            Sessao.UsuarioAtual = null;
        }

        // Usa o PermissionService que você já tem — aproveita o seu design!
        public static bool TemPermissao(Permissao permissao)
        {
            if (Sessao.UsuarioAtual == null) return false;
            return PermissionService.TemPermissao(Sessao.UsuarioAtual.Papel, permissao);
        }
    }
}