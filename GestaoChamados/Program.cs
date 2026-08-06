using GestaoChamados.Data;
using GestaoChamados.Forms;

namespace GestaoChamados
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Database.Initialize(); // cria tabelas + admin padrão

            using var login = new FormLogin();
            if (login.ShowDialog() != DialogResult.OK)
                return; // fechou sem logar = encerra

            Application.Run(new Form1());
        }
    }
}