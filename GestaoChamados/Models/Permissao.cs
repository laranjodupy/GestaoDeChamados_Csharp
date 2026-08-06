using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoChamados.Models
{
    public enum Permissao
    {
        AbrirChamado,
        AlterarStatusChamado,
        ExcluirChamado,

        CadastrarCliente,
        EditarCliente,
        ExcluirCliente,

        CadastrarAtendente,
        EditarAtendente,
        ExcluirAtendente,

        ListarClientes,
        ListarAtendentes,
        ListarChamados,

        GerenciarUsuarios
    }
}