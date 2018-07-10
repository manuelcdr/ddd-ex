//using PGLaw.Infra.Cross.Common;
//using System.Web.Mvc;

//namespace PGLaw.Apresentacao.Web.Attributes
//{
//    public class GlobalFilterToolAttribute : ActionFilterAttribute
//    {
//        private readonly Notificacao _notificacao = InstanceFactory.GetInstance<Notificacao>();
//        // prop logger

//        public GlobalFilterToolAttribute()
//        {
//            // IOC de Logger
//        }

//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            // Inicio Log - Metodo, detalhes
//        }

//        public override void OnActionExecuted(ActionExecutedContext filterContext)
//        {
//            // registra log

//            //base.OnActionExecuted(filterContext);

//            if (_notificacao.ContemMensagens)
//                filterContext.Controller.TempData["mensagens"] = _notificacao.Mensagens;

//            if (filterContext.Exception != null)
//            {
//                filterContext.Controller.TempData["ErrorMessage"] = filterContext.Exception.Message;
//            }
//        }

//        public override void OnResultExecuting(ResultExecutingContext filterContext)
//        {
//            base.OnResultExecuting(filterContext);
//        }

//        public override void OnResultExecuted(ResultExecutedContext filterContext)
//        {
//            base.OnResultExecuted(filterContext);
//        }
//    }
//}