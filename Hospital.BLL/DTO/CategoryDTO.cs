using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeDTO> Staff { get; set; }
    }
}