using primeiroprograma_emCu.Forms;

namespace primeiroprograma_emCu
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}