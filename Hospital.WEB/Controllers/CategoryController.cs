using Hospital.BLL.Interfaces;
using System.Web.Mvc;
using Hospital.WEB.Factories.Interfaces;
using Hospital.WEB.Models.ViewModels.CategoryViewModels;
using Hospital.BLL.DTO;
using AutoMapper;
using System.Collections.Generic;
using Hospital.WEB.Models;
using System.Linq;

namespace Hospital.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IViewModelFactory<IEnumerable<CategoryDTO>, CategoryListViewModel> _categoryListViewModelFactory;
        private readonly IViewModelFactory<CategoryDTO, CategoryViewModel> _categoryViewModelFactory;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper,
            IViewModelFactory<IEnumerable<CategoryDTO>, CategoryListViewModel> categoryListViewModelFactory,
            IViewModelFactory<CategoryDTO, CategoryViewModel> categoryViewModelFactory)
        {
            _categoryListViewModelFactory = categoryListViewModelFactory;
            _categoryViewModelFactory = categoryViewModelFactory;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: Category/List
        public ActionResult List(int page = 1)
        {
            int pageSize = 10;
            var categories = _categoryService.GetCategories();
            var categoryListViewModel = _categoryListViewModelFactory.Create(categories);
            categoryListViewModel.PageInfo = new PageInfo(page, pageSize, categories.ToList().Count);

            ViewBag.Title = "List Category";

            return View(categoryListViewModel);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var category = new CategoryDTO();
            var categoryViewModel = _categoryViewModelFactory.Create(category);

            return View(categoryViewModel);
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            var nameAlreadyExists = _categoryService.NameExists(categoryViewModel.Name);
            if (nameAlreadyExists)
            {
                ModelState.AddModelError(nameof(CategoryViewModel.Name), 
                    $"Category {categoryViewModel.Name} already exists.");
            }

            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryDTO>(categoryViewModel);
                _categoryService.CreateCategory(category);
                return RedirectToAction("List");
            }

            return View(categoryViewModel);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryViewModel = _categoryViewModelFactory.Create(category);
            
            return View(categoryViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            var nameAlreadyExists = _categoryService.NameExists(categoryViewModel.Name);
            if (nameAlreadyExists)
            {
                var category = _categoryService.GetCategoryByName(categoryViewModel.Name);
                if (category.Id != categoryViewModel.Id)
                {
                    ModelState.AddModelError(nameof(CategoryViewModel.Name),
                        $"Category {categoryViewModel.Name} already exists.");
                }
                else
                {
                    return RedirectToAction("List");
                }
            }

            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryDTO>(categoryViewModel);
                _categoryService.UpdateCategory(category);
                return RedirectToAction("List");
            }

            return View(categoryViewModel);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var categoryDTO = _categoryService.GetCategory(id);
            if (categoryDTO == null)
            {
                return HttpNotFound();
            }
            var categoryViewModel = _categoryViewModelFactory.Create(categoryDTO);

            return View(categoryViewModel);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("List");
        }
    }
}