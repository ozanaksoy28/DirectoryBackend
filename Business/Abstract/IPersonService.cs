using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person);
        IResult Update(Person person);
        IResult Delete(Person person);
        IDataResult<List<Person>> GetAll();
        IDataResult<List<Person>> Favorites();
    }
}
