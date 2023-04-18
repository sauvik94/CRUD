using WebApplication1.Models.Request;
using WebApplication1.Models.Response;

namespace WebApplication1.Service.Interface
{
    public interface IDataService
    {
        public Task<List<ContactDetails>> Get();
        public Task<ContactDetails> Get(int ContactId);
        public ContactDetails CreateData(Contacts Contact);
        public int Delete(int ContactId);
        public int Update(ContactUpdate ContactUpdate);
    }
}
