using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBookingSolution.Data.Models;
using TourBookingSolution.Data.ViewModels;
using TourBookingSolution.Services.Infrastructure;

namespace StepBookingSolution.Services.Repositories
{
    public interface IStepRepository : IRepository<Step>
    {
        IEnumerable<StepView> GetAll(long id);
        StepView GetDetail(long id);
        bool Add(StepView model);
        bool Edit(StepView model);
        bool Delete(long id);
    }
    public class StepRepository : RepositoryBase<Step>, IStepRepository
    {
        public StepRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(StepView model)
        {
            try
            {

                Step step = new Step();
                step.Desc = model.Desc;
                step.Name = model.Name;
                step.GuideName = model.GuideName;
                step.Place = model.Place;
                step.Rank = model.Rank;
                step.Tour = model.Tour;
                DbContext.Steps.Add(step);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(StepView model)
        {
            try
            {
                

                var _item = DbContext.Steps.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    _item.Desc = model.Desc;
                    _item.Name =model.Name;
                    _item.GuideName = model.GuideName;
                    _item.Place = model.Place;
                    _item.Rank = model.Rank;
                    _item.Tour = model.Tour;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<StepView> GetAll(long id)
        {
            try
            {
                var _lst = from t in DbContext.Tours
                           from s in DbContext.Steps
                           where t.ID == s.Tour
                           && t.ID == id
                           select new
                           {
                               ID = s.ID,
                               Name = s.Name,
                               Place = s.Place,
                               GuideName = s.GuideName,
                               Desc = s.Desc,
                               Rank = s.Rank,
                               Tour = s.Tour,
                               TourName = t.Title
                           };
                if(_lst!=null && _lst.Count() > 0)
                {
                    List<StepView> steps = new List<StepView>();
                    foreach(var item in _lst)
                    {
                        StepView step = new StepView();
                        step.Desc = item.Desc;
                        step.Name = item.Name;
                        step.GuideName = item.GuideName;
                        step.ID = item.ID;
                        step.Place = item.Place;
                        step.Rank = item.Rank;
                        step.Tour = item.Tour;
                        step.TourName = item.TourName;
                        steps.Add(step);
                    }
                    return steps;
                }
                return new List<StepView>();
            }
            catch (Exception)
            {

                return new List<StepView>();
            }
        }

        public StepView GetDetail(long id)
        {
            try
            {
                var _item = DbContext.Steps.Find(id);
                if(_item!=null && _item.ID != 0)
                {
                    StepView step = new StepView();
                    step.Desc = _item.Desc;
                    step.Name = _item.Name;
                    step.GuideName = _item.GuideName;
                    step.ID = _item.ID;
                    step.Place = _item.Place;
                    step.Rank = _item.Rank;
                    step.Tour = _item.Tour;
                    return step;
                }
                return new StepView();
            }
            catch (Exception)
            {

                return new StepView();
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var _item = DbContext.Steps.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    DbContext.Steps.Remove(_item);
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
