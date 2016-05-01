using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProduceExchange.Models
{
    public class InventoryModels
    {
        [Required]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Type of Product")]
        [DataType(DataType.Text)]
        public virtual int productType { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        [DataType(DataType.Text)]
        public virtual int productCategory { get; set; }

        [Required]
        [Display(Name = "Product Variety")]
        [DataType(DataType.Text)]
        public virtual string productVariety { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [DataType(DataType.Text)]
        public virtual int productQuantity { get; set; }

        [Required]
        [Display(Name = "Date to be Added")]
        [DataType(DataType.Date)]
        public virtual DateTime addDate { get; set; }
    }

    public class productTypeModels
    {
        [Required]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        [DataType(DataType.Text)]
        public virtual string setProductTypes { get; set; }

        [Display(Name = "Type Description")]
        [DataType(DataType.Text)]
        public virtual string typeDescription { get; set; }
    }
    public class categoryModels
    {
        [Required]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public virtual int productType { get; set; }

        [Required]
        [Display(Name = "Name of Category")]
        [DataType(DataType.Text)]
        public virtual string categoryType { get; set; }

        [Display(Name = "Description of Category")]
        [DataType(DataType.Text)]
        public virtual string categoryDiscription { get; set; }
    }

}