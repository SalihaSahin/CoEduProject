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
    public class EducationManager:IEducationService
    {
        IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(EducationValidator))]
        [CacheRemoveAspect("IEducationEdu Service.Get")]
        public IResult Add(Education education)
        {
            _educationDal.Add(education);
            return new SuccessResult(Messages.EducationAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Education education)
        {
            _educationDal.Delete(education);
            return new SuccessResult(Messages.EducationDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Education>> GetAll()
        {

            return new SuccessDataResult<List<Education>>(_educationDal.GetAll(), Messages.EducationListed);
        }

        [CacheAspect]
        public IDataResult<Education> GetById(int eduId)
        {
            return new SuccessDataResult<Education>(_educationDal.Get(e => e.Id == eduId));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IEducationEdu Service.Get")]
        public IResult Update(Education education)
        {
            _educationDal.Update(education);
            return new SuccessResult(Messages.EducationUpdated);
        }
    }
}
