using ContactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Repositories.Interfaces
{
    public interface IContactRepository : IBaseCRUD<Contact> { }
}
