using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WAD_01.Models
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public int TypeId { get; set; }

        [ForeignKey("TypeId")] public virtual CustomerType CustomerType { get; set; }
    }
}