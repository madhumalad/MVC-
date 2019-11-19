using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class CategoryProductViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public int SelectetCategoryId { get; set; }
        public string SelectedCategoryName { get; set; }
    }
}