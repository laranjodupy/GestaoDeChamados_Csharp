using System;
using System.Collections.Generic;
using System.Text;

namespace primeiroprograma_emCu.Models
{
    public static class PermissionService
    {
        private static readonly Dictionary<Papel, List<Permissao>>
            permissoesPorPapel =
            new Dictionary<Papel, List<Permissao>>
        {
            {
                Papel.Admin,
                new List<Permissao>
                {
                    Permissao.AbrirChamado,
                    Permissao.AlterarStatusChamado,

                    Permissao.CadastrarCliente,
                    Permissao.CadastrarAtendente,

                    Permissao.ListarClientes,
                    Permissao.ListarAtendentes,
                    Permissao.ListarChamados
                }
            },

            {
                Papel.Atendente,
                new List<Permissao>
                {
                    Permissao.AbrirChamado,
                    Permissao.AlterarStatusChamado,

                    Permissao.CadastrarCliente,

                    Permissao.ListarClientes,
                    Permissao.ListarAtendentes,
                    Permissao.ListarChamados
                }
            },

            {
                Papel.Cliente,
                new List<Permissao>
                {
                    Permissao.AbrirChamado,
                    Permissao.ListarChamados
                }
            }
        };

        public static bool TemPermissao(
            Papel papel,
            Permissao permissao)
        {
            return permissoesPorPapel[papel]
                .Contains(permissao);
        }
    }
}