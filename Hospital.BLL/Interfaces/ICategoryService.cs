using System.Collections.Generic;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDTO categoryDto);
        void UpdateCategory(CategoryDTO categoryDto);
        void DeleteCategory(int id);
        CategoryDTO GetCategory(int id);
        IEnumerable<CategoryDTO> GetCategories();
        CategoryDTO GetCategoryByName(string name);
        IEnumerable<EmployeeDTO> GetStaffByCategory(int categoryId);
        bool NameExists(string name);
    }
}