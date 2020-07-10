using System.Collections.Generic;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Services.Infrastructure;
using TourBookingSolution.Services.Repositories;

namespace TourBookingSolution.Business.Core
{
    public interface IOrderBusiness
    {
        IEnumerable<OrderView> GetAll(int id);
        IEnumerable<OrderView> GetAll();
        bool Add(OrderView model);
        bool UpdateStatus(long id, int status);
        bool UpdatePayment(long id);
        OrderView GetOrder(string code);
        bool UpdateFileParticipants(long id, string path);
        long GetID(string code);
        bool UpdateSep(long id, int step);
        void Save();
    }
    class OrderBusiness : IOrderBusiness
    {
        private IOrderRepository _order;
        private IUnitOfWork _unitOfWork;
        public OrderBusiness(IOrderRepository order, IUnitOfWork unitOfWork)
        {
            _order = order;
            _unitOfWork = unitOfWork;
        }

        public bool Add(OrderView model)
        {
            return _order.Add(model);
        }

        public IEnumerable<OrderView> GetAll(int id)
        {
            return _order.GetAll(id);
        }

        public IEnumerable<OrderView> GetAll()
        {
            return _order.GetAll();
        }

        public long GetID(string code)
        {
            return _order.GetID(code);
        }

        public OrderView GetOrder(string code)
        {
            return _order.GetOrder(code);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateFileParticipants(long id, string path)
        {
            return _order.UpdateFileParticipants(id, path);
        }

        public bool UpdatePayment(long id)
        {
            return _order.UpdatePayment(id);
        }

        public bool UpdateSep(long id, int step)
        {
            return _order.UpdateSep(id, step);
        }

        public bool UpdateStatus(long id, int status)
        {
            return _order.UpdateStatus(id, status);
        }
    }
}
