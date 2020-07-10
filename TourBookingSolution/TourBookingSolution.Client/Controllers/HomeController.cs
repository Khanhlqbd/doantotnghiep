using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBookingSolution.Business.Core;

namespace TourBookingSolution.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IBannerBusiness _bannerBusiness;
        ITourBusiness _tourBusiness;
        INewsBusiness _newsBusiness;
        IPromotionBusiness _promotionBusiness;
        public HomeController(IBannerBusiness bannerBusiness,ITourBusiness tourBusiness,INewsBusiness newsBusiness,IPromotionBusiness promotionBusiness)
        {
            this._bannerBusiness = bannerBusiness;
            this._newsBusiness = newsBusiness;
            this._tourBusiness = tourBusiness;
            this._promotionBusiness = promotionBusiness;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Slider()
        {
            try
            {
                var result = _bannerBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Tour()
        {
            try
            {
                var result = _tourBusiness.GetAll();
                return PartialView(result.Take(8));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult NewTour()
        {
            try
            {
                var result = _tourBusiness.GetAll();
                return PartialView(result.OrderByDescending(x=>x.ID).Take(8));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult News()
        {
            try
            {
                var result = _newsBusiness.GetAll();
                return PartialView(result.Take(8));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Promotion()
        {
            try
            {
                var result = _promotionBusiness.GetAll();
                return PartialView(result.Take(8));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
    }
}