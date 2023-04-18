using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Models.Request;
using WebApplication1.Models.Response;
using WebApplication1.Service.Interface;

namespace WebApplication1.Service.Implementation
{
    public class DataService : IDataService
    {
        private readonly HelpdeskSbContext _dbContext;
        public DataService(HelpdeskSbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ContactDetails CreateData(Contacts Contact)
        {
            ContactDetails details = new ContactDetails();
            TblContact contact = new TblContact()
            {
                Email = Contact.Email,
                Name = Contact.Name
            };
            _dbContext.TblContacts.Add(contact);
            if (_dbContext.SaveChangesAsync().Result == 1)
            {
                details.Email = Contact.Email;
                details.Name = Contact.Name;
            }
            return details;
        }

        public int Delete(int ContactId)
        {
            int IsFound = 0;
            TblContact contact = _dbContext.TblContacts.FirstOrDefault(x => x.ContactId == ContactId);
            if (contact != null)
            {
                _dbContext.TblContacts.Remove(contact);
                _dbContext.SaveChanges();
                IsFound = 1;
            }
            return IsFound;
        }

        public Task<List<ContactDetails>> Get()
        {
            return _dbContext.TblContacts.Select(p => new ContactDetails
            {
                ContactId = p.ContactId,
                Email = p.Email,
                Name = p.Name
            }).ToListAsync();
        }

        public Task<ContactDetails> Get(int ContactId)
        {
            return _dbContext.TblContacts.Where(id => id.ContactId.Equals(ContactId)).Select(p => new ContactDetails
            {
                ContactId = p.ContactId,
                Email = p.Email,
                Name = p.Name
            }).FirstOrDefaultAsync();
        }

        public int Update(ContactUpdate ContactUpdate)
        {
            int IsFound = 0;
            TblContact contact = _dbContext.TblContacts.FirstOrDefault(x => x.ContactId == ContactUpdate.ContactId);
            if (contact != null)
            {
                contact.Email = ContactUpdate.Email;
                contact.Name = ContactUpdate.Name;
                _dbContext.TblContacts.Update(contact);
                _dbContext.SaveChanges();
                IsFound = 1;
            }
            return IsFound;
        }
    }
}
