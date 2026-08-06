namespace GestaoChamados.Models
{
    public class Atendente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Setor { get; set; }

        public Atendente (int id, string nome, string setor)
        {
            Id = id;
            Nome = nome;
            Setor = setor;
        }
        public override string ToString()
        {
            return $"{Id} - {Nome}";
        }
    }
}
