using Microsoft.AspNetCore.Mvc;
using Task_Rubikans.Models;
using Task_Rubikans.Repository;
using Task_Rubikans.ViewModel;

namespace Task_Rubikans.Controllers
{
    public class InventoryController : Controller
    {
        Entity contxt = new Entity();
        IInventoryRepository inventortRepository;
        IClientRepository clienRepo;
        public InventoryController(IInventoryRepository _inventortRepository, IClientRepository _clienRepo)
        {
            inventortRepository = _inventortRepository;
            clienRepo = _clienRepo;
        }

        public IActionResult Invoice()
        {
            Inventory invent = inventortRepository.GetId();
            Client client = clienRepo.GetId();
            InvoiceVM invoiceVM = new InvoiceVM();
            invoiceVM.InventoryId = invent.Id;
            invoiceVM.ClientId = client.Id;
            ViewData["Clients"] = clienRepo.GetAll();
            ViewData["Inventors"] = inventortRepository.GetAll();
            invoiceVM.Items = contxt.Items.ToList();

            return View(invoiceVM);
        }



        public IActionResult Index()
        {

            return View(inventortRepository.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(inventortRepository.GetById(id));
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Inventory newinventorty)
        {
            if (ModelState.IsValid)
            {
                inventortRepository.Add(newinventorty);
                return RedirectToAction("Index");
            }
            return View(newinventorty);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(inventortRepository.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Inventory newinventorty)
        {
            if (ModelState.IsValid)
            {
                inventortRepository.Update(id, newinventorty);
                return RedirectToAction("Index");
            }
            return View(newinventorty);
        }

        public IActionResult Delete(int id)
        {
            inventortRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetItems(int invent)
        {
            return Json(contxt.Items.Where(i => i.InventoryId == invent).ToList());
        }
    }
}
