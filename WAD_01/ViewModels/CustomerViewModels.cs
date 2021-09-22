using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAD_01.Models;

namespace WAD_01.ViewModels
{
    public class CustomerViewModels
    {
        public CustomerViewModels()
        {

        }
        public CustomerViewModels(Customer customer)
        {
            Id = customer.Id;
            FullName = customer.FullName;
            Address = customer.Address;
            Phone = customer.Phone;
            Gender = customer.Gender;
            TypeId = customer.TypeId;
            TypeName = customer.CustomerType.TypeName;

        }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}