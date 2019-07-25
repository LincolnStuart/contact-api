using ContactApi.Models;
using ContactApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationContext context) : base(context) { }

        public IList<Contact> All()
        {
            return dbSet.ToList();
        }

        public void Create(Contact model)
        {
            dbSet.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = Get(id);
            if(contact == null)
            {
                throw new ArgumentException("Invalid argument.", nameof(id));
            }
        }

        public Contact Get(int id)
        {
            return dbSet.Where(c => c.Id == id).SingleOrDefault();
        }

        public void Update(Contact model)
        {
            if (model == null)
            {
                throw new ArgumentException("Invalid argument.", nameof(model));
            }
            var contact = Get(model.Id);
            if(contact == null)
            {
                throw new ArgumentException("Invalid argument.", nameof(model));
            }
            contact.CopyAtributesFrom(model);
            context.SaveChanges();
        }
    }
}
