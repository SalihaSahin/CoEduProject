using Core.Utitlities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISportEduService
    {
        IResult Add(SportEdu sportedu);
        IResult Delete(SportEdu sportedu);
        IResult Update(SportEdu sportedu);
        IDataResult<List<SportEdu>> GetAll();
        IDataResult<SportEdu> GetById(int sportEduId);
    }
}
