using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBookingSolution.Business.Core;

namespace TourBookingSolution.Client.Controllers
{
    public class PromotionController : Controller
    {
        IPromotionBusiness _promotionBusiness;
        public PromotionController(IPromotionBusiness promotionBusiness)
        {
            this._promotionBusiness = promotionBusiness;
        }
        // GET: Promotion
        public ActionResult List()
        {
            try
            {
                var result = _promotionBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Detail(long id)
        {
            try
            {
                var result = _promotionBusiness.GetByID(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}