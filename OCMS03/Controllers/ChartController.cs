using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Models;

namespace OCMS03.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View(new Helper());
        }
     }
}
