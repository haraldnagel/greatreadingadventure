using Microsoft.AspNetCore.Mvc;

namespace GRA.Controllers.Base
{
    [Route("{culture:validCulture}/[controller]", Order = -2)]
    [Route("{sitePath:validSitePath}/[controller]")]
    [Route("[controller]")]
    public abstract class Controller : BaseController
    {
        protected Controller(ServiceFacade.Controller context) : base(context)
        {
        }

    }
}
