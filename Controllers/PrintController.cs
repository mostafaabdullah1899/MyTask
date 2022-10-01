using Microsoft.AspNetCore.Mvc;
using Task_Rubikans.Reports;

namespace Task_Rubikans.Controllers
{
    public class PrintController : Controller
    {
        public IActionResult Index()
        {
            var saleInvoice = new SaleInvoice();
            ViewBag.Report = saleInvoice;
            return View("ShowPreview");
        }
    }
}
