using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PGLaw.Domain.Contratos.Contratos.Entitties;
using PGLaw.Domain.Contratos.Contratos.ValueObjects;
using PGLaw.Infra.Data.Base;

namespace PGLaw.Infra.Data.Contratos.EntityConfigs
{
    public class GerenciaConfig : EntityConfigBase<Gerencia> { }
    public class IndiceReajusteConfig : EntityConfigBase<IndiceReajuste> { }
    public class TipoConfig : EntityConfigBase<Tipo> { }
    public class VigenciaConfig : EntityConfigBase<Vigencia> { }
    public class TipoServicoConfig : EntityConfigBase<TipoServico> { }
    public class FormaPagamentoConfig : EntityConfigBase<FormaPagamento> { }
}