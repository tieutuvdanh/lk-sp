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
    public interface IPromotionService
    {
        IEnumerable<Promotion> GetAll();

        Promotion Add(Promotion model);
        Promotion GetById(int id);
        void Update(Promotion model);
        Promotion Delete(int id);
        void SaveChange();

    }
    public   class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public PromotionService(IPromotionRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;

            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<Promotion> GetAll()
        {
            return _repository.GetAll();
        }

       
        public Promotion Add(Promotion model)
        {
            return _repository.Add(model);
        }

        public Promotion GetById(int id)
        {
            return _repository.GetSingleById(id);
        }

        public void Update(Promotion model)
        {
            _repository.Update(model);
        }

        public Promotion Delete(int id)
        {
            return _repository.Delete(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }

}
