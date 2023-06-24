using BookProject.Core;
using BookProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.DataAccess.Repository
{
    public class CategoryRep : IRepository<Category>
    {
        List<Category> _categories;
        private Category category;
        public CategoryRep() {
            this._categories = new List<Category>();
           
        }
        public void Add(Category table)
        {
             _categories.Add(table);
        }

        public void Delete(int Id)
        {
            category = Find(Id);
            _categories.Remove(category);
        }

        public void Edit(int Id, Category table)
        {
            category =Find(Id);
            category = new Category
            {
                id= table.id,
                name = table.name,
                description = table.description
            };

            var index = _categories.FindIndex(x => x.id == Id);
            _categories[index] = category;
        }

        public Category Find(int Id)
        {
          return  _categories.Where(x=> x.id == Id).First();
        }

        public List<Category> GetAllData()
        {
            return _categories;
        }

        public List<Category> Search(string SerachItem)
        {
            return _categories.Where(x=> x.name == SerachItem).ToList();
        }
    }
}
