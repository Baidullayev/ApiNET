using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiNET.ViewModel;
namespace ApiNET.Services
{
    public interface IPersonRepository
    {
        IEnumerable <PersonViewModel> GetAll();
        PersonViewModel GetByIin(string iin);
        void Create(PersonViewModel personViewModel);
        void Update(PersonViewModel personViewModel);
        void Delete(string iin);

    }
}