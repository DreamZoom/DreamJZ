using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream.Cms.Site.Areas.Admin.Controllers
{
    [ValidateInput(false)]
    public class ArticleController : ManageControllerBase<ArticleService,Article>
    {

    }
}
