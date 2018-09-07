using System.Web.Mvc;
using Common;

namespace WebAppStd.Controllers
{
    public class BaseController : Controller
    {
        //protected readonly IUnitOfWork _uow;
        //public BaseController(IUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        public BaseController()
        {

        }
       
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}