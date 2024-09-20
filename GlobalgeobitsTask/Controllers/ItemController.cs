using GlobalgeobitsTask.Context;
using GlobalgeobitsTask.Models;
using GlobalgeobitsTask.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GlobalgeobitsTask.Controllers
{
    public class ItemController : Controller
    {
        private readonly TaskDbContext _context;
        public ItemController(TaskDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int Id = 0)
        {
            var viewModel = new IndexVM();
            int size = 3;
            int skip = size * Id;

            viewModel.Items = _context.Items.Skip(skip).Take(size).ToList();
            viewModel.Index = Id;
            
            ViewBag.ItemCount = _context.Items.Count();

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var item = _context.Items.Find(Id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Item itemObj)
        {
            if (ModelState.IsValid)
            {
                _context.Update(itemObj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult EditPrices(List<Item> items,int Index)
        {
                foreach (var updatedItem in items)
                {
                    var itemToUpdate = _context.Items.FirstOrDefault(i => i.ItemID == updatedItem.ItemID);

                    if (itemToUpdate != null)
                    {
                        itemToUpdate.Price = updatedItem.Price;
                    }
                }
                _context.SaveChanges();
            return RedirectToAction("Index", new { Id = Index });

        }
    }

}
