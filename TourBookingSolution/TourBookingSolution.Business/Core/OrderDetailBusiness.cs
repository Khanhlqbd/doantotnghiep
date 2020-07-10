using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Services.Infrastructure;
using TourBookingSolution.Services.Repositories;

namespace TourBookingSolution.Business.Core
{
    public interface IOrderDetailBusiness
    {
        IEnumerable<OrderDetailView> GetAll(long id);
        bool UpdateStep(int step, long id);

        bool Add(OrderDetailView model);
        void Save();
    }
    public class OrderDetailBusiness : IOrderDetailBusiness
    {
        private IOrderDetailRepository _orderDetail;
        private IUnitOfWork _unitOfWork;
        public OrderDetailBusiness(IOrderDetailRepository orderDetail, IUnitOfWork unitOfWork)
        {
            _orderDetail = orderDetail;
            _unitOfWork = unitOfWork;
        }

        public bool Add(OrderDetailView model)
        {
            return _orderDetail.Add(model);
        }

        public IEnumerable<OrderDetailView> GetAll(long id)
        {
            return _orderDetail.GetAll(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateStep(int step, long id)
        {
            return _orderDetail.UpdateStep(step, id);
        }
    }
}
