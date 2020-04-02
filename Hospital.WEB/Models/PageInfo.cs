using System;

namespace Hospital.WEB.Models
{
    public class PageInfo
    {
        private int pageNumber;
        public int PageNumber // номер текущей страницы
        {
            get
            {
                return pageNumber;
            }
            set
            {
                if (value > TotalPages || value < 1)
                {
                    pageNumber = 1;
                }
                else
                {
                    pageNumber = value;
                }
            }
        }
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }

        public PageInfo(int pageNumber, int pageSize, int totalItems)
        {
            PageSize = pageSize;
            TotalItems = totalItems;
            PageNumber = pageNumber;
        }
    }
}