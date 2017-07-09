using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeSport.Data.Infrastructure
{
    /// <summary>
    /// Interface for Inject to Respositories.
    /// </summary>
    public interface IUnitOfWork
    {
        void Commit();
    }
}
