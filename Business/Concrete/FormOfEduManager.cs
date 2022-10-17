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
    public class FormOfEduManager:IFormOfEduService
    {
        IFormOfEduDal _formOfEduDal;

        public FormOfEduManager(IFormOfEduDal formOfEduDal)
        {
            _formOfEduDal = formOfEduDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(FormOfEduValidator))]
        [CacheRemoveAspect("IFormOfEdu Service.Get")]
        public IResult Add(FormOfEdu formOfEdu)
        {
            _formOfEduDal.Add(formOfEdu);
            return new SuccessResult(Messages.FormOfEduAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(FormOfEdu formOfEdu)
        {
            _formOfEduDal.Delete(formOfEdu);
            return new SuccessResult(Messages.FormOfEduDeleted);
        }

        [CacheAspect]
        public IDataResult<List<FormOfEdu>> GetAll()
        {

            return new SuccessDataResult<List<FormOfEdu>>(_formOfEduDal.GetAll(), Messages.FormOfEduListed);
        }

        [CacheAspect]
        public IDataResult<FormOfEdu> GetById(int formOfEduId)
        {
            return new SuccessDataResult<FormOfEdu>(_formOfEduDal.Get(f => f.Id == formOfEduId));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IFormOfEdu Service.Get")]
        public IResult Update(FormOfEdu formOfEdu)
        {
            _formOfEduDal.Update(formOfEdu);
            return new SuccessResult(Messages.FormOfEduUpdated);
        }
    }
}
