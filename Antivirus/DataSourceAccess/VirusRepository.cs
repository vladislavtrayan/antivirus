using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataSourceAccess
{
    public class VirusRepository : IVirusRepository
    {
        public VirusRepository(AntivirusContext context)
        {
            _antivirusContext = context;
        }

        private AntivirusContext _antivirusContext;
        
        public bool Add(Virus item)
        {
            _antivirusContext.Add(item);
            _antivirusContext.SaveChanges();
            return true;
        }

        public bool Remove(Virus item)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Virus item)
        {
            throw new System.NotImplementedException();
        }

        public List<Virus> GetAllItems()
        {
            return _antivirusContext.Viruses.ToList();
        }

        public Virus GetItem(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}