/// <summary>
/// This Interface is response create new Install access db.
/// </summary>
namespace LikeSport.Data.Infrastructure
{
    public interface IDbFactory
    {
        /// <summary>
        /// Initital Object DB
        /// </summary>
        /// <returns>ActivitySportObject.</returns>
        ActivitySportDbContext Init();
    }
}
