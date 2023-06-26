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
        DBcontext db;
        List<Category> _categories;
        private Category category;
        public CategoryRep(DBcontext db)
        {
            this.db = db;
            this._categories = new List<Category>();
           
        }
        public void Add(Category table)
        {
             db.Categories.Add(table);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            category = Find(Id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public void Edit(int Id, Category table)
        {
            this.db = db;
            db.Categories.Update(table);
            db.SaveChanges();
            
        }

        public Category Find(int Id)
        {
          return  db.Categories.Where(x=> x.id == Id).First();
        }

        public List<Category> GetAllData()
        {
            return db.Categories.ToList();
        }

        public List<Category> Search(string SerachItem)
        {
            return db.Categories.Where(x=> x.name == SerachItem).ToList();
        }
    }
}
