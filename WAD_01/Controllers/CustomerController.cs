using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD_01.Models;
using WAD_01.Reponsitory;
using WAD_01.ViewModels;

namespace WAD_01.Controllers
{
    public class CustomerController : Controller
    {
        private IResponsitory<Customer> customers;
        private IResponsitory<CustomerType> customerType;
        public CustomerController()
        {
            customers = new Responsitory<Customer>();
            customerType = new Responsitory<CustomerType>();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customerTypes = customerType.Get().ToList();
            customerTypes.Add(new CustomerType { TypeId = 0, TypeName = "--Select customer type--" });
            ViewBag.Type = new SelectList(customerTypes, "TypeId", "TypeName", 0);

            return View();
        }

        public ActionResult GetData(int type = 0, string name = null)
        {
            var data = customers.Get();
            if (type != 0 && name != null)
            {
                data = data.Where(x => x.TypeId == type && x.FullName.Contains(name));
            }
            return Json(new
            {
                statusCode = 200,
                message = "Thành công",
                data = data.Select(y => new CustomerViewModels(y))
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                var data = customers.Get(x => x.Id == id);
                if (data == null)
                {
                    return Json(new
                    {
                        statusCode = 404,
                        message = "Thất bại",
                    }, JsonRequestBehavior.AllowGet);
                }
                customers.Delete(id);
                //using (var _context = new ApplicationDbContext())
                //{
                //    var a = id.ToLower();
                //    var dataa = _context.Customers.FirstOrDefault(x => x.Id.ToLower().Equals(a));
                //    if (dataa == null)
                //    {
                //        return Json(new
                //        {
                //            statusCode = 404,
                //            message = "Thất bại",
                //        }, JsonRequestBehavior.AllowGet);
                //    }
                //    _context.Customers.Remove(dataa);
                //    //customers.Delete(id);
                return Json(new
                {
                    statusCode = 200,
                    message = "Thành công",
                }, JsonRequestBehavior.AllowGet);
            //}
                //var data = customers.Get();

            }
            catch
            {
                return Json(new
                {
                    statusCode = 404,
                    message = "Thất bại",
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
