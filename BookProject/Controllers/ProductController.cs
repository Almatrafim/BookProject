using BookProject.Code;
using BookProject.Core;
using BookProject.Core.ViewModels;
using BookProject.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repository;
        private readonly FilesHelper filesHelper;
        private readonly IWebHostEnvironment webHost;
        private readonly IRepository<Category> _categoryRepository;



        public ProductController(IRepository<Product> repository,IWebHostEnvironment webHost,IRepository<Category> _categoryRepository)
        {
            this._repository = repository;
            this.webHost = webHost;
            this._categoryRepository = _categoryRepository;
            filesHelper = new FilesHelper(webHost);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_repository.GetAllData());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.Find(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductView collection)
        {
            try
            {
                var product = new Product
                {
                    Title = collection.Title,
                    Price = collection.Price,
                    Author = collection.Author,
                    ImageUrl = filesHelper.UploadFile(collection.ImageUrl,"images"),
                    CategoryId = _categoryRepository.GetAllData().Where(x => x.name == collection.CategoryView).Select(x => x.id).First()

                };
                _repository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var productedit = _repository.Find(id);
            ProductView productView = new ProductView
            {
                Title = productedit.Title,
                Price = productedit.Price,
                Author = productedit.Author,
                CategoryId = productedit.CategoryId,
                Id = productedit.Id
            };
            return View(productView);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductView collection)
        {
            try
            {
                var product = new Product
                {
                    Title = collection.Title,
                    Price = collection.Price,
                    Author = collection.Author,
                    ImageUrl = filesHelper.UploadFile(collection.ImageUrl, "images"),
                    CategoryId = _categoryRepository.GetAllData().Where(x => x.name == collection.CategoryView).Select(x => x.id).First(),
                    Id = collection.Id

                };
                _repository.Edit(id,product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.Find(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
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
