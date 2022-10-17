using Core.Utitlities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHSchoolEduService
    {
        IResult Add(HSchoolEdu hSchoolEdu);
        IResult Delete(HSchoolEdu hSchoolEdu);
        IResult Update(HSchoolEdu hSchoolEdu);
        IDataResult<List<HSchoolEdu>> GetAll();
        IDataResult<HSchoolEdu> GetById(int hSchoolEduId);
    }
}
