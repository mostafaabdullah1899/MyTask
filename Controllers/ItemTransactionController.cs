using Microsoft.AspNetCore.Mvc;
using Task_Rubikans.Models;
using Task_Rubikans.Repository;

namespace Task_Rubikans.Controllers
{
    public class ItemTransactionController : Controller
    {
        IItemTransactionRepository itemTransactionRepo;
        IItemRepository  itemRepo;
        IClientRepository clientRepo;
       public ItemTransactionController(IItemTransactionRepository _itemTransactionRepo , IItemRepository _itemRepo ,IClientRepository _clientRepo)
        {
            itemTransactionRepo = _itemTransactionRepo;
            itemRepo = _itemRepo;
            clientRepo = _clientRepo;
        }
        public IActionResult Index()
        {

            return View(itemTransactionRepo.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(itemTransactionRepo.GetById(id));
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Items"] = itemRepo.GetAll();
            ViewData["Clients"] = clientRepo.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ItemTransaction newitemTrans)
        {
            if (ModelState.IsValid)
            {
                itemTransactionRepo.Add(newitemTrans);
                return RedirectToAction("Index");
            }
            return View(newitemTrans);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewData["Items"] = itemRepo.GetAll();
            ViewData["Clients"] = clientRepo.GetAll();
            return View(itemTransactionRepo.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, ItemTransaction newitemTrans)
        {
            if (ModelState.IsValid)
            {
                itemTransactionRepo.Update(id, newitemTrans);
                return RedirectToAction("Index");
            }
            ViewData["Items"] = itemRepo.GetAll();
            ViewData["Clients"] = clientRepo.GetAll();
            return View(newitemTrans);
        }

        public IActionResult Delete(int id)
        {
            itemTransactionRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
