using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Data.Infrastructure;
using LikeSport.Data.Respositories;
using LikeSport.Model;

namespace LikeSport.Service
{
    public interface IServiceService
    {
        IEnumerable<Model.Service> GetAllService();
        Model.Service Add(Model.Service service);
        Model.Service GetById(int id);
        void Update(Model.Service service);
        Model.Service Delete(int id);
        void SaveService();

    }
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            this._serviceRepository = serviceRepository;

            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<Model.Service> GetAllService()
        {
            return _serviceRepository.GetAll();
        }

        public Model.Service Add(Model.Service service)
        {
            return _serviceRepository.Add(service);
        }

        public Model.Service GetById(int id)
        {
            return _serviceRepository.GetSingleById(id);
        }

        public void Update(Model.Service service)
        {
            _serviceRepository.Update(service);
        }

        public Model.Service Delete(int id)
        {
            return _serviceRepository.Delete(id);
        }

        public void SaveService()
        {
            _unitOfWork.Commit();
        }
    }
}
