using BookProject.Core;
using BookProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.DataAccess.Repository
{
    public class ProductRep : IRepository<Product>
    {
        List<Product> _product;
        private Product product;
        DBcontext db;
        public ProductRep(DBcontext db) {
            this._product = new List<Product>();

            this.db = db;
           
        }
        public void Add(Product table)
        {
             db.Products.Add(table);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            product = Find(Id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void Edit(int Id, Product table)
        {
            this.db = db;
            db.Products.Update(table);
            db.SaveChanges();
        }

        public Product Find(int Id)
        {
          return  db.Products.Where(x=> x.Id == Id).First();
        }

        public List<Product> GetAllData()
        {
            return db.Products.ToList();
        }

        public List<Product> Search(string SerachItem)
        {
            return db.Products.Where(x=> x.Title.Contains(SerachItem) || x.Price ==  Convert.ToDouble(SerachItem)
            || x.Author.Contains(SerachItem)).ToList();
        }
    }
}
