using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class SignatureRepository : ISignatureRepository
    {
        public SignatureRepository(AntivirusContext context)
        {
            _antivirusContext = context;
        }

        private AntivirusContext _antivirusContext;
        public bool Add(Signature item)
        {
            _antivirusContext.Signatures.Add(item);
            _antivirusContext.SaveChanges();
            return true;
        }

        public bool Remove(Signature item)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Signature item)
        {
            throw new System.NotImplementedException();
        }

        public List<Signature> GetAllItems()
        {
            return _antivirusContext.Signatures.Include(x => x.Viruses).ToList();
        }

        public Signature GetItem(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}