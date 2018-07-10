namespace PGLaw.Application.Sistema.Models
{
    public class ListItemMenuVM
    {
        public int Id { get; set; }
        public string CaminhoAcesso { get; set; }
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Ordem { get; set; }
        public bool Ferramenta { get; set; }
        public bool Raiz { get; set; }
    }
}
