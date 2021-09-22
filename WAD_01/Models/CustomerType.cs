using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAD_01.Models
{
    public class CustomerType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}