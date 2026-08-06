using System;
using System.Collections.Generic;
using System.Text;
using BCrypt.Net;

namespace GestaoChamados.Services
{
    public static class SecurityService
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
        public static bool VerificarSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
        
    }
}