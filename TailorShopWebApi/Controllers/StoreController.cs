using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace TailorShopWebApi.Controllers
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("Api/Store")]
    public class StoreController : ApiController
    {
        TailorShopEntities db = new TailorShopEntities();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetStoreList")]
        public JsonResult GetStoreList()
        {
            JsonResult res = new JsonResult();

            res.Data = db.tblStores.ToList();

            return res;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetStoreListById")]
        public JsonResult GetStoreListById(int StoreID)
        {
            JsonResult res = new JsonResult();

            res.Data = db.tblStores.Where(x => x.StoreID == StoreID).ToList();

            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("StoreInsert")]
        public string StoreInsert(Store objStore)
        {
            try
            {
                tblStore Store = new tblStore();
                Store.StoreName = objStore.StoreName;
                Store.StoreMobileNo = objStore.StoreMobileNo;
                Store.StoreAddress = objStore.StoreAddress;
                Store.StoreEmailId = objStore.StoreEmailId;
                Store.StoreStatus = objStore.StoreStatus;

                db.tblStores.Add(Store);
                db.SaveChanges();
                return "Store Inserted Successfully";
            }
            catch (Exception ex)
            {
                return "Store Inserting faild" + ex;
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("StoreUpdate")]
        public string StoreUpdate(Store objStore)
        {
            try
            {
                tblStore Store = db.tblStores.Single(x => x.StoreID == objStore.StoreID);
                Store.StoreName = objStore.StoreName;
                Store.StoreMobileNo = objStore.StoreMobileNo;
                Store.StoreAddress = objStore.StoreAddress;
                Store.StoreEmailId = objStore.StoreEmailId;
                Store.StoreStatus = objStore.StoreStatus;
                db.SaveChanges();

                return "Store Updated Successfully";
            }
            catch (Exception ex)
            {
                return "Store Update faild" + ex;
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("StoreDelete")]
        public string StoreDelete(int StoreID)
        {
            try
            {
                tblStore store = db.tblStores.Single(x => x.StoreID == StoreID);
                db.tblStores.Remove(store);
                db.SaveChanges();
                return "Store Deleted Successfully";
            }
            catch (Exception ex)
            {
                return "Store Deleting faild" + ex;
            }
        }

        #region

        public class Store
        {
            public int StoreID { get; set; }
            public string StoreName { get; set; }
            public string StoreMobileNo { get; set; }
            public string StoreAddress { get; set; }
            public string StoreEmailId { get; set; }
            public int StoreStatus { get; set; }
        }

        #endregion
    }
}
