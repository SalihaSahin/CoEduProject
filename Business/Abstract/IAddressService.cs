using Core.Utitlities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IResult Add(Address address);
        IResult Delete(Address address);
        IResult Update(Address address);
        IDataResult<List<Address>> GetAll();
        IDataResult<Address> GetById(int addressId);
    }
}
