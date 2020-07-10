using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TourBookingSolution.Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "MemberLogin",
                url: "dang-nhap.html",
                defaults: new { controller = "Member", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MemberRegister",
                url: "dang-ky.html",
                defaults: new { controller = "Member", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MemberInfoChange",
                url: "cap-nhat-tai-khoan.html",
                defaults: new { controller = "Member", action = "InfoChange", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "MemberProfile",
                url: "thong-tin-tai-khoan.html",
                defaults: new { controller = "Member", action = "Profiles", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "NewsList",
                url: "tin-tuc.html",
                defaults: new { controller = "News", action = "List", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "NewsDetail",
                url: "tin-tuc/{title}-{id}.html",
                defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PromotionList",
                url: "khuyen-mai.html",
                defaults: new { controller = "Promotion", action = "List", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PromotionDetail",
                url: "khuyen-mai/{title}-{id}.html",
                defaults: new { controller = "Promotion", action = "Detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TourList",
                url: "tour.html",
                defaults: new { controller = "Tour", action = "List", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TourDetail",
                url: "tour/{title}-{id}.html",
                defaults: new { controller = "Tour", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TourBook",
                url: "dat-tour-{id}.html",
                defaults: new { controller = "Tour", action = "Booking", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan.html",
                defaults: new { controller = "Tour", action = "Payment", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "PaymentCofirm",
                url: "xac-nhan-thanh-toan-noi-dia.html",
                defaults: new { controller = "Tour", action = "Confirm", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PaymentGlobalConfirm",
                url: "xac-nhan-thanh-toan-quoc-te.html",
                defaults: new { controller = "Tour", action = "Confirm_Global", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
