using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Models
{
    public class Product
    {/*SQl Server -- C#
        int - int
        smallint-short int
        tinyint-short
        bigint-long
        numeric-float/double
        float -float
        money, smallmoney-decimal
        char,nchar-string
        binary  -byte , byte[]
        bit- bool
        DateTime-datetime

        */       
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage="Product Name is Required")]
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}