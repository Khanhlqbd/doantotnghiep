using System;

namespace TourBookingSolution.Services.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        EntitiesDbContext Init();
    }
}
