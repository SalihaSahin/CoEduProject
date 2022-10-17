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
    public class AddressManager:IAddressService
    {
        IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(AddressValidator))]
        [CacheRemoveAspect("IAddressService.Get")]
        public IResult Add(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressAdded);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(Messages.AddressDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Address>> GetAll()
        {

            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(), Messages.AddressListed);
        }

        [CacheAspect]
        public IDataResult<Address> GetById(int addressId)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(a => a.Id == addressId));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IAddressService.Get")]
        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(Messages.AddressUpdated);
        }
    }
}
