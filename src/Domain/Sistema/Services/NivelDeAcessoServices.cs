using PGLaw.Domain.Sistema.Entitties;
using PGLaw.Domain.Sistema.Interfaces.Repositories;
using PGLaw.Domain.Sistema.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGLaw.Domain.Sistema.Services
{
    public class NivelDeAcessoServices : INivelDeAcessoServices
    {
        private readonly IUsuariosRepository aditionalRepository;
        private readonly ISistemaGlobalRepository repository;

        public NivelDeAcessoServices(ISistemaGlobalRepository repository, IUsuariosRepository aditionalRepository)
        {
            this.repository = repository;
            this.aditionalRepository = aditionalRepository;
        }

        public void Excluir(Guid id)
        {
            repository.Excluir<NivelDeAcesso>(id);
        }

        public void Adicionar(Guid id, string nome, string detalhes, IEnumerable<Guid> usuariosIds, IEnumerable<Guid> menusIds)
        {
            var nivel = new NivelDeAcesso(id, nome, detalhes);
            if (nivel.EhValido())
            {
                repository.Adicionar(nivel);
                aditionalRepository.AtualizarRelacionametoMenuNivelDeAcesso(id, menusIds.ToArray());
                aditionalRepository.AtualizarRelacionametoUsuarioNivelDeAcessoPorNivelDeAcesso(id, usuariosIds.ToArray());
            }
        }

        public void Atualizar(Guid id, string nome, string detalhes, IEnumerable<Guid> usuariosIds, IEnumerable<Guid> menusIds)
        {
            var nivel = repository.ObterPorId<NivelDeAcesso>(id);
            nivel.Nome = nome;
            nivel.Detalhes = detalhes;
            if (nivel.EhValido())
            {
                repository.Atualizar(nivel);
                aditionalRepository.AtualizarRelacionametoMenuNivelDeAcesso(id, menusIds.ToArray());
                aditionalRepository.AtualizarRelacionametoUsuarioNivelDeAcessoPorNivelDeAcesso(id, usuariosIds.ToArray());
            }
        }
    }
}
