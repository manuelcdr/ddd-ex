using PGLaw.Domain.Core.ValueObjects;
using PGLaw.Domain.Juridico.Enderecos.Entitties;

namespace PGLaw.Domain.Juridico.Enderecos.ValueObjects
{
    public class Endereco : ValueObject<Endereco>
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int CidadeId { get; set; }

        //relacionamentos
        public Cidade Cidade { get; set; }

        #region validacoes

        public override bool EhValido()
        {
            return true;
        }

        #endregion
    }
}
