using PGLaw.Application.Juridico.Models.Common;
using PGLaw.Application.Juridico.Models.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models.Processos
{
    public class DetalhesProcessoVM
    {
        public Guid Id { get; set; }

        public ClienteVM Cliente { get; set; }

        public bool Reu { get; set; }

        [Display(Name = "Instância")]
        public byte NumeroInstancia { get; set; }

        public string NumeroPrimeiraInstancia { get; set; }
        public string NumeroSegundaInstancia { get; set; }
        public string NumeroTerceiraInstancia { get; set; }

        [Display(Name = "Tipo de Processo")]
        public string TipoProcesso { get; set; }

        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }


        // ------ dados juridicos -------------------------------------
        public JusticaVM Justica { get; set; }
        public OrgaoVM Orgao { get; set; }
        public TipoAcaoVM TipoAcao { get; set; }
        public EstadoVM Estado { get; set; }
        public CidadeVM Cidade { get; set; }
        public ForumVM Forum { get; set; }

        [Display(Name = "Vara")]
        public string Vara { get; set; }

        [Display(Name = "Data Distribuição")]
        public DateTime? DataDistribuicao { get; set; }

        [Display(Name = "Data Citação")]
        public DateTime? DataCitacao { get; set; }

        [Display(Name = "Ano")]
        public short? Ano { get; set; }

        [Display(Name = "Processo Eletrônico")]
        public bool ProcessoEletronico { get; set; }


        // ------ dados do negócio -------------------------------------

        public FamiliaOfensoraVM FamiliaOfensora { get; set; }
        public AreaOfensoraVM AreaOfensora { get; set; }
        public MotivoAcionamentoVM MotivoAcionamento { get; set; }
        public CausaRealVM CausaReal { get; set; }


        // ------ dados do pedido -------------------------------------

        [Display(Name = "Valor Causa")]
        public decimal? ValorCausa { get; set; }

        [Display(Name = "Valor Pedido")]
        public decimal? ValorPedido { get; set; }

        [Display(Name = "Valor Provisão")]
        public decimal? ValorProvisao { get; set; }

        public RiscoVM Risco { get; set; }


        // relacionamentos
        public IList<ProcessoPessoaVM> ProcessoPessoas { get; set; }
        public IList<ProcessoPedidoVM> ProcessoPedidos { get; set; }

    }
}
