namespace GestaoChamados.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Contato { get; set; }

        public Cliente (int id, string nome, string contato)
        {
            Id = id;
            Nome = nome;
            Contato = contato;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome}";
        }
    }
}
