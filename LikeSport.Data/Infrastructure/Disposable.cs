using System;

namespace LikeSport.Data.Infrastructure
{
    /// <summary>
    /// Class override Interface IDisposable.
    /// </summary>
    public class Disposable :IDisposable        
    {

        #region IDisposable Support
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
        #endregion
      
    }
}
