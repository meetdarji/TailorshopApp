using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace TailorShopWebApi.Controllers
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("Api/Customer")]
    public class CustomerController : ApiController
    {
        TailorShopEntities db = new TailorShopEntities();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetCustomerList")]
        public JsonResult GetCustomerList()
        {
            JsonResult res = new JsonResult();

            res.Data = db.tblCustomers.ToList();
                             
            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("GetCustomerListById")]
        public JsonResult GetCustomerListById(int CustomerId)
        {
            JsonResult res = new JsonResult();

            res.Data = db.tblCustomers.Where(x=>x.CustomerID== CustomerId).ToList();

            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CustomerAdd")]
        public string AddCustomer(Cutstomer objcustomer)
        {
            try
            {
                tblCustomer customer = new tblCustomer();
                customer.CustomerName = objcustomer.CustomerName;
                customer.CustomerMobileNo = objcustomer.CustomerMobileNo;
                customer.CustomerAddress = objcustomer.CustomerAddress;
                customer.EmailId = objcustomer.EmailId;
                customer.Gender = objcustomer.Gender;
                customer.Status = objcustomer.Status;


                db.tblCustomers.Add(customer);
                db.SaveChanges();
                return "Customer Saved Successfully";
            }
            catch (Exception ex)
            {
                return "Customer Saveing faild"+ex;
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CustomerUpdate")]
        public string CustomerUpdate(Cutstomer objcustomer)
        {
            try
            {
                tblCustomer customer = db.tblCustomers.Single(x => x.CustomerID == objcustomer.CustomerId);
                customer.CustomerName = objcustomer.CustomerName;
                customer.CustomerMobileNo = objcustomer.CustomerMobileNo;
                customer.CustomerAddress = objcustomer.CustomerAddress;
                customer.EmailId = objcustomer.EmailId;
                customer.Gender = objcustomer.Gender;
                customer.Status = objcustomer.Status;
                db.SaveChanges();
                return "Customer Updated Successfully";
            }
            catch (Exception ex)
            {
                return "Customer Updating faild" + ex;
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("CustomerDelete")]
        public string CustomerDelete(int CustomerId)
        {
            try
            {
                tblCustomer cutomer = db.tblCustomers.Single(x => x.CustomerID == CustomerId);
                db.tblCustomers.Remove(cutomer);
                db.SaveChanges();
                return "Customer Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Customer Deleting faild" + ex;
            }
        }


        #region

        public class Cutstomer
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerMobileNo { get; set; }
            public string CustomerAddress { get; set; }
            public string EmailId { get; set; }
            public string Gender { get; set; }
            public int Status { get; set; }
        }

        #endregion
    }
}
