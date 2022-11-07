using KaasService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaasService.Repository
{
  public  interface IKazenRepository
    {
        Task<List<kazen>> FindAllAsync();
        Task<kazen> FindByIdAsync(int id);
        Task<List<kazen>> FindBySmaakAsync(string smaak);
        Task UpdateAsync(kazen kaas);
        Task DeleteAsync(kazen kaas);
        Task InsertAsync(kazen kaas);



    }
}
