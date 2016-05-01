using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProduceExchange.Models
{
    public class ClientModels
    {
        public virtual int Id { get; set; }
        [Required]
        [Display(Name = "Client First Name")]
        [DataType(DataType.Text)]
        public virtual string clientFName { get; set; }
        [Required]
        [Display(Name = "Client Last Name")]
        [DataType(DataType.Text)]
        public virtual string clientLName { get; set; }
        
        [Display(Name = "Business Name")]
        [DataType(DataType.Text)]
        public virtual string businessName { get; set; }
        
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public virtual string clientPhoneNumber { get; set; }

        [Display(Name = "Client Email Address")]
        [DataType(DataType.EmailAddress)]
        public virtual string clientEmail { get; set; }


        [Display(Name = "Client Address")]
        [DataType(DataType.Text)]
        public virtual string clientAddress { get; set; }

        [Display(Name = "Client ZipCode")]
        [DataType(DataType.PostalCode)]
        public virtual int clientZipcode { get; set; }

        [Display(Name ="Money Spent")]
        [DataType(DataType.Currency)]
        public virtual decimal moneySpent { get; set; }

        [Display(Name = "Comments and/or Contacts")]
        [DataType(DataType.MultilineText)]
        public virtual string clientComments { get; set; }
    }
}