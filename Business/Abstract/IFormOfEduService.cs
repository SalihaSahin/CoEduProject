using Core.Utitlities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFormOfEduService
    {
        IResult Add(FormOfEdu formOfEdu);
        IResult Delete(FormOfEdu formOfEdu);
        IResult Update(FormOfEdu formOfEdu);
        IDataResult<List<FormOfEdu>> GetAll();
        IDataResult<FormOfEdu> GetById(int formOfEduId);
    }
}
