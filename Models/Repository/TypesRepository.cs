using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class TypesRepository : IAutoRepository<Models.Type>
    {
        readonly AutoCareContext _AutoTypeContext;
        public TypesRepository(AutoCareContext Context)
        {
            _AutoTypeContext = Context;
        }

        public async Task<IEnumerable<Models.Type>> GetAll()
        {
            return await _AutoTypeContext.Types.OrderBy(c => c.Name).ToListAsync();
        }
        public async Task<int> Add(Models.Type entity)
        {
            entity.ModifiedOn = DateTime.Now;
            entity.CreateOn = DateTime.Now;
            if (await _AutoTypeContext.Types.AnyAsync(n => n.Name == entity.Name))
            {
                return -1;

            }
            entity.IsActive = true;
            await _AutoTypeContext.Types.AddAsync(entity);
            return await _AutoTypeContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Models.Type entity)
        {
            _AutoTypeContext.Types.Remove(entity);
            return await _AutoTypeContext.SaveChangesAsync();
        }

        public async Task<Type> Get(long? id)
        {
            return await _AutoTypeContext.Types.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> Update(long id, Models.Type entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var oldType = await Get(id);
            if(await _AutoTypeContext.Types.AnyAsync(t=>t.Name == entity.Name))
            {
                return -1;
            }
            oldType.Name = entity.Name;
            return await _AutoTypeContext.SaveChangesAsync();
        }
    }
}
