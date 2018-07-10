namespace PGLaw.Application.Juridico.Interfaces.Services
{
    public interface IAuxiliaresAppServices : IAppServices
    {
        void Adicionar<T>(T model);
        void Atualizar<T>(T model);
    }
}
