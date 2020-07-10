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
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderView> GetAll(int id);
        IEnumerable<OrderView> GetAll();
        OrderView GetOrder(string code);
        bool Add(OrderView model);
        bool UpdateStatus(long id, int status);
        bool UpdatePayment(long id);
        bool UpdateFileParticipants(long id, string path);
        bool CheckExistsCode(string code);
        long GetID(string code);
        bool UpdateSep(long id, int step);
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(OrderView model)
        {
            try
            {
                Order order = new Order();
                order.Amount = model.Amount;
                order.Date = DateTime.Now;
                order.FileParticipants = model.FileParticipants;
                order.IsPayment = model.IsPayment;
                order.Member = model.Member;
                order.Price = model.Price;
                order.Reduce = model.Reduce;
                order.Status = model.Status;
                order.Tour = model.Tour;
                order.Code = model.Code;
                DbContext.Orders.Add(order);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CheckExistsCode(string code)
        {
            try
            {
                var _item = DbContext.Orders.FirstOrDefault(x => x.Code == code);
                if (_item != null && _item.ID != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {

                return true;
            }
        }

        public IEnumerable<OrderView> GetAll(int id)
        {
            try
            {
                var _lst = from t in DbContext.Tours
                           from o in DbContext.Orders
                           from m in DbContext.Members
                           where t.ID == o.Tour
                           && m.ID == o.Member
                           && o.Member == id
                           select new
                           {
                               ID = o.ID,
                               Tour = o.Tour,
                               TourName = t.Title,
                               Date = o.Date,
                               Status = o.Status,
                               IsPayment = o.IsPayment,
                               Member = o.Member,
                               MemberName = m.Name,
                               FileParticipants = o.FileParticipants,
                               Price = o.Price,
                               Reduce = o.Reduce,
                               Amount = o.Amount,
                               Code = o.Code
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    List<OrderView> orders = new List<OrderView>();
                    foreach (var item in _lst)
                    {
                        OrderView order = new OrderView();
                        order.Amount = item.Amount;
                        order.Date = item.Date;
                        order.FileParticipants = item.FileParticipants;
                        order.ID = item.ID;
                        order.IsPayment = item.IsPayment;
                        order.Member = item.Member;
                        order.MemberName = item.MemberName;
                        order.Price = item.Price;
                        order.Reduce = item.Reduce;
                        order.Status = item.Status;
                        order.Tour = item.Tour;
                        order.TourName = item.TourName;
                        order.Code = item.Code;
                        orders.Add(order);
                    }
                    return orders;
                }
                return new List<OrderView>();
            }
            catch (Exception)
            {

                return new List<OrderView>();
            }
        }

        public IEnumerable<OrderView> GetAll()
        {
            try
            {
                var _lst = from t in DbContext.Tours
                           from o in DbContext.Orders
                           from m in DbContext.Members
                           where t.ID == o.Tour
                           && m.ID == o.Member
                           select new
                           {
                               ID = o.ID,
                               Tour = o.Tour,
                               TourName = t.Title,
                               Date = o.Date,
                               Status = o.Status,
                               IsPayment = o.IsPayment,
                               Member = o.Member,
                               MemberName = m.Name,
                               FileParticipants = o.FileParticipants,
                               Price = o.Price,
                               Reduce = o.Reduce,
                               Amount = o.Amount,
                               Code=o.Code
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    List<OrderView> orders = new List<OrderView>();
                    foreach (var item in _lst)
                    {
                        OrderView order = new OrderView();
                        order.Amount = item.Amount;
                        order.Date = item.Date;
                        order.FileParticipants = item.FileParticipants;
                        order.ID = item.ID;
                        order.IsPayment = item.IsPayment;
                        order.Member = item.Member;
                        order.MemberName = item.MemberName;
                        order.Price = item.Price;
                        order.Reduce = item.Reduce;
                        order.Status = item.Status;
                        order.Tour = item.Tour;
                        order.TourName = item.TourName;
                        order.Code = item.Code;
                        orders.Add(order);
                    }
                    return orders;
                }
                return new List<OrderView>();
            }
            catch (Exception)
            {

                return new List<OrderView>();
            }
        }

        public long GetID(string code)
        {
            try
            {
                var _item = DbContext.Orders.FirstOrDefault(x => x.Code == code);
                if (_item != null && _item.ID != 0)
                    return _item.ID;
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public OrderView GetOrder(string code)
        {
            try
            {
                var _item = DbContext.Orders.FirstOrDefault(x => x.Code == code);
                if (_item != null && _item.ID != 0)
                {
                    OrderView order = new OrderView();
                    order.Amount = _item.Amount;
                    order.Code = _item.Code;
                    order.Date = _item.Date;
                    order.ID = _item.ID;
                    order.IsPayment = _item.IsPayment;
                    order.Member = _item.Member;
                    order.MemberName = DbContext.Members.Find(_item.Member).Name;
                    order.Price = _item.Price;
                    order.Reduce = _item.Reduce;
                    order.Status = _item.Status;
                    order.Step = _item.Step;
                    order.Tour = _item.Tour;
                    order.TourName = DbContext.Tours.Find(_item.Tour).Title;
                    return order;
                }
                return new OrderView();
            }
            catch (Exception)
            {

                return new OrderView();
            }
        }

        public bool UpdateFileParticipants(long id, string path)
        {
            try
            {
                var _item = DbContext.Orders.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.FileParticipants = path;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdatePayment(long id)
        {
            try
            {
                var _item = DbContext.Orders.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.IsPayment = true;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateStatus(long id, int status)
        {
            try
            {
                var _item = DbContext.Orders.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.Status = status;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateSep(long id, int step)
        {
            try
            {
                var _item = DbContext.Orders.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.Step = step;
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
