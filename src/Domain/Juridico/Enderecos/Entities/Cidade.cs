namespace PGLaw.Domain.Juridico.Enderecos.Entitties
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int EstadoId { get; set; }

        public Estado Estado { get; set; }
    }
}
