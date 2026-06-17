using primeiroprograma_emCu.Models;
using primeiroprograma_emCu.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;  

namespace primeiroprograma_emCu.Services
{
    public class AuthService
    {
        private readonly List<Usuario> usuarios;

        public AuthService()
        {
            usuarios = [
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    Login = "admin",
                    SenhaHash = SecurityService.GerarHash("123456"),
                    Papel = Papel.Admin
                }
            ];
        }

        public Usuario? Login(string login, string senha)
        {
            Usuario? usuario =
                usuarios.FirstOrDefault(
                    u => u.Login == login
                );

            if (usuario == null)
                return null;

            bool senhaValida =
                SecurityService.VerificarSenha(
                    senha,
                    usuario.SenhaHash
                );

            if (!senhaValida)
                return null;

            Sessao.UsuarioAtual = usuario;

            return usuario;
        }
    }
}