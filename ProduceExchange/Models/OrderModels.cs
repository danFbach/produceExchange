using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProduceExchange.Models
{
    public class OrderModels
    {
        public virtual int Id { get; set; }
        [Required]
        [Display(Name = "Client")]
        [DataType(DataType.Text)]
        public virtual int? orderClient { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public virtual int orderType { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public virtual int orderCategory { get; set; }

        [Required]
        [Display(Name = "Product Variety")]
        public virtual int orderVariety { get; set; }
        
        [Display(Name = "Quantity Purchased")]
        public virtual int orderQuantity { get; set; }

        [Display(Name = "Dollar Amount of Purchase")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public virtual decimal orderDollars { get; set; }

        [Display(Name = "Date of Delivery/Order")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public virtual DateTime orderDate { get; set; }

        [Display(Name = "Comments / Special Order")]
        [DataType(DataType.MultilineText)]
        public virtual string orderComment { get; set; }

        [Display(Name = "Status of Order")]
        public virtual int orderStatus { get; set; }
    }
}