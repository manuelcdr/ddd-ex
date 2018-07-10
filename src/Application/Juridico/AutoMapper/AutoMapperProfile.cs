using AutoMapper;
using PGLaw.Application.Juridico.Models;
using PGLaw.Application.Juridico.Models.Pessoas;
using PGLaw.Application.Juridico.Models.Processos;
using PGLaw.Domain.Juridico.Enderecos.Entitties;
using PGLaw.Domain.Juridico.Pessoas.Entities;
using PGLaw.Domain.Juridico.Processos.Entitties;
using PGLaw.Domain.Juridico.Processos.Entitties.Relashionships;
using PGLaw.Domain.Juridico.Processos.ValueObjects;
using PGLaw.Infra.Cross.Common.Enums;
using System.Linq;
using System.Reflection;

namespace PGLaw.Application.Juridico.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            DominioParaViewModel();
            ViewModelParaDominio();
            OutrosMapeamentos();
        }

        private void DominioParaViewModel()
        {
            CreateMap<Processo>();
            CreateMap<Pessoa>();
            CreateMap<Justica>();
            CreateMap<Orgao>();
            CreateMap<Cidade>();
            CreateMap<Estado>();
            CreateMap<TipoAcao>();
            CreateMap<FamiliaOfensora>();
            CreateMap<AreaOfensora>();
            CreateMap<MotivoAcionamento>();
            CreateMap<CausaReal>();
            CreateMap<TipoRelacao>();
            CreateMap<DadosPessoaFisica>();
            CreateMap<DadosPessoaJuridica>();
            CreateMap<Cliente>();

            CreateMap<ProcessoPessoa, ProcessoPessoaVM>()
                .ForMember(x => x.TipoRelacao, opt => opt.MapFrom(x => x.TipoRelacao.Descricao))
                .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Pessoa.Nome))
                .ForMember(x => x.TipoPessoa, opt => opt.MapFrom(x => x.Pessoa.TipoPessoa));

            CreateMap<Pedido, PedidoVM>()
                .ForMember(x => x.Risco, opt => opt.MapFrom(x => x.Risco.Descricao))
                .ForMember(x => x.CausaReal, opt => opt.MapFrom(x => x.CausaReal.Descricao))
                .ForMember(x => x.Tipo, opt => opt.MapFrom(x => x.Tipo.Descricao));

            CreateMap<Pessoa, PessoaFisicaVM>();
            CreateMap<Pessoa, PessoaJuridicaVM>();
            CreateMap<Cliente, ClientePessoaJuridicaVM>();
            CreateMap<Cliente, ClientePessoaFisicaVM>();

            CreateMap<Processo, DetalhesProcessoVM>();
        }

        private void ViewModelParaDominio()
        {
            CreateMap<OrgaoVM>();
            CreateMap<JusticaVM>();
            CreateMap<ProcessoVM>();
            CreateMap<ProcessoPessoaVM>();
            CreateMap<PosCadastroProcessoVM, Processo>();

            CreateMap<DadosPessoaFisicaVM, DadosPessoaFisica>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(pf => new DadosPessoaFisica(pf.CPF, pf.RG, pf.OrgaoEmissorRG, pf.Celular, pf.TelefoneComercial, pf.DataNascimento));

            CreateMap<DadosPessoaJuridicaVM, DadosPessoaJuridica>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(pj => new DadosPessoaJuridica(pj.CNPJ, pj.InscricaoEstadual, pj.inscricaoMunicipal, pj.RazaoSocial, pj.EmailFinanceiro));

            CreateMap<PessoaFisicaVM, Pessoa>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(m => m.DadosPessoaJuridica, opt => opt.Ignore())
                .ConstructUsing(m => new Pessoa(
                    m.Id, m.Nome, m.Email, m.Telefone, m.Url, m.Observacoes,
                    m.DadosPessoaFisica.CPF,
                    m.DadosPessoaFisica.RG,
                    m.DadosPessoaFisica.OrgaoEmissorRG,
                    m.DadosPessoaFisica.Celular,
                    m.DadosPessoaFisica.TelefoneComercial,
                    m.DadosPessoaFisica.DataNascimento));

            CreateMap<PessoaJuridicaVM, Pessoa>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(m => m.DadosPessoaFisica, opt => opt.Ignore())
                .ConstructUsing(m => new Pessoa(
                    m.Id, m.Nome, m.Email, m.Telefone, m.Url, m.Observacoes,
                    m.DadosPessoaJuridica.CNPJ, 
                    m.DadosPessoaJuridica.InscricaoEstadual,
                    m.DadosPessoaJuridica.inscricaoMunicipal,
                    m.DadosPessoaJuridica.RazaoSocial, 
                    m.DadosPessoaJuridica.EmailFinanceiro));

            CreateMap<PessoaVM, Pessoa>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(m => new Pessoa(
                    m.Id, m.Nome, m.TipoPessoa, m.Email, m.Telefone, m.Url, m.Observacoes,
                    Mapper.Map<DadosPessoaFisica>(m.DadosPessoaFisica),
                    Mapper.Map<DadosPessoaJuridica>(m.DadosPessoaJuridica)));

            CreateMap<ClientePessoaJuridicaVM, Cliente>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(model => new Cliente(
                        Mapper.Map<Pessoa>(model.Pessoa),
                        model.Segmento,
                        model.Atuacao,
                        model.UF));

            CreateMap<ClientePessoaFisicaVM, Cliente>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(model => new Cliente(
                        Mapper.Map<Pessoa>(model.Pessoa),
                        model.Segmento,
                        model.Atuacao,
                        model.UF));

            CreateMap<ClienteVM , Cliente>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(model => new Cliente(
                        Mapper.Map<Pessoa>(model.Pessoa),
                        model.Segmento,
                        model.Atuacao,
                        model.UF));
        }

        private void OutrosMapeamentos()
        {
            CreateMap<ClienteVM, ClientePessoaFisicaVM>();
            CreateMap<ClienteVM, ClientePessoaJuridicaVM>();
            CreateMap<ClientePessoaFisicaVM, ClienteVM>();
            CreateMap<ClientePessoaJuridicaVM, ClienteVM>();
            CreateMap<PessoaVM, PessoaFisicaVM>();
            CreateMap<PessoaVM, PessoaJuridicaVM>();

            CreateMap<PessoaFisicaVM, PessoaVM>()
                .ForMember(c => c.TipoPessoa, opt => opt.UseValue(TipoPessoa.Fisica));

            CreateMap<PessoaJuridicaVM, PessoaVM>()
                .ForMember(c => c.TipoPessoa, opt => opt.UseValue(TipoPessoa.Juridica));
        }

        private IMappingExpression CreateMap<TSource>()
        {
            var tFonte = typeof(TSource);

            if (tFonte.Name.EndsWith("VM"))
            {
                var nomeDestino = typeof(TSource).Name.Replace("VM", "");
                var types = Assembly.Load(new AssemblyName("PGLaw.Domain.Juridico")).GetTypes();
                var tDestino = types.SingleOrDefault(t => t.Name == nomeDestino);

                if (tDestino != null)
                {
                    return CreateMap(tFonte, tDestino);
                }
            }
            else
            {
                var nomeDestino = typeof(TSource).Name + "VM";
                var types = Assembly.Load(new AssemblyName("PGLaw.Application.Juridico")).GetTypes();
                var tDestino = types.SingleOrDefault(t => t.Name == nomeDestino);

                if (tDestino != null)
                {
                    return CreateMap(tFonte, tDestino);
                }
            }

            return null;
        }

    }
}
