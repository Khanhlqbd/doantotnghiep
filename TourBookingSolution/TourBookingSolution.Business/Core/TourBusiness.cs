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
    public interface ITourBusiness
    {
        IEnumerable<TourView> GetAll();
        TourView GetDetail(long id);
        bool Add(TourView model);
        bool Edit(TourView model);
        bool StatusDelete(long id);
        void Save();
    }
    public class TourBusiness : ITourBusiness
    {
        private ITourRepository _tour;
        private IUnitOfWork _unitOfWork;
        public TourBusiness(ITourRepository tour, IUnitOfWork unitOfWork)
        {
            _tour = tour;
            _unitOfWork = unitOfWork;
        }

        public bool Add(TourView model)
        {
            return _tour.Add(model);
        }

        public bool Edit(TourView model)
        {
            return _tour.Edit(model);
        }

        public IEnumerable<TourView> GetAll()
        {
            return _tour.GetAll();
        }

        public TourView GetDetail(long id)
        {
            return _tour.GetDetail(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool StatusDelete(long id)
        {
            return _tour.StatusDelete(id);
        }
    }
}
