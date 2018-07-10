using PGLaw.Domain.Core.Entities;
using PGLaw.Domain.Juridico.Common.Entitties;
using PGLaw.Domain.Juridico.Enderecos.Entitties;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using System;
using System.Collections.Generic;

namespace PGLaw.Domain.Juridico.Processos.Entitties
{
    public class Processo : DefaultEntity<Processo>
    {
        protected Processo()
        {
            ProcessoPessoa = new List<ProcessoPessoa>();
            Pedidos = new List<Pedido>();
            Andamentos = new List<Andamento>();
        }

        public Processo(
            Guid clienteId, 
            bool reu, 
            EsferaProcesso esfera, 
            byte numeroInstancia, 
            string numeroPrimeiraInstancia, 
            string numeroSegundaInstancia, 
            string numeroTerceiraInstancia, 
            int justicaId,
            int orgaoId, 
            int tipoAcaoId, 
            int forumId, 
            int cidadeId, 
            short ano, 
            string vara, 
            bool processoEletronico, 
            DateTime dataCitacao, 
            Guid familiaOfensoraId,
            Guid areaOfensoraId, 
            Guid motivoAcionamentoId, 
            Guid riscoId,
            DateTime? dataDistribuicao = null, 
            Guid? causaRealId = null)
        {
            ClienteId = clienteId;
            Reu = reu;
            Esfera = esfera;
            NumeroInstancia = numeroInstancia;
            NumeroPrimeiraInstancia = numeroPrimeiraInstancia;
            NumeroSegundaInstancia = numeroSegundaInstancia;
            NumeroTerceiraInstancia = numeroTerceiraInstancia;
            JusticaId = justicaId;
            OrgaoId = orgaoId;
            TipoAcaoId = tipoAcaoId;
            ForumId = forumId;
            CidadeId = cidadeId;
            Ano = ano;
            Vara = vara;
            ProcessoEletronico = processoEletronico;
            DataDistribuicao = dataDistribuicao;
            DataCitacao = dataCitacao;
            FamiliaOfensoraId = familiaOfensoraId;
            AreaOfensoraId = areaOfensoraId;
            MotivoAcionamentoId = motivoAcionamentoId;
            CausaRealId = causaRealId;
            RiscoId = riscoId;
        }

        public Guid ClienteId { get; set; }
        public bool Reu { get; set; }

        public EsferaProcesso Esfera { get; set; }
        public byte NumeroInstancia { get; set; }

        public string NumeroPrimeiraInstancia { get; set; }
        public string NumeroSegundaInstancia { get; set; }
        public string NumeroTerceiraInstancia { get; set; }

        // dados jurídicos
        public int JusticaId { get; set; }
        public int OrgaoId { get; set; }
        public int TipoAcaoId { get; set; }
        public int ForumId { get; set; }
        public int CidadeId { get; set; }
        public short Ano { get; set; }
        public string Vara { get; set; }
        public bool ProcessoEletronico { get; set; }
        public DateTime? DataDistribuicao { get; set; }
        public DateTime DataCitacao { get; set; }

        // área de negócio
        public Guid FamiliaOfensoraId { get; set; }
        public Guid AreaOfensoraId { get; set; }
        public Guid MotivoAcionamentoId { get; set; }
        public Guid? CausaRealId { get; set; }

        // pedido
        public Guid RiscoId { get; set; }


        // relacionamentos
        public FamiliaOfensora FamiliaOfensora { get; set; }
        public AreaOfensora AreaOfensora { get; set; }
        public MotivoAcionamento MotivoAcionamento { get; set; }
        public CausaReal CausaReal { get; set; }
        public Justica Justica { get; set; }
        public Orgao Orgao { get; set; }
        public TipoAcao TipoAcao { get; set; }
        public Forum Forum { get; set; }
        public Cidade Cidade { get; set; }
        public Cliente Cliente { get; set; }
        public Risco Risco { get; set; }
        public List<ProcessoPessoa> ProcessoPessoa { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public List<Andamento> Andamentos { get; set; }

        #region metodos

        public void AdicionarPessoaNoProcesso(ProcessoPessoa processoPessoa)
        {
            ProcessoPessoa.Add(processoPessoa);
        }

        public void AdicionarPedidoNoProcesso(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        #endregion


        #region validações

        public override bool EhValido()
        {
            return true;
        }

        #endregion

        //public int NumeroInterno { get; set; }
        //public string NumeroPasta { get; set; }
        //public string Observacoes { get; set; }
    }
}

