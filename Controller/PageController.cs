using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore20Auth
{ 
    [Authorize]
    public class PageController : Controller
    { 
        [Authorize(Policy = AuthorizeEnum.View)]
        public ActionResult Index()
        {

            return null;
        }    

        [Authorize(Policy = AuthorizeEnum.New)]
        public ActionResult New()
        {

            return null;
        }  

        [Authorize(Policy = AuthorizeEnum.Edit)]
        public ActionResult Edit(int id)
        {

            return null;
        }

        [HttpPost]  
        [Authorize(Policy = AuthorizeEnum.Save)]
        public ActionResult Save(object model)
        {

            return null;
        }   
    }
}