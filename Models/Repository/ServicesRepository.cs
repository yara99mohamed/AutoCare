using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class ServicesRepository : IAutoRepository<Services>
    {
        readonly AutoCareContext _autoCareContext;
        public ServicesRepository(AutoCareContext context)
        {
            _autoCareContext = context;
        }
        public async Task<IEnumerable<Services>> GetAll()
        {
            return await _autoCareContext.Services.ToListAsync();
        }
        public async Task<Services> Get(long? id)
        {
            return await _autoCareContext.Services.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(Services entity)
        {
            await _autoCareContext.Services.AddAsync(entity);
            return await _autoCareContext.SaveChangesAsync();
        }
        public async Task<int> Update(long id, Services entity)
        {
            var oldServies = await Get(id);
            oldServies.Details = entity.Details;
            oldServies.EarnedPoints = entity.EarnedPoints;
            oldServies.Price = entity.Price;
            oldServies.PriceInPoints = entity.PriceInPoints;
            return await _autoCareContext.SaveChangesAsync();
        }
        public async Task<int> Delete(Services services)
        {
            _autoCareContext.Services.Remove(services);
            return await _autoCareContext.SaveChangesAsync();
        }
    }
}
