namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name ="Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(20)]
        [Display(Name ="Mã sản phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        [Display(Name = "Đường dẫn")]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [Display(Name = "Tập ảnh")]
        public string MoreImages { get; set; }

        [Display(Name = "Giá")]
        public decimal? Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }

        public bool? IncludedVAT { get; set; }

        public int? Quantity { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreatedTime { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }
    }
}
