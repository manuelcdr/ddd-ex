using PGLaw.Application.Juridico.Models.Common;
using PGLaw.Application.Juridico.Models.Pessoas;
using PGLaw.Application.Juridico.Models.Processos;
using PGLaw.Infra.Cross.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGLaw.Application.Juridico.Models
{
    public class ProcessoVM
    {
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


        // dados juridicos
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


        // dados de negócio
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


        // dados do pedido

        [Display(Name = "Valor Causa")]
        public decimal? ValorCausa { get; set; }

        [Display(Name = "Valor Pedido")]
        public decimal? ValorPedido { get; set; }

        [Display(Name = "Valor Provisão")]
        public decimal? ValorProvisao { get; set; }

        [Display(Name = "Valor Resultado")]
        public decimal? ValorResultado { get; set; }

        [Display(Name = "Valor Recebido")]
        public decimal? ValorRecebido { get; set; }

        [Display(Name = "Valor Causa Corrigido")]
        public decimal? ValorCausaCorrigido { get; set; }

        [Display(Name = "Valor Pedido Corrigido")]
        public decimal? ValorPedidoCorrigido { get; set; }

        [Display(Name = "Valor Provisão Corrigido")]
        public decimal? ValorProvisaoCorrigido { get; set; }

        [Display(Name = "Valor Resultado Corrigido")]
        public decimal? ValorResultadoCorrigido { get; set; }

        [Display(Name = "Valor Economizado")]
        public decimal? ValorEconomizado { get; set; }

        [Display(Name = "Data Início Correção")]
        public DateTime? DataInicioCorrecao { get; set; }

        [Display(Name = "Índice de Correção")]
        public int? IndiceCorrecaoId { get; set; }

        [Required]
        [Display(Name = "Processo Eletrônico")]
        public bool ProcessoEletronico { get; set; }

        [Display(Name = "Risco")]
        public Guid? RiscoId { get; set; }

        


        // relacionamentos
        public ClienteVM Cliente { get; set; }
        public JusticaVM Justica { get; set; }
        public OrgaoVM Orgao { get; set; }
        public TipoAcaoVM TipoAcao { get; set; }
        public CidadeVM Cidade { get; set; }
        public ForumVM Forum { get; set; }
        public FamiliaOfensoraVM FamiliaOfensora { get; set; }
        public AreaOfensoraVM AreaOfensora { get; set; }
        public MotivoAcionamentoVM MotivoAcionamento { get; set; }
        public CausaRealVM CausaReal { get; set; }
        public RiscoVM Risco { get; set; }
        public IList<ProcessoPessoaVM> ProcessoPessoa { get; set; }
        public IList<PedidoVM> Pedidos { get; set; }

        // usado no cadastro -------------------------------------
        [Required]
        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }

    }
}
