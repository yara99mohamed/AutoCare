using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class SparePartsRepository : IAutoRepository<SpareParts>
    {
        readonly AutoCareContext _autoCareContext;
        public SparePartsRepository(AutoCareContext context)
        {
            _autoCareContext = context;
        }
        public async Task<IEnumerable<SpareParts>> GetAll()
        {
            return await _autoCareContext.SpareParts.ToListAsync();
        }
        public async Task<SpareParts> Get(long? id)
        {
            return await _autoCareContext.SpareParts.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(SpareParts entity)
        {
            await _autoCareContext.SpareParts.AddAsync(entity);
            return await _autoCareContext.SaveChangesAsync();
        }
        public async Task<int> Update(long id, SpareParts entity)
        {
            var carSpareParts = await Get(id);
            carSpareParts.Details = entity.Details;
            carSpareParts.Price = entity.Price;
            carSpareParts.points = entity.points;
            return await _autoCareContext.SaveChangesAsync();
        }
        public async Task<int> Delete(SpareParts spareParts)
        {
            _autoCareContext.SpareParts.Remove(spareParts);
            return await _autoCareContext.SaveChangesAsync();
        }
    }
}
