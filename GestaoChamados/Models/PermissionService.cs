namespace GestaoChamados.Models
{
    public static class PermissionService
    {
        private static readonly Dictionary<Papel, List<Permissao>> permissoesPorPapel = new()
{
    {
        Papel.Admin,
        Enum.GetValues<Permissao>().ToList() // Admin tem todas, sem exceção
    },
    {
        Papel.Operador,
        Enum.GetValues<Permissao>()
            .Where(p => p != Permissao.GerenciarUsuarios)
            .ToList()
    },
    {
        Papel.Visualizador,
        new List<Permissao>
        {
            Permissao.ListarClientes,
            Permissao.ListarAtendentes,
            Permissao.ListarChamados
        }
    }
};

        public static bool TemPermissao(Papel papel, Permissao permissao)
        {
            return permissoesPorPapel[papel].Contains(permissao);
        }
    }
}