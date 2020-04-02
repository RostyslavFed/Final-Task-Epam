using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public CategoryRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Category item)
        {
            _hospitalContext.Categories.Add(item);
        }

        public void Delete(int id)
        {
            var category = _hospitalContext.Categories.Find(id);
            if (category != null)
            {
                _hospitalContext.Categories.Remove(category);
            }
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return _hospitalContext.Categories.Where(predicate).ToList();
        }

        public Category Get(int id)
        {
            return _hospitalContext.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _hospitalContext.Categories;
        }

        public void Update(Category item)
        {
            Category category = Get(item.Id);
            _mapper.Map(item, category);

            var staff = _hospitalContext.Staff.Where(e => e.CategoryId == item.Id).ToList();
            foreach(var e in staff)
            {
                e.CategoryId = item.Id;
            }
        }
    }
}