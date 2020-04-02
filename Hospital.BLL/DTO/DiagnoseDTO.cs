using System.Collections.Generic;

namespace Hospital.BLL.DTO
{
    public class DiagnoseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Notation { get; set; }
        public virtual ICollection<ExaminationDTO> Examinations { get; set; }
    }
}