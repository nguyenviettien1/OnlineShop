using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;

        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }
        public IEnumerable<Product> ListAllProduct(string searchStringP, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchStringP))
            {
                model = model.Where(x => x.Name.Contains(searchStringP) || x.MetaTitle.Contains(searchStringP));
            }
            return model.OrderByDescending(x => x.CreatedTime).ToPagedList(page, pageSize);
        }
        /// <summary>
        /// Get list new product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedTime).Take(top).ToList();
        }
        public List<Product> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot >DateTime.Now).OrderByDescending(x => x.CreatedTime).Take(top).ToList();
        }
        /// <summary>
        /// Get list product by category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public List<Product> ListByCategoryId(long categoryID, ref int totalRecord ,int Page = 1, int pageSize = 8)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(x=>x.CreatedTime).Skip((Page-1)*pageSize).Take(pageSize).ToList();
            return model;
        }
        public List<Product> Search(string keyword, ref int totalRecord, int Page = 1, int pageSize = 8)
        {
            totalRecord = db.Products.Where(x => x.Name.Contains(keyword)).Count();
            var model = db.Products.Where(x => x.Name.Contains(keyword)).OrderByDescending(x => x.CreatedTime).Skip((Page - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        /// <summary>
        /// Get list related product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<Product> ListRelatedProducts(long productId, int takeProducts)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).Take(takeProducts).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        public long Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.ID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.MoreImages = entity.MoreImages;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.CategoryID = entity.CategoryID;
                product.IncludedVAT = entity.IncludedVAT;
                product.ModifiedTime = DateTime.Now;
                product.ModifiedBy = entity.ModifiedBy;
                product.Quantity = entity.Quantity;
                product.Detail = entity.Detail;
                product.Warranty = entity.Warranty;
                product.Status = entity.Status;
                product.TopHot = entity.TopHot;
                product.ViewCount = entity.ViewCount;
                db.SaveChanges();
                return true;
            }
            catch(Exception){
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
