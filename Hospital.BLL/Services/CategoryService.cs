using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateCategory(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _unitOfWork.Categories.Create(category);
            _unitOfWork.Save();
        }

        public void UpdateCategory(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
        }

        public void DeleteCategory(int id)
        {
            _unitOfWork.Categories.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = _unitOfWork.Categories.GetAll().ToList();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public CategoryDTO GetCategory(int id)
        {
            var category = _unitOfWork.Categories.Get(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public IEnumerable<EmployeeDTO> GetStaffByCategory(int categoryId)
        {
            var workers = _unitOfWork.Staff.Find(w => w.CategoryId == categoryId).ToList();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(workers);
        }

        public bool NameExists(string name)
        {
            return _unitOfWork.Categories.Find(c => c.Name.ToLower() == name.ToLower()).ToList().Count > 0;
        }

        public CategoryDTO GetCategoryByName(string name)
        {
            var category = _unitOfWork.Categories.Find(c => c.Name.ToLower() == name.ToLower()).FirstOrDefault();
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}