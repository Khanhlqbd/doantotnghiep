using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBookingSolution.Business.Core;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Helper.Core;

namespace TourBookingSolution.Admin.Controllers
{
    [CheckLogin]
    public class PromotionController : Controller
    {
        // GET: Promotion
        IPromotionBusiness _promotionBusiness;
        ITourBusiness _tourBusiness;
        public PromotionController(IPromotionBusiness promotionBusiness,ITourBusiness tourBusiness)
        {
            this._promotionBusiness = promotionBusiness;
            this._tourBusiness = tourBusiness;
        }
        // GET: Promotion
        public ActionResult List()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                var result = _promotionBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public string Delete(long id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_promotionBusiness.Delete(id))
                {
                    _promotionBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        public ActionResult Add()
        {
            try
            {
                ViewBag.TourLst = _tourBusiness.GetAll();
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(PromotionView model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                    ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null)
                        return Redirect("/System/Login");
                    model.Staff = login.ID;
                    if (_promotionBusiness.Add(model))
                    {
                        _promotionBusiness.Save();
                        return RedirectToAction("List");
                    }
                }
                ViewBag.TourLst = _tourBusiness.GetAll();
                return View(model);
            }
            catch (Exception)
            {
                ViewBag.TourLst = _tourBusiness.GetAll();
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            try
            {
                ViewBag.TourLst = _tourBusiness.GetAll();
                var item = _promotionBusiness.GetByID(id);
                return View(item);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(PromotionView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                    ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null)
                        return Redirect("/System/Login");
                    if (_promotionBusiness.Edit(model))
                    {
                        _promotionBusiness.Save();
                        return RedirectToAction("List");
                    }
                }
                ViewBag.TourLst = _tourBusiness.GetAll();
                return View(model);
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
                var item = _promotionBusiness.GetByID(id);
                return View(item);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}