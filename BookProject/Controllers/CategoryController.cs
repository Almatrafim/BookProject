using BookProject.Core;
using BookProject.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
        {
            this._repository = repository;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_repository.GetAllData());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.Find(id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                _repository.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {
                _repository.Edit(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.Find(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            
                
        }
        public ActionResult Search(string SearchItem)
        {
            if (SearchItem == null)
            {
                return View("Index", _repository.GetAllData());
            }
            else
            {
                return View("Index", _repository.Search(SearchItem));
            }
        }
    }
}
