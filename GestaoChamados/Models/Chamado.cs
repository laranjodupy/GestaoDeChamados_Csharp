namespace GestaoChamados.Models
{
    public class Chamado
    {
        public int Id { get; private set; }
        public string Descricao { get; set; }
        public string Status { get; private set; }
        public Cliente Cliente { get; set; }
        public Atendente Atendente { get; set; }

        public Chamado(int id, string descricao, Cliente cliente, Atendente atendente)
        {
            Id = id;
            Descricao = descricao;
            Cliente = cliente;
            Atendente = atendente;
            Status = "Aberto";
        }

        public void AlterarStatus(string novoStatus)
        {
            Status = novoStatus;
        }

        public override string ToString()
        {
            return $"{Id} - {Descricao} [{Status}]";
        }
    }
}
