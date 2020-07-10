using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBookingSolution.Business.Core;

namespace TourBookingSolution.Admin.Controllers
{
    [CheckLogin]
    public class OrderController : Controller
    {
        // GET: Order
        IOrderBusiness _orderBusiness;
        IOrderDetailBusiness _orderDetailBusiness;
        public OrderController(IOrderBusiness orderBusiness, IOrderDetailBusiness orderDetailBusiness)
        {
            this._orderBusiness = orderBusiness;
            this._orderDetailBusiness = orderDetailBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _orderBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        public string Update(long id, int status)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_orderBusiness.UpdateStatus(id, status))
                {
                    _orderBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        public string UpdateStep(long id, int step)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_orderDetailBusiness.UpdateStep(step, id))
                {
                    _orderDetailBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        public ActionResult Detail(long id)
        {
            try
            {
                var result = _orderDetailBusiness.GetAll(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}