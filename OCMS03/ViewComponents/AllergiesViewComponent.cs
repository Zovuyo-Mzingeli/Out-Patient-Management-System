using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.ViewComponents
{
    public class AllergiesViewComponent : ViewComponent
    {
        private readonly OCMS03_TheCollectiveContext context;

        public AllergiesViewComponent(OCMS03_TheCollectiveContext context)
        {
            this.context = context;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            //Medication model = new Medication();
            var model = context.tblMedication.ToListAsync();

            // returns a finished task
            return Task.FromResult<IViewComponentResult>(View(model));
        }
        //public ExaminationViewComponent(IUrlHelperFactory factory)
        //{
        //    this.factory = factory;
        //}
        //private IUrlHelperFactory factory;

        //public void InvokeAsync()
        //{
        //    IUrlHelper helper = factory.GetUrlHelper(ViewContext);
        //    helper.Action(nameof(ExaminationsController.SaveNotes)); // returns url to the current controller action
        //}
    }
}
