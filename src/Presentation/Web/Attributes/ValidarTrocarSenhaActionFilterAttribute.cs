//using PgLaw.Apresentacao.Web.App.Interfaces.Services;
//using PGLaw.Infra.Cross.Common;
//using System.Linq;
//using System.Web.Mvc;
//using System.Web.Mvc.Filters;
//using System.Web.Routing;

//namespace PGLaw.Apresentacao.Web.Attributes
//{
//    public class ValidarTrocarSenhaActionFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
//    {
//        public void OnAuthentication(AuthenticationContext filterContext) { }

//        private bool DisableAction(AuthenticationChallengeContext filterContext)
//        {
//            return filterContext.ActionDescriptor.GetCustomAttributes(typeof(DesabilitarValidarTrocarSenhaActionFilterAttribute), true).Any();
//        }

//        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
//        {
//            if (DisableAction(filterContext))
//                return;

//            var sessionTrocarSenha = filterContext.RequestContext.HttpContext.Session["trocar-senha"];
//            if (sessionTrocarSenha != null && !(bool)sessionTrocarSenha)
//                return;

//            if (!filterContext.HttpContext.User.Identity.IsAuthenticated ||
//                filterContext.IsChildAction)
//                return;

//            var service = InstanceFactory.GetInstance<IUsuarioAppServices>();
//            var usuario = service.ObterUsuarioPorEmail(filterContext.HttpContext.User.Identity.Name);

//            if (usuario.TrocarSenha)
//            {
//                filterContext.Result = new RedirectToRouteResult(
//                                    new RouteValueDictionary
//                                    {
//                                        { "action", "AlterarSenha" },
//                                        { "controller", "Usuario" }
//                                    });
//            } else
//            {
//                filterContext.RequestContext.HttpContext.Session.Add("trocar-senha", false);
//            }
//        }
//    }
//}