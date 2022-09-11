using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OCMS03.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.ViewComponents
{
    public class VitalsViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            Medication model = new Medication();

            // returns a finished task
            return Task.FromResult<IViewComponentResult>(View(model));
        }
        //public VitalsViewComponent(IUrlHelperFactory factory)
        //{
        //    this.factory = factory;
        //}
        //private IUrlHelperFactory factory;

        //public void Invoke()
        //{
        //    IUrlHelper helper = factory.GetUrlHelper(ViewContext);
        //    helper.Action(); // returns url to the current controller action
        //}
    }
}
