using System.Collections.Generic;

namespace PGLaw.Presentation.Web.Views.Shared.Components.ContainerMenus
{
    public static class ComponentHelper
    {
        public static string DefaultIconeCss = "glyphicon glyphicon-tree-deciduous";

        public static Dictionary<string, string> Icones = new Dictionary<string, string>()
        {
            {"Sistema", "fa fa-gears" },
            {"Contratos", "md md-description" },
            {"Web Links", "fa fa-external-link" },
            {"Painel Juridico", "glyphicon glyphicon-align-center" }
        };

        public static string ObterIconeCss(string titulo)
        {
            if (Icones.ContainsKey(titulo))
                return Icones[titulo];

            return DefaultIconeCss;
        }
    }
}