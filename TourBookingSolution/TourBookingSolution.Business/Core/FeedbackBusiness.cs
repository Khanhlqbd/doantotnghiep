﻿using TourBookingSolution.Data.Models;
using TourBookingSolution.Services.Infrastructure;
using TourBookingSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TourBookingSolution.Business.Core
{
    public interface IFeedbackBusiness
    {
        IEnumerable<Feedback> GetAlls(string[] includes, Expression<Func<Feedback, bool>> filter);
        IEnumerable<Feedback> GetAlls();
        Feedback Add(Feedback entity);
        Feedback Update(Feedback entity, List<Expression<Func<Feedback, object>>> update = null, List<Expression<Func<Feedback, object>>> exclude = null);
        
        Feedback Delete(Feedback entity);
        void Save();
    }
   public class FeedbackBusiness : IFeedbackBusiness
    {
        private IFeedbackRepository _feedback;
        private IUnitOfWork _unitOfWork;
        public FeedbackBusiness(IFeedbackRepository feedback,IUnitOfWork unitOfWork)
        {
            _feedback = feedback;
            _unitOfWork = unitOfWork;
        }

        public Feedback Add(Feedback entity)
        {
            return _feedback.Add(entity);
        }

      
        public Feedback Delete(Feedback entity)
        {
            return _feedback.Delete(entity);
        }

        public IEnumerable<Feedback> GetAlls()
        {
            return _feedback.GetAll(null);
        }

        public IEnumerable<Feedback> GetAlls(string[] includes, Expression<Func<Feedback, bool>> filter)
        {
            return _feedback.GetAll(includes, filter);
        }

        public Feedback Update(Feedback entity, List<Expression<Func<Feedback, object>>> update = null, List<Expression<Func<Feedback, object>>> exclude = null)
        {
            return _feedback.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
