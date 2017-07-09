namespace LikeSport.Data.Infrastructure
{
    // Class Initial Instance of DB.
    public class DbFactory : Disposable, IDbFactory
    {
        ActivitySportDbContext dbContext;

        public ActivitySportDbContext Init()
        {
            // if dbContext != null return dbContext
            // else return new ActivitySportContainer
            return dbContext ?? (dbContext = new ActivitySportDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
