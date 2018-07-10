using AutoMapper;
using PGLaw.Application.Contratos.Models;
using PGLaw.Application.Contratos.Models.Contratos;
using PGLaw.Application.Contratos.Models.Pessoas;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;
using PGLaw.Domain.Contratos.Pessoas.Entitties;
//using PGLaw.Domain.Contratos.Enderecos.Entitties;
//using PGLaw.Domain.Contratos.Processos.ValueObjects;
using System.Linq;
using System.Reflection;

namespace PGLaw.Application.Contratos.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            DomainToVM();
            VMToDomain();
        }

        private void DomainToVM()
        {
            CreateMap<Contrato>();
            CreateMap<Tipo>();
            CreateMap<IndiceReajuste>();
            CreateMap<Gerencia>();
            CreateMap<Vigencia>();
            CreateMap<FormaPagamento>();
            CreateMap<TipoServico>();
            CreateMap<ServicoContrato>();
            CreateMap<DocumentoContrato>();
            //CreateMap<Pessoa>();
            //CreateMap<DadosPessoaFisica>();
            //CreateMap<DadosPessoaJuridica>();

            //CreateMap<Pessoa, PessoaFisicaVM>();
            //CreateMap<Pessoa, PessoaJuridicaVM>();

            //CreateMap<Cliente, ClienteVM>()
            //    .ForMember(c => c.Nome, opt => opt.MapFrom(c => c.Pessoa.Nome))
            //    .ForMember(c => c.TipoPessoa, opt => opt.MapFrom(c => c.Pessoa.TipoPessoa))
            //    .ForMember(c => c.Documento, opt => opt.MapFrom(c => c.Pessoa.DocumentoPrincipal));

            //CreateMap<Cliente, ClientePessoaJuridicaVM>()
            //    .ForMember(c => c.Nome, opt => opt.MapFrom(c => c.Pessoa.Nome))
            //    .ForMember(c => c.TipoPessoa, opt => opt.MapFrom(c => c.Pessoa.TipoPessoa))
            //    .ForMember(c => c.Documento, opt => opt.MapFrom(c => c.Pessoa.DocumentoPrincipal));

            //CreateMap<Cliente, ClientePessoaFisicaVM>()
            //    .ForMember(c => c.Nome, opt => opt.MapFrom(c => c.Pessoa.Nome))
            //    .ForMember(c => c.TipoPessoa, opt => opt.MapFrom(c => c.Pessoa.TipoPessoa))
            //    .ForMember(c => c.Documento, opt => opt.MapFrom(c => c.Pessoa.DocumentoPrincipal));
        }

        private void VMToDomain()
        {
            CreateMap<ContratoVM>();
            CreateMap<ServicoContratoVM>();
            CreateMap<DocumentoContratoVM>();

            //CreateMap<DadosPessoaFisicaVM, DadosPessoaFisica>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ConstructUsing(pf => new DadosPessoaFisica(pf.CPF, pf.RG, pf.OrgaoEmissorRG, pf.Celular, pf.TelefoneComercial, pf.DataNascimento));

            //CreateMap<DadosPessoaJuridicaVM, DadosPessoaJuridica>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ConstructUsing(pj => new DadosPessoaJuridica(pj.CNPJ, pj.InscricaoEstadual, pj.inscricaoMunicipal, pj.RazaoSocial, pj.EmailFinanceiro));

            //CreateMap<PessoaFisicaVM, Pessoa>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ForMember(m => m.DadosPessoaJuridica, opt => opt.Ignore())
            //    .ConstructUsing(m => new Pessoa(
            //        m.Id, m.Nome, m.Email, m.Telefone, m.Url, m.Observacoes,
            //        m.DadosPessoaFisica.CPF,
            //        m.DadosPessoaFisica.RG,
            //        m.DadosPessoaFisica.OrgaoEmissorRG,
            //        m.DadosPessoaFisica.Celular,
            //        m.DadosPessoaFisica.TelefoneComercial,
            //        m.DadosPessoaFisica.DataNascimento));

            //CreateMap<PessoaJuridicaVM, Pessoa>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ForMember(m => m.DadosPessoaFisica, opt => opt.Ignore())
            //    .ConstructUsing(m => new Pessoa(
            //        m.Id, m.Nome, m.Email, m.Telefone, m.Url, m.Observacoes,
            //        m.DadosPessoaJuridica.CNPJ,
            //        m.DadosPessoaJuridica.InscricaoEstadual,
            //        m.DadosPessoaJuridica.inscricaoMunicipal,
            //        m.DadosPessoaJuridica.RazaoSocial,
            //        m.DadosPessoaJuridica.EmailFinanceiro));

            //CreateMap<PessoaVM, Pessoa>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ConstructUsing(m => new Pessoa(
            //        m.Id, m.Nome, m.TipoPessoa, m.Email, m.Telefone, m.Url, m.Observacoes,
            //        Mapper.Map<DadosPessoaFisica>(m.DadosPessoaFisica),
            //        Mapper.Map<DadosPessoaJuridica>(m.DadosPessoaJuridica)));

            //CreateMap<ClientePessoaJuridicaVM, Cliente>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ConstructUsing(model => new Cliente(
            //            Mapper.Map<Pessoa>(model.Pessoa),
            //            model.Segmento,
            //            model.Atuacao,
            //            model.UF));

            //CreateMap<ClientePessoaFisicaVM, Cliente>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ConstructUsing(model => new Cliente(
            //            Mapper.Map<Pessoa>(model.Pessoa),
            //            model.Segmento,
            //            model.Atuacao,
            //            model.UF));

            //CreateMap<ClienteVM, Cliente>()
            //    .IgnoreAllPropertiesWithAnInaccessibleSetter()
            //    .ConstructUsing(model => new Cliente(
            //            Mapper.Map<Pessoa>(model.Pessoa),
            //            model.Segmento,
            //            model.Atuacao,
            //            model.UF));
        }



        private IMappingExpression CreateMap<TSource>()
        {
            var tFonte = typeof(TSource);

            if (tFonte.Name.EndsWith("VM"))
            {
                var nomeDestino = typeof(TSource).Name.Replace("VM", "");
                var types = Assembly.Load(new AssemblyName("PGLaw.Domain.Contratos")).GetTypes();
                var tDestino = types.SingleOrDefault(t => t.Name == nomeDestino);

                if (tDestino != null)
                {
                    return CreateMap(tFonte, tDestino);
                }
            }
            else
            {
                var nomeDestino = typeof(TSource).Name + "VM";
                var types = Assembly.Load(new AssemblyName("PGLaw.Application.Contratos")).GetTypes();
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
