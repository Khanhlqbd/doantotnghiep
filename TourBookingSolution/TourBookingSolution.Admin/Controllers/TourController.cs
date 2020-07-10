using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBookingSolution.Business.Core;
using TourBookingSolution.Data.ViewModels;

namespace TourBookingSolution.Admin.Controllers
{
    [CheckLogin]
    public class TourController : Controller
    {
        // GET: Tour
        ITourBusiness _tourBusiness;
        public TourController(ITourBusiness tourBusiness)
        {
            this._tourBusiness = tourBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _tourBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(TourView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_tourBusiness.Add(model))
                    {
                        _tourBusiness.Save();
                        return Redirect("/Tour/List");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult Edit(long id)
        {
            try
            {
                var result = _tourBusiness.GetDetail(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TourView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_tourBusiness.Edit(model))
                    {
                        _tourBusiness.Save();
                        return Redirect("/Tour/List");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_tourBusiness.StatusDelete(id))
                {
                    _tourBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
    }
}