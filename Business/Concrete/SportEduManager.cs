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
    public class SportEduManager:ISportEduService
    {
        ISportEduDal _sportEduDal;

        public SportEduManager(ISportEduDal sportEduDal)
        {
            _sportEduDal = sportEduDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(SportEduValidator))]
        [CacheRemoveAspect("ISportEduService.Get")]
        public IResult Add(SportEdu sportEdu)
        {
            _sportEduDal.Add(sportEdu);
            return new SuccessResult(Messages.SportEduAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(SportEdu sportEdu)
        {
            _sportEduDal.Delete(sportEdu);
            return new SuccessResult(Messages.SportEduDeleted);
        }

        [CacheAspect]
        public IDataResult<List<SportEdu>> GetAll()
        {

            return new SuccessDataResult<List<SportEdu>>(_sportEduDal.GetAll(), Messages.SportEduListed);
        }

        [CacheAspect]
        public IDataResult<SportEdu> GetById(int sportEduId)
        {
            return new SuccessDataResult<SportEdu>(_sportEduDal.Get(s => s.Id == sportEduId));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ISportEduService.Get")]
        public IResult Update(SportEdu sportEdu)
        {
            _sportEduDal.Update(sportEdu);
            return new SuccessResult(Messages.SportEduUpdated);
        }
    }
}
