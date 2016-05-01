using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProduceExchange.Models
{
    public class ViewModel
    {
        public productTypeModels shareProductModels { get; set; }
        public InventoryModels shareInventoryModels { get; set; }
        public categoryModels shareCategoryModels { get; set; }
    }
}