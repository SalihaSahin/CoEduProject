using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PerDevEduManager: IPerDevEduService
    {
        IPerDevEduDal _perDevEduDal;

        public PerDevEduManager(IPerDevEduDal perDevEduDal)
        {
            _perDevEduDal = perDevEduDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PerDevEduValidator))]
        [CacheRemoveAspect("IPerDevEduService.Get")]
        public IResult Add(PerDevEdu perDevEdu)
        {
            _perDevEduDal.Add(perDevEdu);
            return new SuccessResult(Messages.PerDevEduAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(PerDevEdu perDevEdu)
        {
            _perDevEduDal.Delete(perDevEdu);
            return new SuccessResult(Messages.PerDevEduDeleted);
        }

        [CacheAspect]
        public IDataResult<List<PerDevEdu>> GetAll()
        {

            return new SuccessDataResult<List<PerDevEdu>>(_perDevEduDal.GetAll(), Messages.PerDevEduListed);
        }

        [CacheAspect]
        public IDataResult<PerDevEdu> GetById(int perDevEduId)
        {
            return new SuccessDataResult<PerDevEdu>(_perDevEduDal.Get(p => p.Id == perDevEduId));
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IPerDevEduService.Get")]
        public IResult Update(PerDevEdu perDevEdu)
        {
            _perDevEduDal.Update(perDevEdu);
            return new SuccessResult(Messages.PerDevEduUpdated);
        }
    }
}
