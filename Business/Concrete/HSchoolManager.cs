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
    public class HSchoolManager:IHSchoolEduService
    {
        IHSchoolEduDal _hSchoolEduDal;

        public HSchoolManager(IHSchoolEduDal hSchoolEduDal)
        {
            _hSchoolEduDal = hSchoolEduDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(HSchoolEduValidator))]
        [CacheRemoveAspect("IHSchoolEduService.Get")]
        public IResult Add(HSchoolEdu hSchoolEdu)
        {
            _hSchoolEduDal.Add(hSchoolEdu);
            return new SuccessResult(Messages.HSchoolEduAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(HSchoolEdu hSchoolEdu)
        {
            _hSchoolEduDal.Delete(hSchoolEdu);
            return new SuccessResult(Messages.HSchoolEduDeleted);
        }

        [CacheAspect]
        public IDataResult<List<HSchoolEdu>> GetAll()
        {

            return new SuccessDataResult<List<HSchoolEdu>>(_hSchoolEduDal.GetAll(), Messages.HSchoolEduListed);
        }

        [CacheAspect]
        public IDataResult<HSchoolEdu> GetById(int hSchoolEduId)
        {
            return new SuccessDataResult<HSchoolEdu>(_hSchoolEduDal.Get(h => h.Id == hSchoolEduId));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IHSchoolEduService.Get")]
        public IResult Update(HSchoolEdu hSchoolEdu)
        {
            _hSchoolEduDal.Update(hSchoolEdu);
            return new SuccessResult(Messages.HSchoolEduUpdated);
        }
    }
}
