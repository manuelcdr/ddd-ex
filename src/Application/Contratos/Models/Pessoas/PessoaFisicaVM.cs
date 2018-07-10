namespace PGLaw.Application.Contratos.Models.Pessoas
{
    public class PessoaFisicaVM : PessoaVM
    {
        //public PessoaFisicaVM()
        //{
        //    Id = SequentialGuidGenerator.Generate();
        //}

        //public Guid Id { get; set; }

        //[Display(Name = "Nome")]
        //public string Nome { get; set; }

        //[Display(Name = "Tipo Pessoa")]
        //public TipoPessoa TipoPessoa { get; set; }

        //[Display(Name = "E-mail")]
        //public string Email { get; set; }

        //[Display(Name = "Telefone")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(##)####-####}")]
        //public string Telefone { get; set; }

        //[Display(Name = "Site")]
        //public string Url { get; set; }

        //[Display(Name = "Observações")]
        //public string Observacoes { get; set; }

        //public DadosPessoaFisicaVM DadosPessoaFisica { get; set; }
        private new DadosPessoaJuridicaVM DadosPessoaJuridica;
    }
}
