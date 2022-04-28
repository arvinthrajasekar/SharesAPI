using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharesAPI.Models
{
    public class MockSharesRepository : ISharesRepository
    {
        
        public IEnumerable<Shares> AllShares =>
            new List<Shares>
            {
                //List < Shares > AllShares = new List<Shares>();
                new Shares { Name = "3M India Ltd", Price = 21145 },
                new Shares { Name = "Aarti Drugs Ltd", Price = 519 },
                new Shares { Name = "Tata Power", Price = 277.8 },
                new Shares { Name = "HDFC Bank", Price = 1516.75 },
                new Shares { Name = "Zee Entertainment", Price = 284.75 }

                 /////
            };

        public Task CreateAsync(Shares shares)
        {
            throw new System.NotImplementedException();
        }

        public Shares GetShares(string name)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Shares> ISharesRepository.AllShares()
        {
            throw new System.NotImplementedException();
        }
        /*public Shares GetShares(string name)
{
var result = from r in AllShares
       where r.Name == name
       select new { Name = r.Name, Price = r.Price };
if (result.Count() == 0)
{
return NotFound("Company Does not exist.");

}

return result;
}*/


    }
}
