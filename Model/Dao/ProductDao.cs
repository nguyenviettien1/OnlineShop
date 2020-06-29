using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public IEnumerable<ProductCategoryModel> ListProductFull(string searchStringP, ref int totalProduct, int page, int pageSize)
        {
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        select new ProductCategoryModel()
                        {
                            CateMetaTitle = b.MetaTitle,
                            MetaTitle = a.MetaTitle,
                            CateName = b.Name,
                            Name = a.Name,
                            Image = a.Image,
                            Price = a.Price,
                            Description = a.Description,
                            CreatedTime = a.CreatedTime,
                            ID = a.ID
                        };
            if (!string.IsNullOrEmpty(searchStringP))
            {
                model = model.Where(x => x.Name.Contains(searchStringP) || x.MetaTitle.Contains(searchStringP));
            }
            totalProduct = model.Count();
            model = model.OrderByDescending(x => x.CreatedTime).Skip((page - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        /// <summary>
        /// Get list new products
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
        /// <summary>
        /// Get list feature products
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedTime).Take(top).ToList();
        }
        /// <summary>
        /// List product by categoryID
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="totalRecord"></param>
        /// <param name="Page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>        
        public List<ProductCategoryModel> ListByCategoryId(long categoryID, ref int totalRecord, int Page = 1, int pageSize = 8)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        where a.CategoryID == categoryID
                        select new ProductCategoryModel()
                        {
                            CateMetaTitle = b.MetaTitle,
                            MetaTitle = a.MetaTitle,
                            CateName = b.Name,
                            Name = a.Name,
                            Image = a.Image,
                            Description = a.Description,
                            Price = a.Price,
                            CreatedTime = a.CreatedTime,
                            ID = a.ID
                        };
            model = model.OrderByDescending(x=>x.CreatedTime).Skip((Page - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
        /// <summary>
        /// Get list product by keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="totalRecord"></param>
        /// <param name="Page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
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
            catch (Exception)
            {
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
