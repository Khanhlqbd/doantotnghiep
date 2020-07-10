
using TourBookingSolution.Business.Core;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBookingSolution.Data.Models;

namespace TourBookingSolution.Admin.Controllers
{
    [CheckLogin]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        IOrderBusiness _orderBusiness;
        ITourBusiness _tourBusiness;
        public DashboardController(IOrderBusiness orderBusiness,ITourBusiness tourBusiness)
        {
            this._orderBusiness = orderBusiness;
            this._tourBusiness = tourBusiness;
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult WidgetTop()
        {
            try
            {
                var result = _orderBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        
        public ActionResult WidgetOrder()
        {
            try
            {
                
                var result = _orderBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }

    }
}