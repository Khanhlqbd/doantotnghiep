using TourBookingSolution.Data.Models;
using TourBookingSolution.Services.Infrastructure;

namespace TourBookingSolution.Services.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {

    }
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
