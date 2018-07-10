namespace PGLaw.Application.Contratos.Models.Common
{
    public class EnderecoVM
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set;}
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int CidadeId { get; set; }

        public CidadeVM Cidade { get; set; }
    }
}
