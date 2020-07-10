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
    public interface ITourRepository : IRepository<Tour>
    {
        IEnumerable<TourView> GetAll();
        TourView GetDetail(long id);
        bool Add(TourView model);
        bool Edit(TourView model);
        bool StatusDelete(long id);
    }
    public class TourRepository : RepositoryBase<Tour>, ITourRepository
    {
        public TourRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(TourView model)
        {
            try
            {
                int year, month, day;
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                if (model.DateStart == "" || model.EndDate == "")
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                    day = DateTime.Now.Day;
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = DateTime.Now.AddYears(1).Year;
                    month = DateTime.Now.AddYears(1).Month;
                    day = DateTime.Now.AddYears(1).Day;
                    end = new DateTime(year, month, day, 23, 59, 0);
                }
                else
                {
                    year = Convert.ToInt32(model.DateStart.Split('/')[2]);
                    month = Convert.ToInt32(model.DateStart.Split('/')[1]);
                    day = Convert.ToInt32(model.DateStart.Split('/')[0]);
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = Convert.ToInt32(model.EndDate.Split('/')[2]);
                    month = Convert.ToInt32(model.EndDate.Split('/')[1]);
                    day = Convert.ToInt32(model.EndDate.Split('/')[0]);
                    end = new DateTime(year, month, day, 0, 0, 0);
                }

                Tour tour = new Tour();
                tour.Avatar = "http://localhost:44351" + model.Avatar;
                tour.DateStart = start;
                tour.Desc = model.Desc;
                tour.DescTime = model.DescTime;
                tour.EndDate = end;
                tour.PlaceEnd = model.PlaceEnd;
                tour.PlaceStart = model.PlaceStart;
                tour.Price = model.Price;
                tour.Status = model.Status;
                tour.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                tour.Title = model.Title;
                DbContext.Tours.Add(tour);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(TourView model)
        {
            try
            {
                int year, month, day;
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                if (model.DateStart == "" || model.EndDate == "")
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                    day = DateTime.Now.Day;
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = DateTime.Now.AddYears(1).Year;
                    month = DateTime.Now.AddYears(1).Month;
                    day = DateTime.Now.AddYears(1).Day;
                    end = new DateTime(year, month, day, 23, 59, 0);
                }
                else
                {
                    year = Convert.ToInt32(model.DateStart.Split('/')[2]);
                    month = Convert.ToInt32(model.DateStart.Split('/')[1]);
                    day = Convert.ToInt32(model.DateStart.Split('/')[0]);
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = Convert.ToInt32(model.EndDate.Split('/')[2]);
                    month = Convert.ToInt32(model.EndDate.Split('/')[1]);
                    day = Convert.ToInt32(model.EndDate.Split('/')[0]);
                    end = new DateTime(year, month, day, 0, 0, 0);
                }

                var _item = DbContext.Tours.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    if (!model.Avatar.Contains("http"))
                        _item.Avatar = "http://localhost:44351" + model.Avatar;
                    else
                        _item.Avatar = model.Avatar;
                    _item.DateStart = start;
                    _item.Desc = model.Desc;
                    _item.DescTime = model.DescTime;
                    _item.EndDate = end;
                    _item.PlaceEnd = model.PlaceEnd;
                    _item.PlaceStart = model.PlaceStart;
                    _item.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                    _item.Price = model.Price;
                    _item.Status = model.Status;
                    _item.Title = model.Title;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<TourView> GetAll()
        {
            try
            {
                var _lst = DbContext.Tours.Where(x => x.Status == true);
                if (_lst != null && _lst.Count() > 0)
                {
                    List<TourView> tours = new List<TourView>();
                    foreach (var item in _lst)
                    {
                        TourView tour = new TourView();
                        tour.Avatar = item.Avatar;
                        tour.DateStart = item.DateStart.ToString("dd/MM/yyyy");
                        tour.Desc = item.Desc;
                        tour.DescTime = item.DescTime;
                        tour.EndDate = item.EndDate.ToString("dd/MM/yyyy");
                        tour.ID = item.ID;
                        tour.PlaceEnd = item.PlaceEnd;
                        tour.PlaceStart = item.PlaceStart;
                        tour.Price = item.Price;
                        tour.Content = item.Content;
                        tour.Status = item.Status;
                        tour.Title = item.Title;
                        tours.Add(tour);
                    }
                    return tours;
                }
                return new List<TourView>();
            }
            catch (Exception)
            {

                return new List<TourView>();
            }
        }

        public TourView GetDetail(long id)
        {
            try
            {
                var _item = DbContext.Tours.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    TourView tour = new TourView();
                    tour.Avatar = _item.Avatar;
                    tour.DateStart = _item.DateStart.ToString("dd/MM/yyyy");
                    tour.Desc = _item.Desc;
                    tour.DescTime = _item.DescTime;
                    tour.EndDate = _item.EndDate.ToString("dd/MM/yyyy");
                    tour.ID = _item.ID;
                    tour.PlaceEnd = _item.PlaceEnd;
                    tour.PlaceStart = _item.PlaceStart;
                    tour.Content = _item.Content;
                    tour.Price = _item.Price;
                    tour.Status = _item.Status;
                    tour.Title = _item.Title;
                    return tour;
                }
                return new TourView();
            }
            catch (Exception)
            {

                return new TourView();
            }
        }

        public bool StatusDelete(long id)
        {
            try
            {
                var _item = DbContext.Tours.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.Status = false;
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
