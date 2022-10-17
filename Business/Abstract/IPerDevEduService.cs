using Core.Utitlities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPerDevEduService
    {
        IResult Add(PerDevEdu perDevEdu);
        IResult Delete(PerDevEdu perDevEdu);
        IResult Update(PerDevEdu perDevEdu);
        IDataResult<List<PerDevEdu>> GetAll();
        IDataResult<PerDevEdu> GetById(int perDevEduId);
    }
}
