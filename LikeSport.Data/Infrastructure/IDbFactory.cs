
using System;

namespace LikeSport.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
 
        ActivitySportDbContext Init();
    }
}
