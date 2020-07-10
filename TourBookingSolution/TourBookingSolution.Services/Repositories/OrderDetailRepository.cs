using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBookingSolution.Data.Models;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Services.Infrastructure;

namespace TourBookingSolution.Services.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IEnumerable<OrderDetailView> GetAll(long id);
        bool UpdateStep(int step,long id);
        
        bool Add(OrderDetailView model);
    }
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(OrderDetailView model)
        {
            try
            {
                OrderDetail detail = new OrderDetail();
                detail.IsAccomplish = model.IsAccomplish;
                detail.IsLastStep = model.IsLastStep;
                detail.OrderID = model.OrderID;
                detail.Rank = model.Rank;
                detail.StepID = model.StepID;
                detail.StepName = model.StepName;
                DbContext.OrderDetails.Add(detail);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<OrderDetailView> GetAll(long id)
        {
            try
            {
                var _lst = DbContext.OrderDetails.Where(x => x.OrderID == id);
                if(_lst!=null && _lst.Count() > 0)
                {
                    List<OrderDetailView> detailViews = new List<OrderDetailView>();
                    foreach (var item in _lst)
                    {
                        OrderDetailView view = new OrderDetailView();
                        view.IsAccomplish = item.IsAccomplish;
                        view.IsLastStep = item.IsLastStep;
                        view.OrderID = item.OrderID;
                        view.Rank = item.Rank;
                        view.StepID = item.StepID;
                        view.StepName = item.StepName;
                        detailViews.Add(view);
                    }
                    return detailViews;
                }
                return new List<OrderDetailView>();
            }
            catch (Exception)
            {
                return new List<OrderDetailView>();
            }
        }

        public bool UpdateStep(int step, long id)
        {
            try
            {
                var _item = DbContext.OrderDetails.FirstOrDefault(x => x.OrderID == id && x.StepID == step);
                if(_item!=null && _item.OrderID != 0)
                {
                    _item.IsAccomplish = true;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
