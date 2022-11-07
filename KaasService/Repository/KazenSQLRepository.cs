using KaasService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaasService.Repository
{
    public class KazenSQLRepository : IKazenRepository
    {
        private readonly KazenDbContext context;

        public KazenSQLRepository(KazenDbContext context) => this.context = context;


        public async Task DeleteAsync(kazen kaas)
        {
            try
            {
                var artisten = context.Kazen.First();
                context.Remove(artisten);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var t = ex;
            }

        }
        //public IQueryable<kazen> FindAll()
        //{
        //    return context.Kazen;
        //}
        public async Task<List<kazen>> FindAllAsync() =>
      await context.Kazen.AsNoTracking().ToListAsync();

        public async Task<kazen> FindByIdAsync(int id) =>
          await context.Kazen.FindAsync(id);

        public async Task<List<kazen>> FindBySmaakAsync(string smaak) =>
           await context.Kazen.AsNoTracking().Where(kaas => kaas.smaak == smaak).ToListAsync();


        public async Task InsertAsync(kazen kaas)
        {
            await context.Kazen.AddAsync(kaas);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(kazen kaas)
        {
            context.Kazen.Update(kaas);
            await context.SaveChangesAsync();
        }
    }
}
