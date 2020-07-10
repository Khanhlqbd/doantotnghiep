using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using TourBookingSolution.Business.Core;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Helper.Core;

namespace TourBookingSolution.Client.Controllers
{
    public class TourController : Controller
    {
        ITourBusiness _tourBusiness;
        IStepBusiness _stepBusiness;
        IOrderBusiness _orderBusiness;
        IMemberBusiness _memberBusiness;
        IPromotionBusiness _promotionBusiness;
        IOrderDetailBusiness _orderDetailBusiness;
        public TourController(ITourBusiness tourBusiness, IStepBusiness stepBusiness, IOrderBusiness orderBusiness, IMemberBusiness memberBusiness, IPromotionBusiness promotionBusiness, IOrderDetailBusiness orderDetailBusiness)
        {
            this._tourBusiness = tourBusiness;
            this._stepBusiness = stepBusiness;
            this._orderBusiness = orderBusiness;
            this._memberBusiness = memberBusiness;
            this._promotionBusiness = promotionBusiness;
            this._orderDetailBusiness = orderDetailBusiness;
        }
        // GET: Tour
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
        public ActionResult Detail(long id)
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
        public ActionResult Booking(long id)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null || login.ID == 0)
                    return Redirect("/dang-nhap.html");

                var result = _tourBusiness.GetDetail(id);
                var steps = _stepBusiness.GetAll(id);
                ViewBag.StepsLst = steps;
                DateTime date = DateTime.Now;
                DateTime end = new DateTime(Convert.ToInt32(result.EndDate.Split('/')[2]), Convert.ToInt32(result.EndDate.Split('/')[1]), Convert.ToInt32(result.EndDate.Split('/')[0]));
                if ((end - date).TotalDays >= 0)
                    ViewBag.IsTrue = 1;
                else
                    ViewBag.IsTrue = 0;
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Confirm(string vpc_AdditionData, string vpc_Amount, string vpc_Command, string vpc_CurrencyCode, string vpc_Locale, string vpc_MerchTxnRef, string vpc_Merchant, string vpc_OrderInfo,
            string vpc_TransactionNo, string vpc_TxnResponseCode, string vpc_Version, string vpc_SecureHash)
        {
            Utils.WriteLogToFile("[Date]=[" + DateTime.Now + "]|[vpc_AdditionData]=[" + vpc_AdditionData + "]|[vpc_Amount]=[" + vpc_Amount + "]|[vpc_Command]=[" + vpc_Command + "]|[vpc_CurrencyCode]=[" + vpc_CurrencyCode + "]|[vpc_Locale]=[" + vpc_Locale + "]|[vpc_MerchTxnRef]=[" + vpc_MerchTxnRef + "]|[vpc_Merchant]=[" + vpc_Merchant + "]|[vpc_OrderInfo]=[" + vpc_OrderInfo + "]|[vpc_TransactionNo]=[" + vpc_TransactionNo + "]|[vpc_TxnResponseCode]=[" + vpc_TxnResponseCode + "]|[vpc_Version]=[" + vpc_Version + "]|[vpc_SecureHash]=[" + vpc_SecureHash + "]");

            OrderView order = new OrderView();
            order = _orderBusiness.GetOrder(vpc_OrderInfo);

            bool status = false;
            if (order != null && order.ID != 0 )
            {
                if (vpc_TxnResponseCode == "0")
                {
                    status = true;
                    if (!order.IsPayment)
                    {
                        if (_orderBusiness.UpdatePayment(order.ID))
                            _orderBusiness.Save();
                        if (_memberBusiness.AddPoint(order.Member, Convert.ToDouble(vpc_Amount) / 1000))
                            _memberBusiness.Save();
                    }
                    
                }
                else
                {
                    status = false;
                    if (_orderBusiness.UpdateStatus(order.ID, -1))
                        _orderBusiness.Save();
                }
            }
            ViewBag.StatusPayment = status;
            return View(order);
        }
        public ActionResult Confirm_Global(string vpc_OrderInfo, string vpc_3DSECI, string vpc_AVS_Street01, string vpc_Merchant, string vpc_Card, string vpc_AcqResponseCode, string AgainLink, string vpc_AVS_Country,
            string vpc_AuthorizeId, string vpc_3DSenrolled, string vpc_RiskOverallResult, string vpc_ReceiptNo, string vpc_TransactionNo, string vpc_AVS_StateProv, string vpc_Locale, string vpc_TxnResponseCode, string vpc_VerToken,
            string vpc_Amount, string vpc_BatchNo, string vpc_Version, string vpc_AVSResultCode, string vpc_VerStatus, string vpc_Command, string vpc_Message, string Title, string vpc_3DSstatus, string vpc_SecureHash, string vpc_AVS_PostCode,
            string vpc_CSCResultCode, string vpc_MerchTxnRef, string vpc_VerType, string vpc_VerSecurityLevel, string vpc_3DSXID, string vpc_AVS_City)
        {
            string log = "[Date]=[" + DateTime.Now + "]|[vpc_OrderInfo]=[" + vpc_OrderInfo + "]|[vpc_3DSECI]=[" + vpc_3DSECI + "]|[vpc_AVS_Street01]=[" + vpc_AVS_Street01 + "]|[vpc_Merchant]=[" + vpc_Merchant + "]|[vpc_Card]=[" + vpc_Card + "]|[vpc_AcqResponseCode]=[" + vpc_AcqResponseCode + "]|";
            log += "[AgainLink]=[" + AgainLink + "]|[vpc_AVS_Country]=[" + vpc_AVS_Country + "]|[vpc_AuthorizeId]=[" + vpc_AuthorizeId + "]|[vpc_3DSenrolled]=[" + vpc_3DSenrolled + "]|[vpc_RiskOverallResult]=[" + vpc_RiskOverallResult + "]|";
            log += "[vpc_ReceiptNo] =[" + vpc_ReceiptNo + "]|[vpc_TransactionNo]=[" + vpc_TransactionNo + "]|[vpc_TxnResponseCode]=[" + vpc_TxnResponseCode + "]|[vpc_MerchTxnRef]=[" + vpc_MerchTxnRef + "]|[vpc_AVSResultCode]=[" + vpc_AVSResultCode + "]|";
            Utils.WriteLogToFile(log);
            OrderView order = new OrderView();
            order = _orderBusiness.GetOrder(vpc_OrderInfo);

            bool status = false;
            if (order != null && order.ID != 0)
            {
                if (vpc_TxnResponseCode == "0" )
                {
                    status = true;
                    if (!order.IsPayment)
                    {
                        if (_orderBusiness.UpdatePayment(order.ID))
                            _orderBusiness.Save();
                        if (_memberBusiness.AddPoint(order.Member, Convert.ToDouble(vpc_Amount) / 1000))
                            _memberBusiness.Save();
                    }
                }
                else
                {
                    status = false;
                    if (_orderBusiness.UpdateStatus(order.ID, -1))
                        _orderBusiness.Save();
                }
            }
            ViewBag.StatusPayment = status;
            return View(order);
        }
        [HttpPost]
        public ActionResult CheckPromotion(ApplyPromotionParam model)
        {
            try
            {
                if (model != null && model.Code != "")
                {
                    var promotion = _promotionBusiness.ApplyPromotion(model.Code);
                    if (promotion != null && promotion.ID != 0)
                    {
                        double reduce = 0;
                        if (promotion.Type == 1)

                            reduce = promotion.AmountReduced;
                        else
                            reduce = (model.Price * promotion.PercentReduced) / 100;
                        return Json(new ApplyPromotionResponse { Status = 1, Price = String.Format("{0:0,00}", model.Price - reduce), Reduce = String.Format("{0:0,00}", reduce) });

                    }
                }
                return Json(new ApplyPromotionResponse { Status = -1, Price = String.Format("{0:0,00}", model.Price), Reduce = "0" });
            }
            catch (Exception)
            {

                return Json(new ApplyPromotionResponse { Status = -1, Price = String.Format("{0:0,00}", model.Price), Reduce = "0" });
            }
        }
        [HttpPost]
        public ActionResult Payment(PaymentParam model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null || login.ID == 0)
                    return Json(new PaymentResult { Status = -1, Uri = "" });

                double reduce = 0;

                var tour = _tourBusiness.GetDetail(model.TourID);
                if (tour != null && tour.ID != 0)
                {
                    var steps = _stepBusiness.GetAll(tour.ID);

                    if (model.PCode != "")
                    {
                        var promotion = _promotionBusiness.ApplyPromotion(model.PCode);
                        if (promotion != null && promotion.ID != 0)
                        {
                            if (promotion.TourApply == "" || promotion.TourApply == null)
                            {
                                if (promotion.Type == 1)
                                    reduce = promotion.AmountReduced;
                                else
                                    reduce = (tour.Price * promotion.PercentReduced) / 100;
                            }
                            else
                            {
                                if (promotion.TourApply.Contains(tour.ID.ToString()))
                                {
                                    if (promotion.Type == 1)
                                        reduce = promotion.AmountReduced;
                                    else
                                        reduce = (tour.Price * promotion.PercentReduced) / 100;
                                }
                            }
                        }
                    }

                    OrderView order = new OrderView();
                    order.Amount = tour.Price - reduce;
                    order.Code = $"{DateTime.Now.ToString("ddMMyy")}{RandomUtils.RandomString(6, 8, true, true, false)}";
                    order.Date = DateTime.Now;
                    order.IsPayment = false;
                    order.Member = login.ID;
                    order.MemberName = login.Name;
                    order.Price = tour.Price;
                    order.Reduce = reduce;
                    order.Status = 0;
                    order.Step = 0;
                    order.Tour = tour.ID;
                    if (_orderBusiness.Add(order))
                    {
                        _orderBusiness.Save();

                        long oID = _orderBusiness.GetID(order.Code);

                        if (steps != null && steps.Count() > 0 && oID != 0)
                        {
                            int max = steps.Count();
                            int count = 1;
                            foreach (var item in steps)
                            {
                                OrderDetailView detail = new OrderDetailView();
                                detail.IsAccomplish = false;
                                if (count == max)
                                    detail.IsLastStep = true;
                                else
                                    detail.IsLastStep = false;
                                detail.OrderID = oID;
                                detail.Rank = count;
                                detail.StepID = item.ID;
                                detail.StepName = item.Name;
                                if (_orderDetailBusiness.Add(detail))
                                    _orderDetailBusiness.Save();

                                count++;
                            }
                        }

                        if (model.TypePay == 0)
                        {
                            string uri = CreateRequestPaymentPort(order.Amount.ToString(), order.Code, login.ID.ToString());
                            return Json(new PaymentResult { Status = 1, Uri = uri });
                        }
                        if (model.TypePay == 1)
                        {
                            string uri = CreateRequestPaymentPortGlobal(order.Amount.ToString(), order.Code, login.ID.ToString());
                            return Json(new PaymentResult { Status = 1, Uri = uri });
                        }
                    }


                }
                return Json(new PaymentResult { Status = -1, Uri = "" });
            }
            catch (Exception)
            {

                return Json(new PaymentResult { Status = -1, Uri = "" });
            }
        }
        #region Method
        public string CreateRequestPaymentPort(string amount, string barCode, string phone)
        {
            string SECURE_SECRET = ConfigurationManager.AppSettings["SerectPaymentPort"].ToString();
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan
            VPCRequest_VN conn = new VPCRequest_VN(ConfigurationManager.AppSettings["UrlPaymentLocal"].ToString());
            conn.SetSecureSecret(SECURE_SECRET);
            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields
            conn.AddDigitalOrderField("Title", "onepay paygate");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", ConfigurationManager.AppSettings["MerchantPaymentPort"].ToString());
            conn.AddDigitalOrderField("vpc_AccessCode", ConfigurationManager.AppSettings["AccessCodePayMentPort"].ToString());
            conn.AddDigitalOrderField("vpc_MerchTxnRef", barCode.Split('-')[0]);
            conn.AddDigitalOrderField("vpc_OrderInfo", barCode);
            conn.AddDigitalOrderField("vpc_Amount", amount);
            conn.AddDigitalOrderField("vpc_Currency", "VND");
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://localhost:44345/xac-nhan-thanh-toan-noi-dia.html");
            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", "");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", "");
            conn.AddDigitalOrderField("vpc_SHIP_City", "");
            conn.AddDigitalOrderField("vpc_SHIP_Country", "");
            conn.AddDigitalOrderField("vpc_Customer_Phone", "");
            conn.AddDigitalOrderField("vpc_Customer_Email", "");
            conn.AddDigitalOrderField("vpc_Customer_Id", "");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", GetUserIP());
            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            return url;
        }
        public string CreateRequestPaymentPortGlobal(string amount, string barCode, string phone)
        {

            string SECURE_SECRET = ConfigurationManager.AppSettings["SerectPaymentPortGlobal"].ToString();
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan
            VPCRequest_Global conn = new VPCRequest_Global(ConfigurationManager.AppSettings["UrlPaymentGlobal"].ToString());
            conn.SetSecureSecret(SECURE_SECRET);
            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields

            conn.AddDigitalOrderField("AgainLink", "http://onepay.vn");
            conn.AddDigitalOrderField("Title", "onepay paygate");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", ConfigurationManager.AppSettings["MerchantPaymentPortGlobal"].ToString());
            conn.AddDigitalOrderField("vpc_AccessCode", ConfigurationManager.AppSettings["AccessCodePayMentPortGlobal"].ToString());
            conn.AddDigitalOrderField("vpc_MerchTxnRef", barCode.Split('-')[0]);
            conn.AddDigitalOrderField("vpc_OrderInfo", barCode);
            conn.AddDigitalOrderField("vpc_Amount", amount);
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://localhost:44345/xac-nhan-thanh-toan-quoc-te.html");
            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", " ");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", " ");
            conn.AddDigitalOrderField("vpc_SHIP_City", " ");
            conn.AddDigitalOrderField("vpc_SHIP_Country", " ");
            conn.AddDigitalOrderField("vpc_Customer_Phone", " ");
            conn.AddDigitalOrderField("vpc_Customer_Email", " ");
            conn.AddDigitalOrderField("vpc_Customer_Id", " ");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", GetUserIP());

            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            return url;
        }
        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion
    }
}