using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class PosCadastroProcessoVM
    {
        public PosCadastroProcessoVM()
        {
            Id = SequentialGuidGenerator.Generate();
            ProcessoPessoas = new List<ProcessoPessoaVM>();
            ProcessoPedidos = new List<ProcessoPedidoVM>();
        }

        public PosCadastroProcessoVM(PreCadastroProcessoVM preCadastro)
            : this()
        {
            ClienteId = preCadastro.ClienteId;
            TipoProcesso = preCadastro.TipoProcesso;
            NumeroProcesso = preCadastro.NumeroProcesso;
            NumeroInstancia = preCadastro.NumeroInstancia;

            if (NumeroInstancia == 1)
                NumeroPrimeiraInstancia = preCadastro.NumeroNInstancia;
            else if (NumeroInstancia == 2)
                NumeroSegundaInstancia = preCadastro.NumeroNInstancia;
            else if (NumeroInstancia == 3)
                NumeroTerceiraInstancia = preCadastro.NumeroNInstancia;
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }

        public bool Reu { get; set; }

        [Required]
        [Display(Name = "Instância")]
        public byte NumeroInstancia { get; set; }

        public string NumeroPrimeiraInstancia { get; set; }
        public string NumeroSegundaInstancia { get; set; }
        public string NumeroTerceiraInstancia { get; set; }

        [Required]
        [Display(Name = "Tipo de Processo")]
        public string TipoProcesso { get; set; }

        [Required]
        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }


        // ------ dados juridicos -------------------------------------
        [Required]
        [Display(Name = "Justiça")]
        public int JusticaId { get; set; }

        [Required]
        [Display(Name = "Órgão")]
        public int OrgaoId { get; set; }

        [Required]
        [Display(Name = "Tipo de Ação")]
        public int TipoAcaoId { get; set; }

        [Required]
        [Display(Name = "UF")]
        public int EstadoId { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        [Required]
        [Display(Name = "Fórum")]
        public int ForumId { get; set; }

        [Required]
        [Display(Name = "Vara")]
        public string Vara { get; set; }

        [Display(Name = "Data Distribuição")]
        public DateTime? DataDistribuicao { get; set; }

        [Required]
        [Display(Name = "Data Citação")]
        public DateTime? DataCitacao { get; set; }

        [Required]
        [Display(Name = "Ano")]
        public short? Ano { get; set; }

        [Required]
        [Display(Name = "Processo Eletrônico")]
        public bool ProcessoEletronico { get; set; }


        // ------ dados do negócio -------------------------------------

        [Required]
        [Display(Name = "Família Ofensora")]
        public Guid FamiliaOfensoraId { get; set; }

        [Required]
        [Display(Name = "Produto / Área Ofensora")]
        public Guid AreaOfensoraId { get; set; }

        [Required]
        [Display(Name = "Motivo de Acionamento")]
        public Guid MotivoAcionamentoId { get; set; }

        [Display(Name = "Causa Real")]
        public Guid? CausaRealId { get; set; }


        // ------ dados do pedido -------------------------------------

        [Display(Name = "Valor Causa")]
        public decimal? ValorCausa { get; set; }

        [Display(Name = "Valor Pedido")]
        public decimal? ValorPedido { get; set; }

        [Display(Name = "Valor Provisão")]
        public decimal? ValorProvisao { get; set; }
        
        [Display(Name = "Risco")]
        public Guid? RiscoId { get; set; }


        // relacionamentos
        public IList<ProcessoPessoaVM> ProcessoPessoas { get; set; }
        public IList<ProcessoPedidoVM> ProcessoPedidos { get; set; }
    }
}
