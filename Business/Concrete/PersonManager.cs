using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public IResult Add(Person person)
        {
            IResult result = BusinessRules.Run(CheckIfPhoneNumberxists(person.PhoneNumber));
            if (result != null)
            {
                return result;
            }
            _personDal.Add(person);
            return new SuccessResult(Messages.PersonAdded);
        }

        public IResult Delete(Person person)
        {
            Person deleted = new Person();
            deleted = _personDal.Get(p => p.Id == person.Id);
            _personDal.Delete(deleted);
            return new SuccessResult(Messages.PersonDeleted);
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetAll(), Messages.PersonsListed);
        }
        public IDataResult<List<Person>> Favorites()
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetAll(p=>p.Fav==true), Messages.PersonsListed);
        }

        public IResult Update(Person person)
        {
            Person updated = new Person();
            updated = _personDal.Get(p => p.Id == person.Id);
            updated = person;
            _personDal.Update(updated);
            return new SuccessResult(Messages.PersonUpdated);
        }
        private IResult CheckIfPhoneNumberxists(string phoneNumber)
        {
            var result = _personDal.GetAll(p => p.PhoneNumber == phoneNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.PhonenumberAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
