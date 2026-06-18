using primeiroprograma_emCu.Data;
using primeiroprograma_emCu.Forms;

namespace primeiroprograma_emCu
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