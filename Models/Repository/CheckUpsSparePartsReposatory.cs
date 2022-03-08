using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class CheckUpsSparePartsReposatory : IAutoRepository<CheckUpsSpareParts>
    {
        readonly AutoCareContext _AutoCheckUpsContext;
        public CheckUpsSparePartsReposatory(AutoCareContext context)
        {
            _AutoCheckUpsContext = context;
        }
        public async Task<IEnumerable<CheckUpsSpareParts>> GetAll()
        {
            return await _AutoCheckUpsContext.CheckUpsSpareParts.ToListAsync();
        }
        public async Task<CheckUpsSpareParts> Get(long? id)
        {
            return await _AutoCheckUpsContext.CheckUpsSpareParts
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(CheckUpsSpareParts entity)
        {
            entity.CreateOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;
            await _AutoCheckUpsContext.CheckUpsSpareParts.AddAsync(entity);
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
        public async Task<int> Update(long id, CheckUpsSpareParts entity)
        {
            var oldCheckUp = await Get(id);

            entity.ModifiedOn = DateTime.Now;
            oldCheckUp.CarCheckUps = entity.CarCheckUps;
            oldCheckUp.CheckUpsId = entity.CheckUpsId;
            oldCheckUp.CarSparePart = entity.CarSparePart;
            oldCheckUp.SparePartsId = entity.SparePartsId;

            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
        public async Task<int> Delete(CheckUpsSpareParts CheckUpsSpareParts)
        {
            _AutoCheckUpsContext.CheckUpsSpareParts.Remove(CheckUpsSpareParts);
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
    }
}
