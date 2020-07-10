using StepBookingSolution.Services.Repositories;
using System.Collections.Generic;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Services.Infrastructure;

namespace TourBookingSolution.Business.Core
{
    public interface IStepBusiness
    {
        IEnumerable<StepView> GetAll(long id);
        StepView GetDetail(long id);
        bool Add(StepView model);
        bool Edit(StepView model);
        bool Delete(long id);
        void Save();
    }
     public class StepBusiness: IStepBusiness
    {
        private IStepRepository _step;
        private IUnitOfWork _unitOfWork;
        public StepBusiness(IStepRepository step, IUnitOfWork unitOfWork)
        {
            _step = step;
            _unitOfWork = unitOfWork;
        }

        public bool Add(StepView model)
        {
            return _step.Add(model);
        }

        public bool Delete(long id)
        {
            return _step.Delete(id);
        }

        public bool Edit(StepView model)
        {
            return _step.Edit(model);
        }

        public IEnumerable<StepView> GetAll(long id)
        {
            return _step.GetAll(id);
        }

        public StepView GetDetail(long id)
        {
            return _step.GetDetail(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
